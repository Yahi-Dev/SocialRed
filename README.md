OJO: Al momento de alguien bajar los cambios debe de cambiar solamente del appsettings.json (en el proyecto de WebApi y del WebApp) el IdentityConnection y
el DefaultConnetion con la ruta de su base de datos, luego vas a Package Manager Console y en la opción que dice Default Projects lo vas a poner primero en la capa de identity y vas a escribir:
Update-Database -Context IdentityContext, Lo mismo vas hacer con la capa de persistence, vas a cambiar de la capa de identity a persistencia y en el panel de escritura vas a escribir: Update-Database
-Context ApplicationContext. Sino haces estos cambios no te va a funcionar la app y te va a dar un error de mapeo con la base de datos.


Resumen de la Funcionalidad de la Aplicación
Objetivo General
Crear una red social donde los usuarios puedan crear publicaciones y estas puedan ser comentadas por sus amigos, utilizando ASP.NET Core MVC 6, 7 o 8.

Funcionalidad

Login y Registro:

Pantalla inicial de login con formulario para usuario y contraseña.
Redirección al Home si el usuario ya está logueado.
Opción de registro con formulario para crear un nuevo usuario (Nombre, Apellido, Teléfono, Correo, Foto de perfil, Nombre de usuario, Contraseña y Confirmar contraseña).
Validaciones para campos requeridos y formato de datos.
Restablecimiento de contraseña mediante nombre de usuario, con envío de correo para la nueva contraseña.
Activación de usuario vía correo electrónico.
Publicaciones (Home):

Listado de publicaciones del usuario, ordenadas desde la más reciente a la más antigua.
Posibilidad de agregar comentarios y respuestas (replies) a publicaciones y comentarios.
Creación, modificación y eliminación de publicaciones (solo propias).
Opción para publicar imágenes y videos de YouTube.
Amigos:

Listado de publicaciones de amigos con opción de agregar comentarios y replies.
Gestión de amigos: visualizar, agregar y eliminar amigos.
Agregar amigos mediante nombre de usuario.
Mi Perfil:

Formulario para modificar información del perfil (Nombre, Apellido, Teléfono, Correo, Foto de perfil, Contraseña y Confirmar contraseña).
Validaciones para campos requeridos, excepto foto de perfil y contraseña.
Seguridad:

Restricción de acceso a publicaciones, perfil y amigos para usuarios no logueados.
Redirección al login con mensaje de permiso denegado si se intenta acceder sin estar logueado.
Consideraciones Generales

Uso de viewmodels para validaciones.
Persistencia de datos mediante Entity Framework con code first.
Interfaz visualmente entendible utilizando Bootstrap.
Aplicación de la arquitectura ONION al 100%.
Implementación de repositorios y servicios genéricos.
Uso de AutoMapper.
Capa de shared para el servicio de correo.
Descripción del Proyecto en Readme
Descripción del Proyecto

Este proyecto implementa una red social donde los usuarios pueden crear y gestionar publicaciones, interactuar con amigos mediante comentarios y replies, y actualizar su perfil personal. La aplicación está desarrollada utilizando ASP.NET Core MVC y sigue la arquitectura ONION para asegurar una separación clara de preocupaciones y una alta mantenibilidad del código.

Tecnologías Utilizadas

ASP.NET Core MVC (versiones 6, 7 o 8): Framework principal para la construcción de la aplicación.
Entity Framework Core: Para la persistencia de datos utilizando el enfoque code first.
Bootstrap: Para una interfaz de usuario moderna y responsiva.
AutoMapper: Para mapeo entre objetos de dominio y viewmodels.
Arquitectura ONION: Para una separación clara de las capas de la aplicación y mejorar la mantenibilidad y testabilidad del código.
Capa de Shared: Utilizada para implementar el servicio de correo para la activación de usuarios y restablecimiento de contraseñas.
Funcionalidades Clave

Autenticación y Autorización: Sistema de login y registro con activación de cuenta vía correo electrónico y restablecimiento de contraseña.
Gestión de Publicaciones: Crear, editar y eliminar publicaciones propias, con soporte para comentarios y respuestas.
Gestión de Amigos: Agregar y eliminar amigos, y visualizar sus publicaciones.
Perfil de Usuario: Actualización de la información del perfil personal.
Seguridad: Acceso restringido a funcionalidades clave para usuarios no logueados.
Este proyecto busca proporcionar una base sólida para una red social funcional, con un enfoque en la seguridad, la validación de datos y la usabilidad.
