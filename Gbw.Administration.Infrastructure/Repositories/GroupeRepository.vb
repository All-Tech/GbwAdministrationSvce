Imports System.Data.Common
Imports Gbw.Administration.Domain.Communs
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Common.DAL.Containeur
Imports Gbw.Common.DAL.Factories
Imports Gwb.Common.Models

''' <summary>
''' classe de persistence 
''' </summary>
Public Class GroupeRepository
    Implements IGroupeRepository

    Private dale As IDataContaineur

#Region "Constantes"
    Private Const PS_SELECT_ALL = "spGroupeSelectAll"
    Private Const PS_SELECT_BYID = "spGroupeSelect"
    Private Const PS_INSERT = "sp_GroupeInsert"
    Private Const PS_UPDATE = "sp_GroupeUpdate"
    Private Const PS_DELETE = "sp_GroupeDelete"
#End Region

#Region "Constructeur"
    Public Sub New()
        Dim de As New CategorieEssence()
        dale = New DataContaineur()
    End Sub

#End Region

#Region "functions publiques"


    Public Function ObtenireListe(Id As Integer) As List(Of Groupe) Implements IRepository(Of Groupe).ObtenireListe
        Dim groupes As List(Of Groupe) = Nothing
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_ALL, CommandType.StoredProcedure)
        groupes = dale.ExecuteList(Of Groupe)(command)
        Dim ext As New CategorieEssence()
        Return groupes
    End Function

    Public Function ObtenireParId(Id As Integer) As Groupe Implements IRepository(Of Groupe).ObtenireParId
        Dim groupe As Groupe = Nothing
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_BYID, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@Id", Id))
        groupe = dale.ExecuteSingle(Of Groupe)(command)
        Return groupe
    End Function


    Public Function Creation(ByRef entity As Groupe) As Boolean Implements IRepository(Of Groupe).Creation

        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_INSERT, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateOutputParameter("@pc_InGroupeID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCode", entity.Code, 50))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", entity.Libelle, 50))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InAdresse", entity.Adresse))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InVille", entity.Ville))
        Return dale.ExecuteNonQuery(entity.GroupeID, command, "@pc_InGroupeID")
    End Function

    Public Function Misejour(entity As Groupe) As Boolean Implements IRepository(Of Groupe).Misejour
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_UPDATE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InGroupeID", entity.GroupeID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCode", entity.Code, 50))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", entity.Libelle, 50))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InAdresse", entity.Adresse))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InVille", entity.Ville))
        Return dale.ExecuteNonQuery(command)
    End Function

    Public Function Suppression(Id As Integer) As Boolean Implements IRepository(Of Groupe).Suppression
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_DELETE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InGroupeID", Id))

        Return dale.ExecuteNonQuery(command)
    End Function

#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
