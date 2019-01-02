Imports System.Configuration
Imports System.Data.Common
Imports Gbw.Administration.Domain.Communs
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Common.DAL.Containeur
Imports Gbw.Common.DAL.Factories
Imports Gwb.Common.Models
Imports System.Data.SqlClient

Public Class QualiteIHCRepository
	 Implements IQualiteIHCRepository
	 Private dale As IDataContaineur
     #Region "CONSTANTS"
     Private Const PS_SELECT_ALL As String ="sp_QualiteIHCSelect"
     Private Const PS_SELECT_BYID As String ="sp_QualiteIHCSelectById"
     Private Const PS_INSERT As String ="sp_QualiteIHCinsert"
     Private Const PS_UPDATE As String ="sp_QualiteIHCUpdate"
     Private Const PS_DELETE As String ="sp_QualiteIHCDelete"
     #End Region

     #Region "Fields"
      Private _QualiteIHCID As Integer
      Private _ProduitID As Integer
      Private _CodeQualite As String
      Private _Libelle As String
      Private _CodeMercuriale As String
      Private _CodeActivite As String
      Private _CodePlaquette As String
      Private _CodePlaquette1 As String
      Private _CodeIhc As String
      Private _PrixVenteLocale As Single
      Private _PosAffic As String
      Private _LongueurRecuperation As Single
     #End Region


     #Region "Constructeurs"
       Public Sub New()
	          dale = New DataContaineur()
       End Sub


     #End Region
     #Region "Methods"
      Public  Function ObtenireListe(Id As Integer) As List(Of QualiteIHC) Implements IRepository(Of QualiteIHC).ObtenireListe
         Dim qualiteihcs As New List(Of QualiteIHC)
         Dim command As DbCommand =CommandeFactory.CreateCommand(PS_SELECT_ALL,CommandType.StoredProcedure)
	qualiteihcs= dale.ExecuteList(Of QualiteIHC)(command)
         Return qualiteihcs
       End Function

      Public  Function ObtenireParId(Id As Integer) As  QualiteIHC  Implements IRepository(Of QualiteIHC).ObtenireParId
         Dim qualiteihc  As  QualiteIHC= Nothing
         Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_BYID, CommandType.StoredProcedure)
         command.Parameters.Add(ParamertesFactory.CreateParameter("@Id", Id))
      qualiteihc = dale.ExecuteSingle(Of QualiteIHC)(command)
        Return qualiteihc
      End Function

    Public Function Creation(ByRef qualiteihc As QualiteIHC) As Boolean Implements IRepository(Of QualiteIHC).Creation
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_INSERT, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateOutputParameter("@OutQualiteIHCID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@ProduitID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeQualite", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@Libelle", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeMercuriale", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeActivite", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodePlaquette", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodePlaquette1", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeIhc", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@PrixVenteLocale", SqlDbType.Real))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@PosAffic", SqlDbType.VarChar))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@LongueurRecuperation", SqlDbType.Real))
        Return dale.ExecuteNonQuery(qualiteihc.QualiteIHCID, command, "@OutQualiteIHCID")
    End Function

    Public  Function Misejour(ByVal qualiteihc As QualiteIHC) As Boolean Implements IRepository(Of QualiteIHC).Misejour
      Dim command As DbCommand = CommandeFactory.CreateCommand(PS_UPDATE, CommandType.StoredProcedure)
	command.Parameters.Add(ParamertesFactory.CreateParameter("@QualiteIHCID" ,qualiteihc.QualiteIHCID))
	command.Parameters.Add(ParamertesFactory.CreateParameter("@ProduitID" ,qualiteihc.ProduitID))
	command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeQualite" ,qualiteihc.CodeQualite))
	command.Parameters.Add(ParamertesFactory.CreateParameter("@Libelle" ,qualiteihc.Libelle))
	command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeMercuriale" ,qualiteihc.CodeMercuriale))
	command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeActivite" ,qualiteihc.CodeActivite))
	command.Parameters.Add(ParamertesFactory.CreateParameter("@CodePlaquette" ,qualiteihc.CodePlaquette))
	command.Parameters.Add(ParamertesFactory.CreateParameter("@CodePlaquette1" ,qualiteihc.CodePlaquette1))
	command.Parameters.Add(ParamertesFactory.CreateParameter("@CodeIhc" ,qualiteihc.CodeIhc))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@PrixVenteLocale", Integer.Parse(qualiteihc.PrixVenteLocale)))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@PosAffic" ,qualiteihc.PosAffic))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@LongueurRecuperation", Integer.Parse(qualiteihc.LongueurRecuperation)))
        Return dale.ExecuteNonQuery(command)
      End Function
    Public Function Suppression(ByVal ID As Integer) As Boolean Implements IRepository(Of QualiteIHC).Suppression
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_DELETE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@QualiteIHCID", ID))
        Return True
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        Throw New NotImplementedException()
    End Sub
#End Region


End Class