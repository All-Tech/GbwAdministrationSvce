Imports System.Text
Imports Gwb.Common.Models
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class CategorieEssenceTest

    Private repository As CategorieEssenceRepository

    Public Sub New()
        repository = New CategorieEssenceRepository()
    End Sub
    <TestMethod()> Public Sub CreationCategorieEssence()
        'Dim cat As New CategorieEssence() With {.CategorieEssenceID = 1, .Libelle = "Bois de Travail", .BoisRougeBoisLong = "BT"}
        'Dim rep As Boolean
        'Try
        '    rep = repository.Creation(cat)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub

    <TestMethod()> Public Sub ModificationClasseEssence()
        'Dim cat As New CategorieEssence() With {.CategorieEssenceID = 4, .Libelle = "Bois de Chauffage", .BoisRougeBoisLong = "BC"}
        'Dim rep As Boolean
        'Try
        '    rep = repository.Misejour(cat)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub

    <TestMethod()> Public Sub SuppressionClasseEssence()
        'Try
        '    Dim result = repository.Suppression(4)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub


    <TestMethod()> Public Sub RetournerParIdClasseEssence()
        'Dim result
        'Try
        '    result = repository.ObtenireParId(1)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub
End Class