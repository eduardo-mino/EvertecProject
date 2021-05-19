# EvertecProject

Instrucciones de instalación:

BASE DE DATOS
- este proyecto requiere crear primero la base de datos.
	para eso se puede generar un script de directamente desde el proyecto de base de datos.
	se debe crear la base en la instancia de sql y el script agrega todos los elementos necesarios.
	

IIS
- se deben crear 2 aplicacione web en IIS en el servdor donde se quiera instalar la aplicación, una para el portal web y otra para la API de servicios.
- no tiene que ser creadas en un mismo servidor, se pueden usar servidores diferentes para front-end y back-end


- compilar toda la solución

FRONT END
- publicar el proyecto: EvertecProject_WebApplication en la aplicaón web destinada al portal.
- ediar el archivo web.config del proyecto: modificar el valor del registro con key "OrdersApiBaseUrl" con la url del la aplicación destinada a la API:
    - <add key="OrdersApiBaseUrl" value="http://{{servdor}}:{{puerto}}/{{nombre de aplición}}/API/"/>


BACK END
- publicar el proyecto: EvertecProject_API en la aplicaón we estinada para la API de servicios.
- editar el archivo web.config del proyecto: modificar el valor del retistro con key "WebPortalUrl" con la url de la aplicación del portal web
    <add key="WebPortalUrl" value="http://{{servdor}}:{{puerto}}/{{nombre de aplición}}/pages/OrderStatus.aspx?orderId={0}"/>
- también se deben chequear los datos de WebCheckOut
    <add key="Login" value="6dd490faf9cb87a9862245da41170ff2" />
    <add key="TranKey" value="024h1IlD" />
    <add key="WebCheckOutUrl" value="https://test.placetopay.com/redirection/" />
- finalmente resta configurar el connectionstring con los datos de la base creada para este proyecto:
    <add name="Orders" connectionString="server={{servidor}};database={{database name}};Integrated Security=True" providerName="System.Data.SqlClient" />


API NOTIFICATIONS HANDLER
Esta API fue creada para recibir las notificaciones de pago de PlaceToPay con el fin de actualizar el estado de pago de la orden correspondiente.

- esta API se debe publicar en una aplicación bajo un sitio de IIS que utilice el puerto 80 o el 443 porque así lo requiere la documentación de PlaceToPay
- tiene dos endpoint sque manejan diferente las notificaciones. se debe evaluar cual es la mejor forma de recibir esas notificaciones para quitar el otro método.
- el web.config también debe tener configurado el connectionstring para la database:
    <add name="Orders" connectionString="server={{servidor}};database={{database name}};Integrated Security=True" providerName="System.Data.SqlClient" />

