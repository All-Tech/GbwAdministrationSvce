Imports System.Configuration
Imports System.Data.Common
Imports Gbw.Administration.Domain.Communs
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Common.DAL.Containeur
Imports Gbw.Common.DAL.Factories
Imports Gwb.Common.Models

Public Class EssenceRepository
    Implements IEssenceRepository

    Private dale As IDataContaineur
#Region "CONSTANTS"
    Private Const PS_SELECT_ALL As String = "sp_EssenceSelect"
    Private Const PS_SELECT_BYID As String = "sp_EssenceSelectById"
    Private Const PS_INSERT As String = "sp_Essenceinsert"
    Private Const PS_UPDATE As String = "sp_EssenceUpdate"
    Private Const PS_DELETE As String = "sp_EssenceDelete"
#End Region


#Region "Constructeurs"
    Public Sub New()
        dale = New DataContaineur()
    End Sub


#End Region
#Region "Methods"
    Public Function ObtenireListe(Id As Integer) As List(Of Essence) Implements IRepository(Of Essence).ObtenireListe
        Dim essences As New List(Of Essence)
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_ALL, CommandType.StoredProcedure)
        essences = dale.ExecuteList(Of Essence)(command)
        Return essences
    End Function

    Public Function ObtenireParId(Id As Integer) As Essence Implements IRepository(Of Essence).ObtenireParId
        Dim essence As Essence = Nothing
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_BYID, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@Id", Id))
        essence = dale.ExecuteSingle(Of Essence)(command)
        Return essence
    End Function
    Public Function Creation(ByRef essence As Essence) As Boolean Implements IRepository(Of Essence).Creation
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_INSERT, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateOutputParameter("@OutEssenceID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@ClasseEssenceID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@SocieteID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CategorieEssenceID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@Libelle", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@NomScientifique", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeMesurage", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@DiamExpeditionOfficielle", SqlDbType.SmallInt))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@MesurageAubier", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeActif", SqlDbType.Bit))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@NomSnt", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeCubagePlein", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeCubageCom", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeStat", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeCde", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeIhc", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@Aupdate", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@RendementProduitRC", SqlDbType.Real))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@EtatIc", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@RendementProduitRC1", SqlDbType.Real))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@SeuilLongueurEntreeScie", SqlDbType.Real))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@PrixFob", SqlDbType.Real))
        Return dale.ExecuteNonQuery(essence.EssenceID, command, "@OutEssenceID")
    End Function

    Public Function Misejour(ByVal essence As Essence) As Boolean Implements IRepository(Of Essence).Misejour
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_UPDATE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateOutputParameter("@EssenceID", essence.EssenceID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@ClasseEssenceID", essence.ClasseEssenceID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@SocieteID", essence.SocieteID.ToString()))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CategorieEssenceID", essence.CategorieEssenceID.ToString()))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@Libelle", essence.Libelle))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@NomScientifique", essence.NomScientifique))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeMesurage", essence.CodeMesurage))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@DiamExpeditionOfficielle", essence.DiamExpeditionOfficielle.ToString()))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@MesurageAubier", essence.MesurageAubier))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeActif", essence.CodeActif.ToString()))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@NomSnt", essence.NomSnt))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeCubagePlein", essence.CodeCubagePlein))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeCubageCom", essence.CodeCubageCom))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeStat", essence.CodeStat))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeCde", essence.CodeCde))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeIhc", essence.CodeIhc))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@Aupdate", essence.Aupdate))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@RendementProduitRC", essence.RendementProduitRC.ToString()))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@EtatIc", essence.EtatIc.ToString()))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@RendementProduitRC1", essence.RendementProduitRC1.ToString()))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@SeuilLongueurEntreeScie", essence.SeuilLongueurEntreeScie.ToString()))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@PrixFob", essence.PrixFob.ToString()))
        Return dale.ExecuteNonQuery(command)
    End Function
    Public Function Suppression(ByVal ID As Integer) As Boolean Implements IRepository(Of Essence).Suppression
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_DELETE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@EssenceID", ID))
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

    'Public Function Creation(ByRef entity As Essence) As Boolean Implements IRepository(Of Essence).Creation
    '    Throw New NotImplementedException()
    'End Function
#End Region
#End Region


End Class