Imports System.Net
Imports System.Net.Http

Namespace Helpers
    Public NotInheritable Class ErrorMessageHelper(Of T)
        Public Shared Function RetourneMessageErreur(ByVal statusCode As HttpStatusCode) As HttpResponseMessage
            Dim response As HttpResponseMessage = New HttpResponseMessage(statusCode)
            'Dim response As HttpResponseMessage = New HttpResponseMessage(statusCode) With {
            '       .Content = New ObjectContent(Of Object)(New With {Key .message = New GroupeReponse() With {
            '                                               .Message = New Message With {.CodeMessage = "error124578", .LibelleMessageEn = ex.Message},
            '                                               .Groupes = Nothing
            '                                               },
            '       .StatusCode = System.Net.HttpStatusCode.Unauthorized
            '        }, Configuration.Formatters.JsonFormatter)}
            Return response
        End Function
    End Class
End Namespace

