Public Class CreatedAuthUser
    Public Property ExternalId As String
    Public Property UserName As String
    Public Property Email As String
    Public Property HotpQrCodeUri As Uri
    Public Property TotpQrCodeUri As Uri
    Public Property SecretInBase32 As String
    Public Property Id As Guid
End Class