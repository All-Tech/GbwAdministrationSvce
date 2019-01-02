Imports System.Text
Imports Gbw.Administration.Domain.Contracts
Imports Gwb.Common.Models
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class ClasseEssenceTest

    Private repository As IClasseEssenceRepository
    Public Sub New()
        repository = New ClasseEssenceRepository()
    End Sub
    <TestMethod()> Public Sub CreationClasseEssence()
        'Dim classe As New ClasseEssence With {.ClasseEssenceID = 1, .Libelle = "CLASSE IV"}
        'Try
        '    For i = 1 To 10
        '        repository.Creation(classe)
        '    Next

        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub

    <TestMethod()> Public Sub MiseAjourTest()
        'Dim classe As New ClasseEssence With {.ClasseEssenceID = 6, .Libelle = "CLASSE II"}
        'Try
        '    For i = 7 To 17
        '        classe.ClasseEssenceID = i
        '        classe.Libelle = "CLASSE " & i
        '        repository.Misejour(classe)
        '    Next
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub

    <TestMethod()> Public Sub SuppressionTest()
        'Dim classe As New ClasseEssence With {.ClasseEssenceID = 6, .Libelle = "CLASSE II"}
        'Try
        '    repository.Suppression(17)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub
End Class