Imports System.Text
Imports Gbw.Administration.Domain.Contracts
Imports Gwb.Common.Models
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class SousFamilleTest

    Private repository As ISousFamilleRepository

    Public Sub New()
        repository = New SousFamilleRepository()
    End Sub

    <TestMethod()> Public Sub CreationTest()
        'Dim soufamille As New SousFamille With {.SousFamilleID = 1, .Libelle = "Contre Plaqué", .FamilleID = 2, .Code = "PL"}
        'Try
        '    repository.Creation(soufamille)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub

    <TestMethod()> Public Sub MiseAjourTest()
        'Dim soufamille As New SousFamille With {.SousFamilleID = 5, .Code = "GR", .FamilleID = 2, .Libelle = "Grume"}
        'Try
        '    repository.Misejour(soufamille)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub

    <TestMethod()> Public Sub SuppressionTest()
        'Dim soufamille As New SousFamille With {.SousFamilleID = 6, .Code = "GR", .FamilleID = 2, .Libelle = "Grume"}
        'Try
        '    repository.Suppression(5)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub
End Class