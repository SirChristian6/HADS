Imports System.ServiceModel

' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de interfaz "IService2" en el código y en el archivo de configuración a la vez.
<ServiceContract()>
Public Interface HorasMedias

    <OperationContract()>
    Function HorasMedias(ByVal asignatura As String) As Double

End Interface
