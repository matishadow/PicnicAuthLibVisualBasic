Imports RestSharp

Public interface IPicnicAuthClient
    Function Login(ByVal username As String, ByVal password As String) As IRestResponse(Of TokenResponse)
    Function GetAuthUsers(ByVal Optional page As Integer = 1, ByVal Optional pageCount As Integer = 10) As IRestResponse(Of AuthUsersInCompany)
    Function AddAuthUser(ByVal addAuthUserArgument As AddAuthUserArgument) As IRestResponse(Of CreatedAuthUser)
    Function GenereteNewSecret(ByVal userId As Guid) As IRestResponse(Of CreatedAuthUser)
    Function GetLoggedCompany() As IRestResponse(Of LoggedCompany)
    Function AddCompany(ByVal addCompanyArgument As AddCompanyArgument) As IRestResponse(Of IdentityResult)
    Function GetHotpForAuthUser(ByVal userId As Guid) As IRestResponse(Of OneTimePassword)
    Function ValidateHotpForAuthUser(ByVal userId As Guid, ByVal hotp As String) As IRestResponse(Of OtpValidationResult)
    Function GetTotpForAuthUser(ByVal userId As Guid) As IRestResponse(Of OneTimePassword)
    Function ValidateTotpForAuthUser(ByVal userId As Guid, ByVal totp As String) As IRestResponse(Of OtpValidationResult)
end interface