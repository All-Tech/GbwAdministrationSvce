Imports System.Web.Http.Dependencies
Imports Unity
Imports Unity.Exceptions

Public Class UnityWebApiActivator
    Implements IDependencyResolver

    Protected container As IUnityContainer

    Public Sub New(ByVal container As IUnityContainer)
        If container Is Nothing Then
            Throw New ArgumentNullException("container")
        End If
        Me.container = container
    End Sub


    Public Function BeginScope() As IDependencyScope Implements IDependencyResolver.BeginScope
        Dim child = container.CreateChildContainer()
        Return New UnityWebApiActivator(child)
    End Function

    Public Function GetService(serviceType As Type) As Object Implements IDependencyResolver.GetService
        Try
            Return container.Resolve(serviceType)
        Catch ex As ResolutionFailedException
            Return Nothing
        End Try
    End Function

    Public Function GetServices(serviceType As Type) As IEnumerable(Of Object) Implements IDependencyResolver.GetServices
        Try
            Return container.ResolveAll(serviceType)
        Catch ex As ResolutionFailedException
            Return New List(Of Object)
        End Try
    End Function
#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                container.Dispose()
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
