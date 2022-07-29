using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Entities
{
    public class Registros
    {
        public int ID_COMPRA { get; set; }
        public string CEDULA_CLIENTE { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string CORREO { get; set; }
        public string TELEFONO { get; set; }
        public DateTime FECHA { get; set; }
        public decimal TOTAL_COMPRA { get; set; }
        public int ID_METODO { get; set; }
        public int ID_EMPLEADO { get; set; }    
        public string NOMBRE_EMPLEADO { get; set; }

    }
}