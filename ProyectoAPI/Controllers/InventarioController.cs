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
    public class InventarioController : ApiController
    {
        InventarioModel modelo = new InventarioModel();

        [HttpGet]
        [Route("api/ConsultarInventario")]
        public List<Inventario> ConsultarInventario()
        {
            try
            {
                return modelo.ConsultarInventario();
            }
            catch (Exception)
            {
                return null;
            }
        }


        [HttpGet]
        [Route("api/ConsultarProducto")]
        public Inventario ConsultarProducto(int ID_PRODUCTO)
        {
            try
            {
                return modelo.ConsultarProducto(ID_PRODUCTO);
            }
            catch (Exception)
            {
                return null;
            }
        }


        [HttpPost]
        [Route("api/RegistrarProducto")]
        public bool RegistrarProducto(Inventario producto)
        {
            try
            {
                return modelo.RegistrarProducto(producto);
            }
            catch (Exception)
            {
                return false;
            }
        }
        /*{
        "DESCRIPCION":"PRUEBA2",
        "PRECIO":10,
        "CANTIDAD_DISPONIBLE":2,
        "URL_IMAGE":"URLIMAGE2",
        "ID_SERVICIO":2
        }*/

        [HttpPut]
        [Route("api/ActualizarInventario")]
        public bool ActualizarInventario(Inventario producto)
        {
            try
            {
                return modelo.ActualizarInventario(producto);
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpDelete]
        [Route("api/EliminarProducto")]
        public bool EliminarProducto(int ID_PRODUCTO)
        {
            try
            {
                return modelo.EliminarProducto(ID_PRODUCTO);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("api/VaciarInventario")]
        public bool VaciarInventario()
        {
            try
            {
                return modelo.VaciarInventario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
