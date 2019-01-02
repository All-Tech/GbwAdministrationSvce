Imports System.Configuration
Imports System.Data.Common
Imports Gbw.Administration.Domain.Communs
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Common.DAL.Containeur
Imports Gbw.Common.DAL.Factories
Imports Gwb.Common.Models
Imports System.Data.SqlClient

Public Class ClasseEssenceRepository
	 Implements IClasseEssenceRepository
	 Private dale As IDataContaineur
     #Region "CONSTANTS"
     Private Const PS_SELECT_ALL As String ="sp_ClasseEssenceSelect"
     Private Const PS_SELECT_BYID As String ="sp_ClasseEssenceSelectById"
     Private Const PS_INSERT As String ="sp_ClasseEssenceinsert"
     Private Const PS_UPDATE As String ="sp_ClasseEssenceUpdate"
     Private Const PS_DELETE As String ="sp_ClasseEssenceDelete"
     #End Region

     #Region "Fields"
      Private _ClasseEssenceID As Integer
      Private _Libelle As String
#End Region

#Region "Constructeurs"
    Public Sub New()
	          dale = New DataContaineur()
       End Sub


     #End Region
     #Region "Methods"
      Public  Function ObtenireListe(Id As Integer) As List(Of ClasseEssence) Implements IRepository(Of ClasseEssence).ObtenireListe
         Dim classeessences As New List(Of ClasseEssence)
         Dim command As DbCommand =CommandeFactory.CreateCommand(PS_SELECT_ALL,CommandType.StoredProcedure)
	classeessences= dale.ExecuteList(Of ClasseEssence)(command)
         Return classeessences
       End Function

      Public  Function ObtenireParId(Id As Integer) As  ClasseEssence  Implements IRepository(Of ClasseEssence).ObtenireParId
         Dim classeessence  As  ClasseEssence= Nothing
         Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_BYID, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InClasseEssenceID", Id))
        classeessence = dale.ExecuteSingle(Of ClasseEssence)(command)
        Return classeessence
      End Function

    Public Function Creation(ByRef classeessence As ClasseEssence) As Boolean Implements IRepository(Of ClasseEssence).Creation
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_INSERT, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateOutputParameter("@pn_InClasseEssenceID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", classeessence.Libelle))
        Return dale.ExecuteNonQuery(classeessence.ClasseEssenceID, command, "@pn_InClasseEssenceID")
    End Function

    Public  Function Misejour(ByVal classeessence As ClasseEssence) As Boolean Implements IRepository(Of ClasseEssence).Misejour
      Dim command As DbCommand = CommandeFactory.CreateCommand(PS_UPDATE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InClasseEssenceID", classeessence.ClasseEssenceID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", classeessence.Libelle))
        Return dale.ExecuteNonQuery(command)
      End Function
      Public  Function Suppression(ByVal ID As Integer )  As Boolean Implements IRepository(Of ClasseEssence).Suppression
      Dim command As DbCommand = CommandeFactory.CreateCommand(PS_DELETE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InClasseEssenceID", ID))
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