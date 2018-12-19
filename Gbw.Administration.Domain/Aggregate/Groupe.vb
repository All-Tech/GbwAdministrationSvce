Public Class Groupe

#Region "------ Proprietes ------"
    Public Property ID As Integer
    Public Property Code As String
    Public Property Libelle As String
    Public Property Adresse As String
    Public Property Ville As String
#End Region


#Region "------ Constructeurs ------"

    Public Sub New(ByVal groupe As Groupe)
        Me.Code = groupe.Code
        Me.Libelle = groupe.Libelle
        Me.Adresse = groupe.Adresse
        Me.Ville = groupe.Ville
    End Sub
    Public Sub New(ByVal _code As String, _libelle As String, _adresse As String, ByVal _ville As String)
        Me.Code = _code
        Me.Libelle = _libelle
        Me.Adresse = _adresse
        Me.Ville = _ville
    End Sub
    Public Sub New()
        Me.Code = Nothing
        Me.Libelle = Nothing
        Me.Adresse = Nothing
        Me.Ville = Nothing

    End Sub
#End Region


#Region "------ Behaviors ------"

    Public Function SelectionTout(ByVal IdSiteOperation As Integer) As List(Of Groupe)
        Dim groupes As List(Of Groupe) = Nothing
        'To Do
        Return groupes
    End Function


    Public Function SelectionParId(ByVal IdSiteOperation As Integer) As Groupe
        Dim groupe As Groupe = Nothing
        'To Do
        Return groupe
    End Function

    Public Function Creation(ByVal entite As Groupe) As Boolean
        Dim results As Boolean = False
        'To Do
        Return results
    End Function
    Public Function Modification(ByVal entite As Groupe) As Boolean
        Dim results As Boolean = False
        'To Do
        Return results
    End Function
    Public Function Suppression(ByVal Id As Integer) As Boolean
        Dim results As Boolean = False
        'To Do
        Return results
    End Function
#End Region

End Class
