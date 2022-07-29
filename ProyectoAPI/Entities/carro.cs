using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Entities
{
    public class carro
    {
        public int ID_PROD { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal PRECIO { get; set; }
        public int CANTIDAD { get; set; }
        public decimal TOTAL { get; set; }
        public int ID_PRODUCTO { get; set; }

        public int ID { get; set; }

    }
}