Imports System.Configuration
Imports System.Data.Common
Imports Gbw.Administration.Domain.Communs
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Common.DAL.Containeur
Imports Gbw.Common.DAL.Factories
Imports Gwb.Common.Models
Imports System.Data.SqlClient

Public Class SousFamilleRepository
	 Implements ISousFamilleRepository
	 Private dale As IDataContaineur
     #Region "CONSTANTS"
     Private Const PS_SELECT_ALL As String ="sp_SousFamilleSelect"
     Private Const PS_SELECT_BYID As String ="sp_SousFamilleSelectById"
     Private Const PS_INSERT As String ="sp_SousFamilleinsert"
     Private Const PS_UPDATE As String ="sp_SousFamilleUpdate"
     Private Const PS_DELETE As String ="sp_SousFamilleDelete"
     #End Region

     #Region "Fields"
      Private _SousFamilleID As Integer
    Private _FamilleID As Integer
    Private _Code As String
      Private _Libelle As String
#End Region




#Region "Constructeurs"
    Public Sub New()
	          dale = New DataContaineur()
       End Sub


     #End Region
     #Region "Methods"
      Public  Function ObtenireListe(Id As Integer) As List(Of SousFamille) Implements IRepository(Of SousFamille).ObtenireListe
         Dim sousfamilles As New List(Of SousFamille)
         Dim command As DbCommand =CommandeFactory.CreateCommand(PS_SELECT_ALL,CommandType.StoredProcedure)
        sousfamilles = dale.ExecuteList(Of SousFamille)(command)
        Return sousfamilles
       End Function

      Public  Function ObtenireParId(Id As Integer) As  SousFamille  Implements IRepository(Of SousFamille).ObtenireParId
         Dim sousfamille  As  SousFamille= Nothing
         Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_BYID, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InSousFamilleID", Id))
        sousfamille = dale.ExecuteSingle(Of SousFamille)(command)
        Return sousfamille
      End Function

    Public Function Creation(ByRef sousfamille As SousFamille) As Boolean Implements IRepository(Of SousFamille).Creation
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_INSERT, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateOutputParameter("@pn_InSousFamilleID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InFamilleID", sousfamille.FamilleID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCode", sousfamille.Code))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", sousfamille.Libelle))
        Return dale.ExecuteNonQuery(sousfamille.SousFamilleID, command, "@pn_InSousFamilleID")
    End Function

    Public  Function Misejour(ByVal sousfamille As SousFamille) As Boolean Implements IRepository(Of SousFamille).Misejour
      Dim command As DbCommand = CommandeFactory.CreateCommand(PS_UPDATE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InSousFamilleID", sousfamille.SousFamilleID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InFamilleID", sousfamille.FamilleID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCode", sousfamille.Code))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", sousfamille.Libelle))
        Return dale.ExecuteNonQuery(command)
      End Function
      Public  Function Suppression(ByVal ID As Integer )  As Boolean Implements IRepository(Of SousFamille).Suppression
      Dim command As DbCommand = CommandeFactory.CreateCommand(PS_DELETE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InSousFamilleID", ID))
        Return dale.ExecuteNonQuery(command)
    End Function


    Public Sub Dispose() Implements IDisposable.Dispose
        Throw New NotImplementedException()
    End Sub
#End Region


End Class