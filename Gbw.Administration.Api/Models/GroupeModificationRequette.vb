Imports System.ComponentModel.DataAnnotations
Namespace Models


    Public Class GroupeModificationRequette
        <Required(ErrorMessage:="un champ ID est requis")>
        <Range(1, 100, ErrorMessage:="le champ ID  est positif")>
        Public Property GroupeID As Integer
        Public Property Code As String
        <Required(ErrorMessage:="un champ libelle est requis")>
        Public Property Libelle As String

        Public Property Adresse As String
        ' <CheckvalidateYear()>
        Public Property Ville As String
    End Class
End Namespace