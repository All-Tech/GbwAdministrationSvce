Imports Gbw.Administration.Api.Models

Public Interface IGroupeMappeurFrom
    Function MappageGroupefrom(ByVal entite As Gwb.Common.Models.DTO.Groupe) As GroupeViemodel
    Function MappageGroupefrom(ByVal entite As List(Of Gwb.Common.Models.DTO.Groupe)) As List(Of GroupeViemodel)
    Function MappageGroupeTo(ByVal entite As GroupeRequette) As Gwb.Common.Models.DTO.Groupe
    Function MappageGroupeModificationTo(ByVal entite As GroupeModificationRequette) As Gwb.Common.Models.DTO.Groupe
End Interface
