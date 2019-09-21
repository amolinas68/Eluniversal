using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTiendaWeb.Models
{
    public class ArticuloModel
    {
        public int IdArticulo { get; set; }
        public string Articulo { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
        public char Activo { get; set; }
    }
}