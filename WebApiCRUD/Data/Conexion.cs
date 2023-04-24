using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace WebApiCRUD.Data
{
    public class Conexion
    {

        public static SqlConnection conexion = new SqlConnection(@"Data Source=ING-LLAMAS;Initial Catalog=Tienda_Comiclandia;Persist Security Info=True;User ID=sa;Password=oscar1012");
        public static void abrir()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
                //  MessageBox.Show("CONEXION ABIERTA");
            }

        }
        public static void cerrar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                //   MessageBox.Show("CONEXION CERRADA");
            }

        }

    }
}