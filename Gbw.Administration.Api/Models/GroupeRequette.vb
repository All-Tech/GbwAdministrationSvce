Imports System.ComponentModel.DataAnnotations

Namespace Models
    Public Class GroupeRequette

        Public Property GroupeID As Integer
        Public Property Code As String
        <Required(ErrorMessage:="un champ libelle est requis")>
        Public Property Libelle As String

        Public Property Adresse As String
        ' <CheckvalidateYear()>
        Public Property Ville As String

    End Class
End Namespace

