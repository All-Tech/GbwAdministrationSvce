﻿Imports System.Net.Http.Formatting
Imports System.Net.Http.Headers
Imports System.Xml

Namespace Helpers
    Public Class BrowserJsonFormatter
        Inherits JsonMediaTypeFormatter

        Public Sub New()
            Me.SupportedMediaTypes.Add(New MediaTypeHeaderValue("text/html"))
            Me.SerializerSettings.Formatting = Formatting.Indented
        End Sub
        Public Overrides Sub SetDefaultContentHeaders(type As Type, headers As HttpContentHeaders, mediaType As MediaTypeHeaderValue)
            MyBase.SetDefaultContentHeaders(type, headers, mediaType)
            headers.ContentType = New MediaTypeHeaderValue("application/json")
        End Sub
    End Class
End Namespace

