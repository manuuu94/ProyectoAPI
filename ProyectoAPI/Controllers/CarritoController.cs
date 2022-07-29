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
    public class CarritoController : ApiController
    {
        CarritoModel modelo = new CarritoModel();

        [HttpPost]
        [Route("api/AñadirCarrito")]
        public bool AñadirCarrito(carro carrito)
        {
            try
            {
                return modelo.AñadirCarrito(carrito);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("api/AñadirCarrito2")]
        public bool AñadirCarrito2(string descripcion, decimal precio, int cantidad, int id_producto)
        {
            try
            {
                return modelo.AñadirCarrito2(descripcion, precio, cantidad, id_producto);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("api/mostrarCarrito")]
        public List<carro> mostrarCarrito()
        {
            try
            {
                return modelo.mostrarCarrito();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpDelete]
        [Route("api/EliminarProductoCarrito")]
        public bool EliminarProductoCarrito(int ID_PROD)
        {
            try
            {
                return modelo.EliminarProductoCarrito(ID_PROD);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("api/VaciarCarrito")]
        public bool VaciarCarrito()
        {
            try
            {
                return modelo.vaciarCarrito();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        


    }
}
