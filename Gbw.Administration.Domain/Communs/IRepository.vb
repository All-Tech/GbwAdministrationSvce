Namespace Communs
    ''' <summary>
    ''' Interface générique de persistence
    ''' </summary>
    Public Interface IRepository(Of TKey)
        Inherits IDisposable
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Id">id site operation</param>
        ''' <returns>Collection des objets</returns>
        Function ObtenireListe(ByVal Id As Integer) As List(Of TKey)
        '  Function ObtenireListe(ByVal Id As Integer) As List(Of TKey)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Id"></param>
        ''' <returns></returns>
        Function ObtenireParId(ByVal Id As Integer) As TKey
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="entity"></param>
        ''' <returns></returns>
        Function Creation(ByRef entity As TKey) As Boolean
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="entity"></param>
        ''' <returns></returns>
        Function Misejour(ByVal entity As TKey) As Boolean
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Id"></param>
        ''' <returns></returns>
        Function Suppression(ByVal Id As Integer) As Boolean
    End Interface
End Namespace

