using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCRUD.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }


    }
}