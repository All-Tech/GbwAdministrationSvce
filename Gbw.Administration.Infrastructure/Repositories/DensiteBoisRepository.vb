Imports System.Configuration
Imports System.Data.Common
Imports Gbw.Administration.Domain.Communs
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Common.DAL.Containeur
Imports Gbw.Common.DAL.Factories
Imports Gwb.Common.Models
Imports System.Data.SqlClient

Public Class DensiteBoisRepository
	 Implements IDensiteBoisRepository
	 Private dale As IDataContaineur
     #Region "CONSTANTS"
     Private Const PS_SELECT_ALL As String ="sp_DensiteBoisSelect"
     Private Const PS_SELECT_BYID As String ="sp_DensiteBoisSelectById"
     Private Const PS_INSERT As String ="sp_DensiteBoisinsert"
     Private Const PS_UPDATE As String ="sp_DensiteBoisUpdate"
     Private Const PS_DELETE As String ="sp_DensiteBoisDelete"
     #End Region

     #Region "Fields"
      Private _DensiteBoisID As Integer
      Private _EssenceID As Integer
      Private _ProduitID As Integer
      Private _Libelle As Single
     #End Region


     #Region "Constructeurs"
       Public Sub New()
	          dale = New DataContaineur()
       End Sub


#End Region


#Region "Methods"
    Public  Function ObtenireListe(Id As Integer) As List(Of DensiteBois) Implements IRepository(Of DensiteBois).ObtenireListe
         Dim densiteboiss As New List(Of DensiteBois)
         Dim command As DbCommand =CommandeFactory.CreateCommand(PS_SELECT_ALL,CommandType.StoredProcedure)
	densiteboiss= dale.ExecuteList(Of DensiteBois)(command)
         Return densiteboiss
       End Function

      Public  Function ObtenireParId(Id As Integer) As  DensiteBois  Implements IRepository(Of DensiteBois).ObtenireParId
         Dim densitebois  As  DensiteBois= Nothing
         Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_BYID, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InDensiteBoisID", Id))
        densitebois = dale.ExecuteSingle(Of DensiteBois)(command)
        Return densitebois
      End Function

    Public Function Creation(ByRef densitebois As DensiteBois) As Boolean Implements IRepository(Of DensiteBois).Creation
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_INSERT, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateOutputParameter("@pn_InDensiteBoisID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InEssenceID", densitebois.EssenceID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InProduitID", densitebois.ProduitID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pd_InLibelle", densitebois.Libelle))
        Return dale.ExecuteNonQuery(densitebois.DensiteBoisID, command, "@pn_InDensiteBoisID")
    End Function

    Public  Function Misejour(ByVal densitebois As DensiteBois) As Boolean Implements IRepository(Of DensiteBois).Misejour
      Dim command As DbCommand = CommandeFactory.CreateCommand(PS_UPDATE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InDensiteBoisID", densitebois.DensiteBoisID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InEssenceID", densitebois.EssenceID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InProduitID", densitebois.ProduitID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pd_InLibelle", densitebois.Libelle))
        Return dale.ExecuteNonQuery(command)
      End Function
      Public  Function Suppression(ByVal ID As Integer )  As Boolean Implements IRepository(Of DensiteBois).Suppression
      Dim command As DbCommand = CommandeFactory.CreateCommand(PS_DELETE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InDensiteBoisID", ID))
        Return dale.ExecuteNonQuery(command)
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        Throw New NotImplementedException()
    End Sub
#End Region


End Class