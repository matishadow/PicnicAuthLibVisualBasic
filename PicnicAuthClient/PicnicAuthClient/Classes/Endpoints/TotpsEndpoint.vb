Imports RestSharp

Friend Class TotpsEndpoint
    Inherits AuthorizedEndpoint

    Protected Friend Sub New(restClient As IRestClient, apiKey As String)
        MyBase.New(restClient, apiKey)
    End Sub

    Public Function GetTotpForAuthUser(ByVal userId As Guid) As IRestResponse(Of OneTimePassword)
        Dim request = New RestRequest($"AuthUsers/{userId}/totp", Method.[GET])
        AddAuthorizationHeader(request, ApiKey)
        Return RestClient.Execute(Of OneTimePassword)(request)
    End Function

    Public Function ValidateTotpForAuthUser(ByVal userId As Guid, ByVal totp As String) As IRestResponse(Of OtpValidationResult)
        Dim request = New RestRequest($"AuthUsers/{userId}/totp/{totp}", Method.[GET])
        AddAuthorizationHeader(request, ApiKey)
        Return RestClient.Execute(Of OtpValidationResult)(request)
    End Function
End Class