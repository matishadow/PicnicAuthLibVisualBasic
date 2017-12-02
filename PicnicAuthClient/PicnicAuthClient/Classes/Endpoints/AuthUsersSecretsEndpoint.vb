Imports RestSharp

Friend Class AuthUsersSecretsEndpoint
    Inherits AuthorizedEndpoint

    Protected Friend Sub New(restClient As IRestClient, apiKey As String)
        MyBase.New(restClient, apiKey)
    End Sub

    Public Function GenereteNewSecret(ByVal userId As Guid) As IRestResponse(Of CreatedAuthUser)
        Dim request = New RestRequest($"AuthUsers/{userId}/secret", Method.PATCH)
        AddAuthorizationHeader(request, ApiKey)
        Return RestClient.Execute(Of CreatedAuthUser)(request)
    End Function
End Class