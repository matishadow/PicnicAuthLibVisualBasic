Imports RestSharp

Public Class RestEndpoint
    Protected ReadOnly RestClient As IRestClient
    Protected ReadOnly ApiKey As String

    Protected Sub New(ByVal restClient As IRestClient, ByVal apiKey As String)
        Me.RestClient = restClient
        Me.ApiKey = apiKey
    End Sub
End Class