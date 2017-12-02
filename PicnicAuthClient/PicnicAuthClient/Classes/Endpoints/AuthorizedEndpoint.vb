Imports RestSharp

Public MustInherit Class AuthorizedEndpoint
    Inherits RestEndpoint

    Private Const AuthenticationHeaderName As String = "Authorization"
    Private Const AuthenticationHeaderValueFormat As String = "Bearer {0}"

    Protected Sub AddAuthorizationHeader(ByVal request As IRestRequest, ByVal apiKey As String)
        request?.AddHeader(AuthenticationHeaderName, String.Format(AuthenticationHeaderValueFormat, apiKey))
    End Sub

    Protected Sub New(ByVal restClient As IRestClient, ByVal apiKey As String)
        MyBase.New(restClient, apiKey)
    End Sub
End Class