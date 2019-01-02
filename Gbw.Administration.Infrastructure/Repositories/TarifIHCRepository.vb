Imports System.Configuration
Imports System.Data.Common
Imports Gbw.Administration.Domain.Communs
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Common.DAL.Containeur
Imports Gbw.Common.DAL.Factories
Imports Gwb.Common.Models
Imports System.Data.SqlClient
Imports Gbw.Administration.Domain.services

Public Class TarifIHCRepository
    Implements ITarifIHCRepository
    Private dale As IDataContaineur
#Region "CONSTANTS"
    Private Const PS_SELECT_ALL As String = "sp_TarifIHCSelect"
    Private Const PS_SELECT_BYID As String = "sp_TarifIHCSelectById"
    Private Const PS_INSERT As String = "sp_TarifIHCinsert"
    Private Const PS_UPDATE As String = "sp_TarifIHCUpdate"
    Private Const PS_DELETE As String = "sp_TarifIHCDelete"
#End Region

#Region "Constructeurs"
    Public Sub New()
        dale = New DataContaineur()
    End Sub


#End Region
#Region "Methods"
    Public Function ObtenireListe(Id As Integer) As List(Of TarifIHC) Implements IRepository(Of TarifIHC).ObtenireListe
        Dim tarifihcs As New List(Of TarifIHC)
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_ALL, CommandType.StoredProcedure)
        tarifihcs = dale.ExecuteList(Of TarifIHC)(command)
        Return tarifihcs
    End Function

    Public Function ObtenireParId(Id As Integer) As TarifIHC Implements IRepository(Of TarifIHC).ObtenireParId
        Dim tarifihc As TarifIHC = Nothing
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_BYID, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@Id", Id))
        tarifihc = dale.ExecuteSingle(Of TarifIHC)(command)
        Return tarifihc
    End Function

    Public Function Creation(ByRef tarifihc As TarifIHC) As Boolean Implements IRepository(Of TarifIHC).Creation
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_INSERT, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateOutputParameter("@OutTarifIHCID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@SocieteID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@EssenceID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@ProduitID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@QualiteIHCID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@PrixM3Prix", SqlDbType.Real))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@AncienPrixM3", SqlDbType.Real))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@DateAncienPrixm3", SqlDbType.Date))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@DatePrixM3", SqlDbType.Date))
        Return dale.ExecuteNonQuery(tarifihc.TarifIHCID, command, "@OutTarifIHCID")
    End Function

    Public Function Misejour(ByVal tarifihc As TarifIHC) As Boolean Implements IRepository(Of TarifIHC).Misejour
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_UPDATE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@TarifIHCID", tarifihc.TarifIHCID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@SocieteID", tarifihc.SocieteID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@EssenceID", tarifihc.EssenceID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@ProduitID", tarifihc.ProduitID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@QualiteIHCID", tarifihc.QualiteIHCID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@PrixM3Prix", tarifihc.PrixM3Prix))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@AncienPrixM3", tarifihc.AncienPrixM3))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@DateAncienPrixm3", tarifihc.DateAncienPrixm3))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@DatePrixM3", tarifihc.DatePrixM3))
        Return dale.ExecuteNonQuery(command)
    End Function
    Public Function Suppression(ByVal ID As Integer) As Boolean Implements IRepository(Of TarifIHC).Suppression
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_DELETE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@TarifIHCID", ID))
        Return True
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