) Entornos de desarrollos en los que se Trabajó la prueba

- Visual Studio 2019

- SQL SERVER 2019

2) Configuraciones

- Restaurar la base de datos en nuestro SQL SERVER (Tienda_Comiclandia.BAK)

- Ejecutar la solucion del proyecto, Luego ir a carpeta CONEXION, entrar a la clase ConexionMaestra y asignarle a la variable Conexion las credenciales
   de su SQL SERVER

- Ejecutar la API

- Modificar el valor la variable url("Ingresar la url donde se ejecuta la Api en su equipo"), esta se encuentra al inicio de Class Form1
  
    
**************************************************************** Descripción *****************************************************************

1) Esta aplicacion aplicacion tiene 4 modulos (Ventas, Inventario, Usuario, Pedidos)

2) Modulo de ventas: En este se puden se realizan la venta de los productos que se encuentran en el sistema y su funcionamiento es de la siguiente forma:

- Agregar un producto al pedido: para realizar esta accion primero hay que buscar el producto por su nombre, Luego dar doble click para ver los datos del 
                                producto y por ultimo damos click en el boton Agregar

- Relizar Compra : Para registrar una venta damos click en el Boton (Compar/Separe), para que la venta sea exitosa debe haber almenos un producto agregado al pedido 
	           un cliente que este registrado en el sistema y la direccion de envio

3) Modulo Inventario : En este modulo se puede crear, modificar, eliminar y visualizar los productos de nuestro sistema

- Crear producto : Para crear un producto vamos al panel de producto, se ingresan todos los datos y se da click en el bonton de agregar (Para que este 
                   proceso se exitoso se debe diligenciar todos los campos)

- Editar Producto : Para poder editar un producto existente damos doble click sobre el producto, luego en el panel producto se cargaran los datos del producto seleccionado,
                    procedemos a modificar los campo y dar click en el boton editar para guardar los cambios 
    
- Eliminar Producto : Para poder eliminar un producto existente damos doble click sobre el producto, luego en el panel producto se cargaran los datos del producto seleccionado,
                      y dar click en el boton Eliminar
                                
4) Usuario : Este modulo nos permite agregar cliente a nuestro sistema, para esto se deben llenar todos los campo del formulario y dar click en el boton crear (No admite campos vacios)

5) Pedido : En este modulo podremos ver el historial de los pedido asi como consultar lo productos que contienen un pedido
            

Buscar Pedido: ingresamo la identificacion del cliente al cual queremos ver sus pedidos y le damos click en buscar
Comsultar pedido: Damos doble click en un pedido y asi podremos ver los productos de ese pedido
Eliminar Pedido: permite eliminar un pedido seleccionado
