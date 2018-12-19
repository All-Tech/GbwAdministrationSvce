Imports Gbw.Administration.Api.Helpers
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Administration.Infrastructure
Imports Gbw.Administration.Service.services
Imports Unity

Public NotInheritable Class UnityConfig
    Public Shared Sub RegisterTypes(ByVal container As IUnityContainer)
        'configuration de la couche DAL
        container.RegisterType(Of IGroupeRepository, GroupeRepository)()

        container.RegisterType(Of IGroupeService, GroupeService)()

        container.RegisterType(Of IMappeurConfigure, MappeurConfigure)()
        container.RegisterType(Of IGroupeMappeurFrom, GroupeMappeurFrom)()
        Dim val = New MappeurConfigure()
    End Sub
End Class
