Imports RestSharp

Friend Class TokensEndpoint

    Private ReadOnly restClient As IRestClient

    Private Const grant_type As String = "password"

    Public Sub New(ByVal restClient As IRestClient)
        Me.restClient = restClient
    End Sub

    Public Function GetApiKey(ByVal username As String, ByVal password As String) As IRestResponse(Of TokenResponse)
        Dim request = New RestRequest("tokens", Method.POST)
        request.AddParameter(NameOf(grant_type), grant_type)
        request.AddParameter(NameOf(username), username)
        request.AddParameter(NameOf(password), password)
        Return restClient.Execute(Of TokenResponse)(request)
    End Function
End Class