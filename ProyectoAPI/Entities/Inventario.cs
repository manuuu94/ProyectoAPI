using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Entities
{
    public class Inventario
    {
        public int ID_PRODUCTO { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal PRECIO { get; set; }
        public int CANTIDAD_DISPONIBLE { get; set; }
        public string URL_IMAGE { get; set; }
        public int ID_SERVICIO { get; set; }




        //public int ID { get; set; }
        //public int CANTIDAD { get; set; }
    }
}