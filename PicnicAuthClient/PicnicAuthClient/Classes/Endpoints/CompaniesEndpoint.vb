Imports RestSharp

Friend Class CompaniesEndpoint
    Inherits AuthorizedEndpoint

    Protected Friend Sub New(restClient As IRestClient, apiKey As String)
        MyBase.New(restClient, apiKey)
    End Sub

    Public Function GetLoggedCompany() As IRestResponse(Of LoggedCompany)
        Dim request = New RestRequest("Companies/Me", Method.[GET])
        AddAuthorizationHeader(request, ApiKey)
        Return RestClient.Execute(Of LoggedCompany)(request)
    End Function

    Public Function AddCompany(ByVal addCompanyArgument As AddCompanyArgument) As IRestResponse(Of IdentityResult)
        Dim request = New RestRequest("Companies", Method.POST)
        request.AddJsonBody(addCompanyArgument)
        Return RestClient.Execute(Of IdentityResult)(request)
    End Function
End Class