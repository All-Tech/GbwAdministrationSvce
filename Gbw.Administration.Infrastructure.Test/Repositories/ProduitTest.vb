Imports System.Text
Imports Gbw.Administration.Domain
Imports Gwb.Common.Models
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class ProduitTest

    Private repository As IProduitRepository

    Public Sub New()
        repository = New ProduitRepository()
    End Sub
    <TestMethod()> Public Sub CreationTest()
        'Dim prod As New Produit With {.CodeActivite = "AB", .CodeProduit = "AA", .CodePlaque = "BP", .CodeSig = "C4", .Libelle = "Grume", .PostAff = "PF", .ProduitID = 1, .SDKDF = "SDKDF", .SocieteID = 2, .SousFamilleID = 3, .TypeGroupe = "TG", .TypeQualite = "TQ", .Unites = "Unity"}
        'Try
        '    repository.Creation(prod)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub

    <TestMethod()> Public Sub ModificationTest()
        'Dim prod As New Produit With {.CodeActivite = "AB", .CodeProduit = "BY", .CodePlaque = "BP", .CodeSig = "C4", .Libelle = "Grume", .PostAff = "PF", .ProduitID = 4, .SDKDF = "SDKDF", .SocieteID = 2, .SousFamilleID = 3, .TypeGroupe = "TG", .TypeQualite = "TQ", .Unites = "Unity"}
        'Try
        '    repository.Misejour(prod)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub

    <TestMethod()> Public Sub SuppressionTest()
        'Dim prod As New Produit With {.CodeActivite = "AB", .CodeProduit = "BY", .CodePlaque = "BP", .CodeSig = "C4", .Libelle = "Grume", .PostAff = "PF", .ProduitID = 4, .SDKDF = "SDKDF", .SocieteID = 2, .SousFamilleID = 3, .TypeGroupe = "TG", .TypeQualite = "TQ", .Unites = "Unity"}
        'Try
        '    repository.Suppression(5)
        'Catch ex As Exception
        '    Assert.Fail(ex.Message)
        'End Try
    End Sub
End Class