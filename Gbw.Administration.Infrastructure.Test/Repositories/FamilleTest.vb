Imports System.Text
Imports Gbw.Administration.Domain.Contracts
Imports Gwb.Common.Models
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class FamilleTest

    Private repository As IFamilleRepository
    Public Sub New()
        repository = New FamilleRepository()
    End Sub
    <TestMethod()> Public Sub CreationFamille()
        'Dim famille As New Famille With {.Code = "Grumes", .FamilleID = 1, .Libelle = "Grumes"}
        'Try
        '    repository.Creation(famille)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub


    <TestMethod()> Public Sub ModificationFamille()
        'Dim famille As New Famille With {.Code = "DL", .FamilleID = 1, .Libelle = "Débité local"}
        'Try
        '    repository.Misejour(famille)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub


    <TestMethod()> Public Sub SuppressionFamille()
        'Try
        '    repository.Suppression(1)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub


    <TestMethod()> Public Sub ObtenirListeByIDFamille()
        'Dim fam As New Famille()
        'Try
        '    fam = repository.ObtenireParId(2)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub


End Class