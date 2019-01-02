Imports System.Text
Imports Gwb.Common.Models
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()
        Try
            Dim Repository As Gbw.Administration.Domain.Contracts.IFamilleRepository
            Repository = New FamilleRepository()
            Dim famille As New Famille With {.FamilleID = 1, .Code = "Grume", .IsNew = True, .Libelle = "Les Grumes"}
            Repository.Creation(famille)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

End Class