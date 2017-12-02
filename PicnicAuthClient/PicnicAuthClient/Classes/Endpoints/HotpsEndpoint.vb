Imports RestSharp

Friend Class HotpsEndpoint
    Inherits AuthorizedEndpoint

    Protected Sub New(restClient As IRestClient, apiKey As String)
        MyBase.New(restClient, apiKey)
    End Sub

    Public Function GetHotpForAuthUser(ByVal userId As Guid) As IRestResponse(Of OneTimePassword)
        Dim request = New RestRequest($"AuthUsers/{userId}/hotp", Method.[GET])
        AddAuthorizationHeader(request, ApiKey)
        Return RestClient.Execute(Of OneTimePassword)(request)
    End Function

    Public Function ValidateHotpForAuthUser(ByVal userId As Guid, ByVal hotp As String) As IRestResponse(Of OtpValidationResult)
        Dim request = New RestRequest($"AuthUsers/{userId}/hotp/{hotp}", Method.[GET])
        AddAuthorizationHeader(request, ApiKey)
        Return RestClient.Execute(Of OtpValidationResult)(request)
    End Function
End Class