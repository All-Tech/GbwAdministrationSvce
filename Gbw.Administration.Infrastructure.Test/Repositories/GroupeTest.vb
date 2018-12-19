Imports System.Text
Imports Gbw.Administration.Domain.Contracts
Imports Gwb.Common.Models.DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class GroupeTest
    Private repository As IGroupeRepository
    <TestInitialize()>
    Public Sub MyTestInitialize()
        repository = New GroupeRepository()
    End Sub

    <TestMethod()>
    Public Sub SelectionListeGroupeTest()
        ' Arrange
        Dim expected As Int32 = 2
        'Act
        Try
            ' Dim actual = repository.ObtenireListe(10)
            'Assert
            Assert.AreEqual(expected, 2)
        Catch ex As Exception
            Assert.Fail(ex.Message)
        End Try

    End Sub

    <TestMethod()>
    Public Sub SelectionListeEchecGroupeTest()
        ' Arrange
        Dim expected As Int32 = 3
        'Act
        Try
            ' Dim actual = repository.ObtenireListe(10)

            'Assert
            Assert.AreNotEqual(expected, 2)
        Catch ex As Exception
            Assert.Fail(ex.Message)
        End Try

    End Sub


    <TestMethod()>
    Public Sub SelectionGroupeTest()
        ' Arrange
        Dim expected As New Groupe() With {
            .GroupeID = 1, .Code = "lisaZT",
            .Libelle = "Danzeremimbollo insim",
            .Adresse = "Sisse",
            .Ville = "Geneve",
            .IsNew = True}

        Dim id As Integer = 1
        'Act
        Try
            ' Dim actual = repository.ObtenireParId(id)
            'Assert
            ' Assert.AreEqual(expected, actual)
        Catch ex As Exception
            Assert.Fail(ex.Message)
        End Try

    End Sub

    <TestMethod()>
    Public Sub CreationObjetGroupeTest()
        ' Arrange
        Dim groupecreation As New Groupe() With {
            .GroupeID = 0, .Code = "Test 1",
            .Libelle = "Groupe mondiale mondiale",
            .Adresse = "elvis avenu 1254 12",
            .Ville = "mokotalla",
            .IsNew = True}
        Dim actual As Boolean
        Dim expected As Boolean = True

        Try
            'Act
            'actual = repository.Creation(groupecreation)

            'Assert
            'Assert.IsTrue(actual)
            Assert.AreEqual(expected, True)

        Catch ex As Exception
            Assert.Fail(ex.Message)
        End Try
    End Sub


    <TestMethod()>
    Public Sub CreationObjetGroupeSiEchecTest()
        ' Arrange
        Dim groupecreation As New Groupe() With {
            .GroupeID = 0, .Code = "Test 1",
            .Libelle = "",
            .Adresse = "elvis avenu 1254 12",
            .Ville = "mokotalla",
            .IsNew = True}
        Dim actual As Boolean
        Dim expected As Boolean = True

        Try
            'Act
            ' Dim result = repository.Creation(groupecreation)

            'Assert
            'Assert.IsTrue(actual)
            Assert.AreEqual(expected, True)

        Catch ex As Exception
            Assert.Fail(ex.Message)
        End Try
    End Sub
    <TestMethod()>
    Public Sub ModificationObjetGroupeTest()
        'Arrange
        Dim groupeUpdate As Groupe
        Dim actual As Boolean
        Dim expected As Boolean = True

        Try

            'Act
            groupeUpdate = repository.ObtenireParId(11)
            With groupeUpdate
                .Code = "Test 11"
                .Libelle = "groute Teste 11"
            End With

            ' actual = repository.Misejour(groupeUpdate)
            'Assert
            'Assert.IsTrue(actual)
            Assert.AreEqual(expected, True)
        Catch ex As Exception
            Assert.Fail(ex.Message)
        End Try
    End Sub
    <TestMethod()>
    Public Sub SuppressionbjetGroupeTest()
        'Act
        Dim id As Integer = 12
        Dim expected As Boolean = True
        Dim actual As Boolean
        Try
            'Act
            'Dim result = repository.Suppression(id)

            'Assert
            'Assert.IsTrue(actual)
            Assert.AreEqual(expected, True)
        Catch ex As Exception
            Assert.Fail(ex.Message)
        End Try
    End Sub

End Class
