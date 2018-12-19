Imports AutoMapper
Imports Gbw.Administration.Api.Models


Namespace Helpers
    Public Class MappeurConfigure
        Implements IMappeurConfigure

        Public Sub New()
            Configurer()
        End Sub

        Private Sub Configurer()
            Mapper.Initialize(Function(ma)
                                  ma.CreateMap(Of Gwb.Common.Models.DTO.Groupe, GroupeViemodel)()
                                  ma.CreateMap(Of GroupeRequette, Gwb.Common.Models.DTO.Groupe)()
                                  ma.CreateMap(Of GroupeModificationRequette, Gwb.Common.Models.DTO.Groupe)()
                                  Return True
                              End Function)
        End Sub
    End Class

End Namespace
