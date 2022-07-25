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
    public class EmpleadoController : ApiController
    {
        EmpleadoModel modelo = new EmpleadoModel();

        [HttpPost]
        [Route("api/ValidarUsuario")]
        public Empleado ValidarUsuario(Empleado empleado)
        {
            try
            {
                return modelo.ValidarUsuario(empleado);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/RecuperarContraseña")]
        public ResPass RecuperarContraseña(ResPass respass)
        {
            try
            {
                return modelo.RecuperarContraseña(respass);
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
