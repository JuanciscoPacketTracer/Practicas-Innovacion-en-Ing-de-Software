# Practicas Innovacion en Ing. de Software

Aplicacion de windows forms .NET con practicas realizadas para la materia de Innovacion en Ingenieria de Software de 6t semestre

Docente: Alan Fernando Meza Cota

formulario menu que lleva a 5 opciones

Proceso ETL

Formulario que carga un archivo .CSV, le da formato a la informacion y lo introduce a una base de datos Mysql.
Posteriormente, trae los registros de la base de datos y los llena en un datagridview con paginación.

Proceso Captura de Frame

Formulario que utiliza AForge video para mediante video activar la camara, capturar video en un picture box, pausar en un frame especifico,
luego guarda el frame en la base de datos Mysql como un archivo blob.
Cuenta con boton para consultar la base de datos y cargar todos los registros en un datagridview.

Proceso Envio de Emails

Formulario que utiliza MailKit y contraseñas de aplicaciones de gmail para, mediante textbox, llenar la informacion necesaria para enviar correos.
Permite adjuntar archivos.

Proceso Reconocimiento de texto

Formulario que carga imagen y utilizando Tesseract reconoce el texto de la imagen, con la posibilidad de guardar el texto reconocido como archivo txt

Proceso Generacion de codigo de barras y Crud de productos

Formulario que utliza TabControl para mostrar operacion CRUD para manejar productos, permite imprimir un reporte de los productos donde se genera un codigo de barras a partir del codigo ID del producto
