Imports System.ServiceModel

' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de interfaz "IPassword" en el código y en el archivo de configuración a la vez.
<ServiceContract()>
Public Interface IPassword

    <OperationContract()>
    Function esSegura(ByVal pass As String) As String

End Interface
