Imports Newtonsoft.Json

Namespace Models
    Public Class GroupeViemodel
        <JsonProperty("id")>
        Public Property GroupeID As Integer
        <JsonProperty("code")>
        Public Property Code As String
        <JsonProperty("libelle")>
        Public Property Libelle As String
        <JsonProperty("adresse")>
        Public Property Adresse As String
        <JsonProperty("ville")>
        Public Property Ville As String
    End Class
End Namespace

