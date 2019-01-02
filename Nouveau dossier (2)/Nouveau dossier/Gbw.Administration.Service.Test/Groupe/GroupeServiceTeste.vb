
Imports AutoFixture
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Administration.Service.services
Imports Gwb.Common.Models
Imports Moq
Imports Xunit

Public Class GroupeServiceTeste
    Private fixture As IFixture
    Private MockGroupeRepository As Mock(Of IGroupeRepository)
    Private ReadOnly service As GroupeService

    Public Sub New()
        fixture = New Fixture().Customize(New CompositeCustomization(New AutoMoq.AutoMoqCustomization))
        MockGroupeRepository = New Mock(Of IGroupeRepository)
        service = New GroupeService(MockGroupeRepository.Object)
    End Sub

    <Fact()>
    Public Sub ServiveObteniteAll()
        'Act
        ' Dim MockGroupe = fixture.Freeze(Of Mock(Of IGroupeService))
        Dim idSiteoperation As Integer = 10

        'Arrange
        MockGroupeRepository.Setup(Function(sc) sc.ObtenireListe(idSiteoperation)).Returns(GetGroupes())
        ''Act
        Dim actual = service.ObtenireListe(idSiteoperation)

        ''Assert
        Assert.Equal(actual.Count, GetGroupes.Count)
    End Sub
    Public ReadOnly Property GetGroupes() As List(Of Groupe)
        Get
            Dim liste As New List(Of Groupe)
            liste.Add(New Groupe With {.GroupeID = 1, .Code = "code 1", .Libelle = " groupe teste 1", .Adresse = "", .Ville = ""})
            liste.Add(New Groupe With {.GroupeID = 2, .Code = "code 2", .Libelle = " groupe teste 2", .Adresse = "", .Ville = ""})
            Return liste
        End Get

    End Property
End Class