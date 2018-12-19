Imports Gbw.Administration.Domain.Contracts
Imports Gwb.Common.Models.DTO

Namespace services
    Public Class GroupeService
        Implements IGroupeService

        Private ReadOnly groupeRepository As IGroupeRepository
#Region "Constructeurs"
        Public Sub New(groupeRepository As IGroupeRepository)

            If groupeRepository Is Nothing Then
                Throw New ArgumentException("groupeRepository")
            End If

            Me.groupeRepository = groupeRepository
        End Sub
#End Region


#Region "Methodes"
        Public Function ObtenireListe(IdSiteOperation As Integer) As List(Of Groupe) Implements IService(Of Groupe).ObtenireListe
            Return groupeRepository.ObtenireListe(IdSiteOperation)
        End Function

        Public Function ObtenireParId(Id As Integer) As Groupe Implements IService(Of Groupe).ObtenireParId
            Return groupeRepository.ObtenireParId(Id)
        End Function

        Public Function Creation(ByRef entity As Groupe) As Boolean Implements IService(Of Groupe).Creation
            Return groupeRepository.Creation(entity)
        End Function

        Public Function Misejour(entity As Groupe) As Boolean Implements IService(Of Groupe).Misejour
            Return groupeRepository.Misejour(entity)
        End Function

        Public Function Suppression(Id As Integer) As Boolean Implements IService(Of Groupe).Suppression
            Return groupeRepository.Suppression(Id)
        End Function
#End Region

    End Class
End Namespace