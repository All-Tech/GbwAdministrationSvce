Imports System.Text
Imports Gbw.Administration.Domain.Contracts
Imports Gwb.Common.Models
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class DensiteBoisTest
    Private repository As IDensiteBoisRepository

    Public Sub New()
        repository = New DensiteBoisRepository
    End Sub
    <TestMethod()> Public Sub CreationTest()
        'Dim densite As New DensiteBois With {.DensiteBoisID = 1, .EssenceID = 1, .ProduitID = 4, .Libelle = "1.33"}
        'Try
        '    repository.Creation(densite)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub

    <TestMethod()> Public Sub MiseAJourTest()
        'Dim densite As New DensiteBois With {.DensiteBoisID = 3, .EssenceID = 1, .ProduitID = 4, .Libelle = "1.03"}
        'Try
        '    repository.Misejour(densite)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub


    <TestMethod()> Public Sub SuppressionTest()
        'Dim densite As New DensiteBois With {.DensiteBoisID = 6, .EssenceID = 1, .ProduitID = 4, .Libelle = "1.03"}
        'Try
        '    repository.Suppression(6)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub
End Class