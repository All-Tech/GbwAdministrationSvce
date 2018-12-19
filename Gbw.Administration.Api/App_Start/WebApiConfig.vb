
Imports System.Web.Http
Imports Gbw.Administration.Api.Helpers
Imports Unity

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services
        'config.SuppressDefaultHostAuthentication()
        'config.Filters.Add(New HostAuthenticationFilter(OAuthDefaults.AuthenticationType))

        config.Formatters.Add(New BrowserJsonFormatter())
        config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore

        'Configuration unity
        Dim container = New UnityContainer()
        UnityConfig.RegisterTypes(container)
        config.DependencyResolver = New UnityWebApiActivator(container)
        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
    End Sub
End Module
