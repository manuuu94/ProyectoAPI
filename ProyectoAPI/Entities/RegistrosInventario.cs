using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Entities
{
    public class RegistrosInventario
    {
        public int ID { get; set; }
        public string ACCION { get; set; }
        public string DESCRIPCION { get; set; }
        public int CANTIDAD { get; set; }
        public DateTime FECHA { get; set; }
        public int ID_SERVICIO { get; set; }


    }
}