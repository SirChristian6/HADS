﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace HorasMediasAsignatura
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="HorasMediasAsignatura.HorasMedias")>  _
    Public Interface HorasMedias
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/HorasMedias/HorasMedias", ReplyAction:="http://tempuri.org/HorasMedias/HorasMediasResponse")>  _
        Function HorasMedias(ByVal asignatura As String) As Double
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/HorasMedias/HorasMedias", ReplyAction:="http://tempuri.org/HorasMedias/HorasMediasResponse")>  _
        Function HorasMediasAsync(ByVal asignatura As String) As System.Threading.Tasks.Task(Of Double)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface HorasMediasChannel
        Inherits HorasMediasAsignatura.HorasMedias, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class HorasMediasClient
        Inherits System.ServiceModel.ClientBase(Of HorasMediasAsignatura.HorasMedias)
        Implements HorasMediasAsignatura.HorasMedias
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function HorasMedias(ByVal asignatura As String) As Double Implements HorasMediasAsignatura.HorasMedias.HorasMedias
            Return MyBase.Channel.HorasMedias(asignatura)
        End Function
        
        Public Function HorasMediasAsync(ByVal asignatura As String) As System.Threading.Tasks.Task(Of Double) Implements HorasMediasAsignatura.HorasMedias.HorasMediasAsync
            Return MyBase.Channel.HorasMediasAsync(asignatura)
        End Function
    End Class
End Namespace