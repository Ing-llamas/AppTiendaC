using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using WebApiCRUD.Models;

namespace WebApiCRUD.Data
{
    public class PedidosData
    {


        //Crear un pedido
        public static bool insertarPedido(Pedido oPedido)
        {
            try
            {
                Conexion.abrir();
                // para insertar editar o eliminar de trabaja sqlCommand
                SqlCommand cmd = new SqlCommand("insertar_pedido", Conexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Total", oPedido.Total);
                cmd.Parameters.AddWithValue("@Cedula", oPedido.Cedula);
                cmd.Parameters.AddWithValue("@Direccion", oPedido.Direccion);
      
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
          
                return false;

            }

            finally
            {
                Conexion.cerrar();
            }
        }

        public static bool eliminarPedido(int Id)
        {
            try
            {
                Conexion.abrir();
                // para insertar editar o eliminar de trabaja sqlCommand
                SqlCommand cmd = new SqlCommand("eliminar_pedido", Conexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
           

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }

            finally
            {
                Conexion.cerrar();
            }
        }


    }
}