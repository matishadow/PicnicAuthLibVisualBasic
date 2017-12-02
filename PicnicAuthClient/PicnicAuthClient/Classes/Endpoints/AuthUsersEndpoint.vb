Imports RestSharp

Friend Class AuthUsersEndpoint
    Inherits AuthorizedEndpoint

    Protected Friend Sub New(restClient As IRestClient, apiKey As String)
        MyBase.New(restClient, apiKey)
    End Sub

    Public Function GetAuthUsersForLoggedCompany(ByVal Optional page As Integer = 1, ByVal Optional pageCount As Integer = 10) As IRestResponse(Of AuthUsersInCompany)
        Dim request = New RestRequest("Companies/Me/AuthUsers", Method.[GET])
        AddAuthorizationHeader(request, ApiKey)
        request.AddQueryParameter(NameOf(page), page.ToString())
        request.AddQueryParameter(NameOf(pageCount), pageCount.ToString())
        Return RestClient.Execute(Of AuthUsersInCompany)(request)
    End Function

    Public Function AddAuthUser(ByVal addAuthUserArgument As AddAuthUserArgument) As IRestResponse(Of CreatedAuthUser)
        Dim request = New RestRequest("AuthUsers", Method.POST)
        AddAuthorizationHeader(request, ApiKey)
        request.AddJsonBody(addAuthUserArgument)
        Return RestClient.Execute(Of CreatedAuthUser)(request)
    End Function
End Class