Imports System.Configuration
Imports System.Data.Common
Imports Gbw.Administration.Domain.Communs
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Common.DAL.Containeur
Imports Gbw.Common.DAL.Factories
Imports Gwb.Common.Models
Imports System.Data.SqlClient

Public Class CategorieEssenceRepository
	 Implements ICategorieEssenceRepository
	 Private dale As IDataContaineur
     #Region "CONSTANTS"
     Private Const PS_SELECT_ALL As String ="sp_CategorieEssenceSelect"
     Private Const PS_SELECT_BYID As String ="sp_CategorieEssenceSelectById"
     Private Const PS_INSERT As String ="sp_CategorieEssenceinsert"
     Private Const PS_UPDATE As String ="sp_CategorieEssenceUpdate"
     Private Const PS_DELETE As String ="sp_CategorieEssenceDelete"
#End Region




#Region "Constructeurs"
    Public Sub New()
	          dale = New DataContaineur()
       End Sub


     #End Region
     #Region "Methods"
      Public  Function ObtenireListe(Id As Integer) As List(Of CategorieEssence) Implements IRepository(Of CategorieEssence).ObtenireListe
         Dim categorieessences As New List(Of CategorieEssence)
         Dim command As DbCommand =CommandeFactory.CreateCommand(PS_SELECT_ALL,CommandType.StoredProcedure)
	categorieessences= dale.ExecuteList(Of CategorieEssence)(command)
         Return categorieessences
       End Function

      Public  Function ObtenireParId(Id As Integer) As  CategorieEssence  Implements IRepository(Of CategorieEssence).ObtenireParId
         Dim categorieessence  As  CategorieEssence= Nothing
         Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_BYID, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InCategorieEssenceID", Id))
        categorieessence = dale.ExecuteSingle(Of CategorieEssence)(command)
        Return categorieessence
      End Function

    Public Function Creation(ByRef categorieessence As CategorieEssence) As Boolean Implements IRepository(Of CategorieEssence).Creation
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_INSERT, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateOutputParameter("@pn_InCategorieEssenceID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", categorieessence.Libelle))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InBoisRougeBoisLong", categorieessence.BoisRougeBoisLong))
        Return dale.ExecuteNonQuery(categorieessence.CategorieEssenceID, command, "@pn_InCategorieEssenceID")
    End Function

    Public  Function Misejour(ByVal categorieessence As CategorieEssence) As Boolean Implements IRepository(Of CategorieEssence).Misejour
      Dim command As DbCommand = CommandeFactory.CreateCommand(PS_UPDATE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InCategorieEssenceID", categorieessence.CategorieEssenceID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", categorieessence.Libelle))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InBoisRougeBoisLong", categorieessence.BoisRougeBoisLong))
        Return dale.ExecuteNonQuery(command)
      End Function
      Public  Function Suppression(ByVal ID As Integer )  As Boolean Implements IRepository(Of CategorieEssence).Suppression
      Dim command As DbCommand = CommandeFactory.CreateCommand(PS_DELETE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InCategorieEssenceID", ID))
        Return dale.ExecuteNonQuery(command)
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Pour détecter les appels redondants

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: supprimer l'état managé (objets managés).
            End If

            ' TODO: libérer les ressources non managées (objets non managés) et remplacer Finalize() ci-dessous.
            ' TODO: définir les champs de grande taille avec la valeur Null.
        End If
        disposedValue = True
    End Sub

    ' TODO: remplacer Finalize() seulement si la fonction Dispose(disposing As Boolean) ci-dessus a du code pour libérer les ressources non managées.
    'Protected Overrides Sub Finalize()
    '    ' Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(disposing As Boolean) ci-dessus.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Ce code est ajouté par Visual Basic pour implémenter correctement le modèle supprimable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(disposing As Boolean) ci-dessus.
        Dispose(True)
        ' TODO: supprimer les marques de commentaire pour la ligne suivante si Finalize() est remplacé ci-dessus.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
#End Region

End Class