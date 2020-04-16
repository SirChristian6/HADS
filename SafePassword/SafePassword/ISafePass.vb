' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
<ServiceContract()>
Public Interface ISafePass

    <OperationContract()>
    Function esSegura(ByVal pass As String) As String

End Interface

