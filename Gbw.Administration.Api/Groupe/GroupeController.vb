Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Results
Imports Gbw.Administration.Api.Controllers
Imports Gbw.Administration.Api.Models
Imports Gbw.Administration.Service.services
Imports Unity

Namespace Groupe
    <RoutePrefix("api/groupes")>
    Public Class GroupeController
        Inherits BaseController

#Region "------ Proprietes ------"
        Private groupeService As IGroupeService
        Private ReadOnly mappeur As IGroupeMappeurFrom
        Dim container As UnityContainer
#End Region

#Region "------ Constructeur ------"
        Public Sub New(ByVal unGroupeService As IGroupeService,
                       _mappeur As IGroupeMappeurFrom)
            If unGroupeService Is Nothing Then
                Throw New ArgumentNullException("unGroupeService")
            End If
            If _mappeur Is Nothing Then
                Throw New ArgumentNullException("_mappeur")
            End If

            groupeService = unGroupeService
            mappeur = _mappeur
            container = New UnityContainer()
        End Sub
#End Region

#Region "------ Methodes Http ------"

#End Region
        ' GET: api/Groupe
        Public Function GetValues(ByVal siteid As Integer) As IHttpActionResult
            '' Dim mappeurT = container.Resolve(Of IGroupeMappeurFrom)
            Try
                Dim liste = groupeService.ObtenireListe(siteid)
                Dim groupes As List(Of GroupeViemodel) = New List(Of GroupeViemodel)()
                groupes = mappeur.MappageGroupefrom(liste)

                'liste.ForEach(Function(obj)
                '                  groupes.Add(mappeur.MappageGroupefrom(obj))
                '                  Return True
                '              End Function)
                If liste Is Nothing Then
                    Return NotFound()
                End If

                Return Ok(Of GroupeReponse)(New GroupeReponse() With {
                                                            .Message = Nothing,
                                                            .Groupe = Nothing,
                                                            .Success = True,
                                                            .Groupes = groupes
                                                            })
            Catch ex As Exception
                Dim response As HttpResponseMessage = New HttpResponseMessage(HttpStatusCode.Ambiguous) With {
                    .Content = New ObjectContent(Of Object)(New With {Key .message = New GroupeReponse() With {
                                                            .Message = New Message With {.CodeMessage = "erreur: 00001", .LibelleMessageEn = ex.Message},
                                                            .Groupes = Nothing
                                                            },
                    .StatusCode = System.Net.HttpStatusCode.Ambiguous
                     }, Configuration.Formatters.JsonFormatter)}
                Return New ResponseMessageResult(response)
            End Try

            '  Return Ok(Of Object)(New With {.id = siteid, .libelle = "essigan"})
        End Function

        ' GET: api/Groupe/5
        Public Function GetValue(ByVal id As Integer) As IHttpActionResult
            Try
                Dim groupe = groupeService.ObtenireParId(id)
                If groupe Is Nothing Then
                    Return NotFound()
                End If
                Dim groupemapper As GroupeViemodel = mappeur.MappageGroupefrom(groupe)
                Return Ok(Of GroupeReponse)(New GroupeReponse() With {
                                                           .Message = Nothing,
                                                           .Success = True,
                                                           .Groupes = Nothing,
                                                           .Groupe = groupemapper
                                                           })

            Catch ex As Exception
                Dim response As HttpResponseMessage = New HttpResponseMessage(HttpStatusCode.Ambiguous) With {
                   .Content = New ObjectContent(Of Object)(New With {Key .message = New GroupeReponse() With {
                                                           .Message = New Message With {.CodeMessage = "erreur: 00001", .LibelleMessageEn = ex.Message},
                                                           .Groupes = Nothing
                                                           },
                   .StatusCode = System.Net.HttpStatusCode.Ambiguous
                    }, Configuration.Formatters.JsonFormatter)}
                Return New ResponseMessageResult(response)
            End Try

        End Function

        ' POST: api/Groupe
        Public Function PostValue(<FromBody()> ByVal value As GroupeRequette) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                Dim requette = mappeur.MappageGroupeTo(value)
                Dim estcreation As Boolean = groupeService.Creation(requette)
                Return Ok(Of GroupeReponse)(New GroupeReponse() With {
                                                           .Message = Nothing,
                                                           .Success = True,
                                                           .Groupes = Nothing,
                                                           .Groupe = Nothing
                                                           })

            Catch ex As Exception
                Dim response As HttpResponseMessage = New HttpResponseMessage(HttpStatusCode.BadRequest) With {
                   .Content = New ObjectContent(Of Object)(New With {Key .message = New GroupeReponse() With {
                                                           .Message = New Message With {.CodeMessage = "erreur: 00002", .LibelleMessageEn = ex.Message},
                                                           .Groupes = Nothing
                                                           },
                   .StatusCode = System.Net.HttpStatusCode.BadRequest
                    }, Configuration.Formatters.JsonFormatter)}
                Return New ResponseMessageResult(response)
            End Try

            'Dim id = CabinetLayer.CreationNouveauCabinet(value)
            Return Ok(10)
        End Function

        ' PUT: api/Groupe/5
        Public Function PutValue(ByVal id As Integer, <FromBody()> ByVal value As GroupeModificationRequette) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            If Not id = value.GroupeID Then
                Return BadRequest()
            End If

            Try

                Dim requette = mappeur.MappageGroupeModificationTo(value)
                Dim estModification As Boolean = groupeService.Misejour(requette)
                If estModification Then
                    Return Ok(Of GroupeReponse)(New GroupeReponse() With {
                                                           .Message = Nothing,
                                                           .Success = True,
                                                           .Groupes = Nothing,
                                                           .Groupe = Nothing
                                                           })
                Else
                    Throw New Exception("Pas de midication valide")
                End If

            Catch ex As Exception
                Dim response As HttpResponseMessage = New HttpResponseMessage(HttpStatusCode.BadRequest) With {
                  .Content = New ObjectContent(Of Object)(New With {Key .message = New GroupeReponse() With {
                                                          .Message = New Message With {
                                                                                        .CodeMessage = "erreur: 00002",
                                                                                        .LibelleMessageEn = ex.Message
                                                                                       },
                                                          .Groupes = Nothing
                                                          },
                  .StatusCode = System.Net.HttpStatusCode.BadRequest
                   }, Configuration.Formatters.JsonFormatter)}
                Return New ResponseMessageResult(response)
            End Try

        End Function

        ' DELETE: api/Groupe/5
        Public Function DeleteValue(ByVal id As Integer) As IHttpActionResult
            Try
                Dim groupe = groupeService.ObtenireParId(id)

                If groupe Is Nothing Then
                    Return NotFound()
                End If

                Dim estSupprimer As Boolean = groupeService.Suppression(id)

                If estSupprimer Then
                    Return Ok(Of GroupeReponse)(New GroupeReponse() With {
                                                           .Message = Nothing,
                                                           .Success = True,
                                                           .Groupes = Nothing,
                                                           .Groupe = Nothing
                                                           })
                Else
                    Throw New Exception("Pas de suppression effectué ")
                End If
            Catch ex As Exception
                Dim response As HttpResponseMessage = New HttpResponseMessage(HttpStatusCode.BadRequest) With {
                  .Content = New ObjectContent(Of Object)(New With {Key .message = New GroupeReponse() With {
                                                          .Message = New Message With {
                                                                                        .CodeMessage = "erreur: 00002",
                                                                                        .LibelleMessageEn = ex.Message
                                                                                       },
                                                          .Groupes = Nothing
                                                          },
                  .StatusCode = System.Net.HttpStatusCode.BadRequest
                   }, Configuration.Formatters.JsonFormatter)}
                Return New ResponseMessageResult(response)
            End Try
        End Function
    End Class


End Namespace