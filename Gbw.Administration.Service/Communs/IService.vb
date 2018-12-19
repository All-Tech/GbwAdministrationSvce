Namespace services
    Public Interface IService(Of TKey)
        Function ObtenireListe(ByVal IdSiteOperation As Integer) As List(Of TKey)
        Function ObtenireParId(ByVal Id As Integer) As TKey
        Function Creation(ByRef entity As TKey) As Boolean
        Function Misejour(ByVal entity As TKey) As Boolean
        Function Suppression(ByVal Id As Integer) As Boolean
    End Interface
End Namespace

