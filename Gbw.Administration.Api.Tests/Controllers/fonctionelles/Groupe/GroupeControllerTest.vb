
Imports Xunit
Imports AutoFixture
Imports Gbw.Administration.Api.Groupe
Imports Moq
Imports Gbw.Administration.Service.services
Imports Gbw.Administration.Api.Models
Imports Gwb.Common.Models.DTO
Imports System.Web.Http.Results

Public Class GroupeControllerTest
    Private fixture As IFixture
    Public Sub New()
        fixture = New Fixture()
    End Sub

    <Fact()>
    Public Sub ObtenireListegroupeTest()
        'Arrange
        'Dim MockGroupeService As New Mock(Of IGroupeService)
        Dim idSiteoperation = fixture.Create(Of Integer)()

        Dim MockGroupe = fixture.Freeze(Of Mock(Of IGroupeService))
        Dim MockMappeur = fixture.Freeze(Of Mock(Of IGroupeMappeurFrom))

        MockGroupe.Setup(Function(sv) sv.ObtenireListe(1)).Returns(GetGroupes())
        MockMappeur.Setup(Function(mp) mp.MappageGroupefrom(GetGroupes()))

        'Act
        ' var controller = fixture.Create<ReclamationController>();
        ' Dim ncontroller = fixture.Create(Of GroupeController)
        Dim controller As New GroupeController(MockGroupe.Object, MockMappeur.Object)
        Dim actual As OkNegotiatedContentResult(Of GroupeReponse) = controller.GetValues(1)

        'result.Content.
        'OkObjectResult
        'Assert
        'Assert.IsNotNull(result)
        'Assert.AreEqual(2, result.Count())
        'Assert.AreEqual("value1", result.ElementAt(0))
        'Assert.AreEqual("value2", result.ElementAt(1))
        ' Dim [error] = _modelState("FirstName").Errors(0)
        'Assert.AreEqual("First name is required.", [error].ErrorMessage)
    End Sub

    Public ReadOnly Property GetGroupes() As List(Of Gwb.Common.Models.DTO.Groupe)
        Get
            Dim liste As New List(Of Gwb.Common.Models.DTO.Groupe)
            liste.Add(New Gwb.Common.Models.DTO.Groupe With {.GroupeID = 1, .Code = "code 1", .Libelle = " groupe teste 1", .Adresse = "", .Ville = ""})
            liste.Add(New Gwb.Common.Models.DTO.Groupe With {.GroupeID = 2, .Code = "code 2", .Libelle = " groupe teste 2", .Adresse = "", .Ville = ""})
            Return liste
        End Get

    End Property
    Public ReadOnly Property GetGroupesfrom() As List(Of GroupeViemodel)
        Get
            Dim liste As New List(Of GroupeViemodel)
            liste.Add(New GroupeViemodel With {.GroupeID = 1, .Code = "code 1", .Libelle = " groupe teste 1", .Adresse = "", .Ville = ""})
            liste.Add(New GroupeViemodel With {.GroupeID = 2, .Code = "code 2", .Libelle = " groupe teste 2", .Adresse = "", .Ville = ""})
            Return liste
        End Get

    End Property
End Class
