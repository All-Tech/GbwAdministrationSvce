Imports System.Configuration
Imports System.Data.Common
Imports Gbw.Administration.Domain.Communs
Imports Gbw.Administration.Domain.Contracts
Imports Gbw.Common.DAL.Containeur
Imports Gbw.Common.DAL.Factories
Imports Gwb.Common.Models
Imports System.Data.SqlClient
Imports Gbw.Administration.Domain

Public Class ProduitRepository
    Implements IProduitRepository
    Private dale As IDataContaineur
#Region "CONSTANTS"
    Private Const PS_SELECT_ALL As String = "sp_ProduitSelect"
    Private Const PS_SELECT_BYID As String = "sp_ProduitSelectById"
    Private Const PS_INSERT As String = "sp_Produitinsert"
    Private Const PS_UPDATE As String = "sp_ProduitUpdate"
    Private Const PS_DELETE As String = "sp_ProduitDelete"
#End Region



#Region "Constructeurs"
    Public Sub New()
        dale = New DataContaineur()
    End Sub


#End Region
#Region "Methods"
    Public Function ObtenireListe(Id As Integer) As List(Of Produit) Implements IRepository(Of Produit).ObtenireListe
        Dim produits As New List(Of Produit)
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_ALL, CommandType.StoredProcedure)
        produits = dale.ExecuteList(Of Produit)(command)
        Return produits
    End Function

    Public Function ObtenireParId(Id As Integer) As Produit Implements IRepository(Of Produit).ObtenireParId
        Dim produit As Produit = Nothing
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_SELECT_BYID, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InProduitID", Id))
        produit = dale.ExecuteSingle(Of Produit)(command)
        Return produit
    End Function

    Public Function Creation(ByRef produit As Produit) As Boolean Implements IRepository(Of Produit).Creation
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_INSERT, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateOutputParameter("@pn_InProduitID", SqlDbType.Int))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InSocieteID", produit.SocieteID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InSousFamilleID", produit.SousFamilleID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCodeProduit", produit.CodeProduit))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", produit.Libelle))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InTypeQualite", produit.TypeQualite))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InTypeGroupe", produit.TypeGroupe))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCodeActivite", produit.CodeActivite))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCodePlaque", produit.CodePlaque))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InPostAff", produit.PostAff))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCodeSig", produit.CodeSig))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InSDKDF", produit.SDKDF))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InUnites", produit.Unites))
        Return dale.ExecuteNonQuery(produit.ProduitID, command, "@pn_InProduitID")
    End Function

    Public Function Misejour(ByVal produit As Produit) As Boolean Implements IRepository(Of Produit).Misejour
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_UPDATE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InProduitID", produit.ProduitID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InSocieteID", produit.SocieteID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InSousFamilleID", produit.SousFamilleID))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCodeProduit", produit.CodeProduit))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InLibelle", produit.Libelle))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InTypeQualite", produit.TypeQualite))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InTypeGroupe", produit.TypeGroupe))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCodeActivite", produit.CodeActivite))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCodePlaque", produit.CodePlaque))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InPostAff", produit.PostAff))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InCodeSig", produit.CodeSig))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InSDKDF", produit.SDKDF))
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pc_InUnites", produit.Unites))
        Return dale.ExecuteNonQuery(command)
    End Function
    Public Function Suppression(ByVal ID As Integer) As Boolean Implements IRepository(Of Produit).Suppression
        Dim command As DbCommand = CommandeFactory.CreateCommand(PS_DELETE, CommandType.StoredProcedure)
        command.Parameters.Add(ParamertesFactory.CreateParameter("@pn_InProduitID", ID))
        Return dale.ExecuteNonQuery(command)
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        Throw New NotImplementedException()
    End Sub
#End Region


End Class