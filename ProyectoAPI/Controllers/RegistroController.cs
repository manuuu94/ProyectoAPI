using ProyectoAPI.Entities;
using ProyectoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoAPI.Controllers
{
    public class RegistroController : ApiController
    {
        RegistroModel modelo = new RegistroModel();

        [HttpPost]
        [Route("api/ConfirmaCompra")]
        public string ConfirmaCompra(Registros registros)
        {
            try
            {
                return modelo.ConfirmaCompra(registros);
            }
            catch (Exception)
            {
                return "Ingrese cédula del cliente y su ID de empleado";
            }
        }

        [HttpGet]
        [Route("api/ConsultarRegistrosCompras")]
        public List<Registros> ConsultarRegistrosCompras()
        {
            try
            {
                return modelo.ConsultarRegistrosCompras();
            }
            catch (Exception)
            {
                return null;
            }
        }


        [HttpGet]
        [Route("api/ConsultarRegistrosInventario")]
        public List<RegistrosInventario> ConsultarRegistrosInventario()
        {
            try
            {
                return modelo.ConsultarRegistrosInventario();
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
/*
CEDULA_CLIENTE INT NOT NULL,
NOMBRE_CLIENTE VARCHAR(50),
CORREO VARCHAR(100),
TELEFONO VARCHAR(100),
FECHA DATE,
TOTAL_COMPRA DECIMAL(10,2),
ID_EMPLEADO INT NOT NULL,
NOMBRE_EMPLEADO VARCHAR(50),
*/