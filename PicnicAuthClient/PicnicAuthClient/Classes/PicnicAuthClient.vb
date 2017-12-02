
Imports RestSharp

Public Class PicnicAuthClient
    Implements IPicnicAuthClient

    Private ReadOnly restClient As IRestClient

    Private apiKey As String

    Private authUsersEndpoint As AuthUsersEndpoint

    Private authUsersSecretsEndpoint As AuthUsersSecretsEndpoint

    Private companiesEndpoint As CompaniesEndpoint

    Private hotpsEndpoint As HotpsEndpoint

    Private totpsEndpoint As TotpsEndpoint

    Private tokensEndpoint As TokensEndpoint

    Public Sub New(ByVal baseEndpoint As Uri, ByVal apiKey As String)
        restClient = New RestClient(baseEndpoint)
        Me.apiKey = apiKey
        CreateEndpoints()
    End Sub

    Private Sub CreateEndpoints()
        authUsersEndpoint = New AuthUsersEndpoint(restClient, apiKey)
        authUsersSecretsEndpoint = New AuthUsersSecretsEndpoint(restClient, apiKey)
        companiesEndpoint = New CompaniesEndpoint(restClient, apiKey)
        hotpsEndpoint = New HotpsEndpoint(restClient, apiKey)
        totpsEndpoint = New TotpsEndpoint(restClient, apiKey)
        tokensEndpoint = New TokensEndpoint(restClient)
    End Sub

    Public Function Login(ByVal username As String, ByVal password As String) As IRestResponse(Of TokenResponse) Implements IPicnicAuthClient.Login
        Dim response As IRestResponse(Of TokenResponse) = tokensEndpoint.GetApiKey(username, password)
        apiKey = response.Data.access_token
        CreateEndpoints()
        Return response
    End Function

    Public Function GetAuthUsers(ByVal Optional page As Integer = 1, ByVal Optional pageCount As Integer = 10) As IRestResponse(Of AuthUsersInCompany) Implements IPicnicAuthClient.GetAuthUsers
        Return authUsersEndpoint.GetAuthUsersForLoggedCompany(page, pageCount)
    End Function

    Public Function AddAuthUser(ByVal addAuthUserArgument As AddAuthUserArgument) As IRestResponse(Of CreatedAuthUser) Implements IPicnicAuthClient.AddAuthUser
        Return authUsersEndpoint.AddAuthUser(addAuthUserArgument)
    End Function

    Public Function GenereteNewSecret(ByVal userId As Guid) As IRestResponse(Of CreatedAuthUser) Implements IPicnicAuthClient.GenereteNewSecret
        Return authUsersSecretsEndpoint.GenereteNewSecret(userId)
    End Function

    Public Function GetLoggedCompany() As IRestResponse(Of LoggedCompany) Implements IPicnicAuthClient.GetLoggedCompany
        Return companiesEndpoint.GetLoggedCompany()
    End Function

    Public Function AddCompany(ByVal addCompanyArgument As AddCompanyArgument) As IRestResponse(Of IdentityResult) Implements IPicnicAuthClient.AddCompany
        Return companiesEndpoint.AddCompany(addCompanyArgument)
    End Function

    Public Function GetHotpForAuthUser(ByVal userId As Guid) As IRestResponse(Of OneTimePassword) Implements IPicnicAuthClient.GetHotpForAuthUser
        Return hotpsEndpoint.GetHotpForAuthUser(userId)
    End Function

    Public Function ValidateHotpForAuthUser(ByVal userId As Guid, ByVal hotp As String) As IRestResponse(Of OtpValidationResult) Implements IPicnicAuthClient.ValidateHotpForAuthUser
        Return hotpsEndpoint.ValidateHotpForAuthUser(userId, hotp)
    End Function

    Public Function GetTotpForAuthUser(ByVal userId As Guid) As IRestResponse(Of OneTimePassword) Implements IPicnicAuthClient.GetTotpForAuthUser
        Return totpsEndpoint.GetTotpForAuthUser(userId)
    End Function

    Public Function ValidateTotpForAuthUser(ByVal userId As Guid, ByVal totp As String) As IRestResponse(Of OtpValidationResult) Implements IPicnicAuthClient.ValidateTotpForAuthUser
        Return totpsEndpoint.ValidateTotpForAuthUser(userId, totp)
    End Function
End Class