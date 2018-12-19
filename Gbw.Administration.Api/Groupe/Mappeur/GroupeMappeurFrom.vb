Imports AutoMapper
Imports Gbw.Administration.Api
Imports Gbw.Administration.Api.Models
Imports Gwb.Common.Models.DTO

Public Class GroupeMappeurFrom
    Implements IGroupeMappeurFrom

    Public Function MappageGroupefrom(entite As Gwb.Common.Models.DTO.Groupe) As GroupeViemodel Implements IGroupeMappeurFrom.MappageGroupefrom
        Dim groupe = Mapper.Map(Of GroupeViemodel)(entite)

        Return groupe
    End Function

    Public Function MappageGroupefrom(entite As List(Of Gwb.Common.Models.DTO.Groupe)) As List(Of GroupeViemodel) Implements IGroupeMappeurFrom.MappageGroupefrom
        Dim groupes = Mapper.Map(Of List(Of GroupeViemodel))(entite)
        Return groupes
    End Function

    Public Function MappageGroupeTo(entite As GroupeRequette) As Gwb.Common.Models.DTO.Groupe Implements IGroupeMappeurFrom.MappageGroupeTo
        Dim groupe = Mapper.Map(Of Gwb.Common.Models.DTO.Groupe)(entite)
        Return groupe
    End Function

    Public Function MappageGroupeModificationTo(entite As GroupeModificationRequette) As Gwb.Common.Models.DTO.Groupe Implements IGroupeMappeurFrom.MappageGroupeModificationTo
        Dim groupe = Mapper.Map(Of Gwb.Common.Models.DTO.Groupe)(entite)
        Return groupe
    End Function
End Class
