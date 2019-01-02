Imports System.Configuration
Imports System.Data.Common
Imports Gbw.Administration.Domain.Communs
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Common.DAL.Containeur
Imports Gbw.Common.DAL.Factories
Imports Gwb.Common.Models
Imports System.Data.SqlClient

Public Class FamilleRepository
	 Implements IFamilleRepository
	 Private dale As IDataContaineur
     #Region "CONSTANTS"
     Private Const PS_SELECT_ALL As String ="sp_FamilleSelect"
     Private Const PS_SELECT_BYID As String ="sp_FamilleSelectById"
     Private Const PS_INSERT As String ="sp_Familleinsert"
     Private Const PS_UPDATE As String ="sp_FamilleUpdate"
     Private Const PS_DELETE As String ="sp_FamilleDelete"
     #End Region

     #Region "Fields"
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
    Public  Function ObtenireListe(Id As Integer) As List(Of Famille) Implements IRepository(Of Famille).ObtenireListe
         Dim familles As New List(Of Famille)
         Dim command As DbCommand =CommandeFactory.CreateCommand(PS_SELECT_ALL,CommandType.StoredProcedure)
        familles = dale.ExecuteList(Of Famille)(command)
        Return familles
       End Function

      Public  Function ObtenireParId(Id As Integer) As  Famille  Implements IRepository(Of Famille).ObtenireParId
         Dim famille  As  Famille= Nothing
         Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_BYID, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InFamilleID", Id))
        famille = dale.ExecuteSingle(Of Famille)(command)
        Return famille
      End Function

    Public Function Creation(ByRef famille As Famille) As Boolean Implements IRepository(Of Famille).Creation
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_INSERT, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateOutputParameter("@pn_InFamilleID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCode", famille.Code))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", famille.Libelle))
        Return dale.ExecuteNonQuery(famille.FamilleID, command, "@pn_InFamilleID")
    End Function

    Public  Function Misejour(ByVal famille As Famille) As Boolean Implements IRepository(Of Famille).Misejour
      Dim command As DbCommand = CommandeFactory.CreateCommand(PS_UPDATE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InFamilleID", famille.FamilleID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCode", famille.Code))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", famille.Libelle))
        Return dale.ExecuteNonQuery(command)
      End Function
      Public  Function Suppression(ByVal ID As Integer )  As Boolean Implements IRepository(Of Famille).Suppression
      Dim command As DbCommand = CommandeFactory.CreateCommand(PS_DELETE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InFamilleID", ID))
        Return dale.ExecuteNonQuery(command)
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        Throw New NotImplementedException()
    End Sub
#End Region

End Class