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

        [HttpPut]
        [Route("api/CambiarContraseña")]
        public bool CambiarContraseña(ResPass resPass)
        {
            try
            {
                return modelo.CambiarContraseña(resPass);
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpGet]
        [Route("api/ConsultarEmpleados")]
        public List<Empleado> ConsultarEmpleados()
        {
            try
            {
                return modelo.ConsultarEmpleados();
            }
            catch (Exception)
            {
                return null;
            }
        }


        [HttpGet]
        [Route("api/ConsultarEmpleado")]
        public Empleado ConsultarEmpleado(int ID_EMPLEADO)
        {
            try
            {
                return modelo.ConsultarEmpleado(ID_EMPLEADO);
            }
            catch (Exception)
            {
                return null;
            }
        }


        [HttpPut]
        [Route("api/ActualizarEmpleado")]
        public bool ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                return modelo.ActualizarEmpleado(empleado);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("api/EliminarEmpleado")]
        public bool EliminarEmpleado(int ID_EMPLEADO)
        {
            try
            {
                return modelo.EliminarEmpleado(ID_EMPLEADO);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/RegistrarEmpleado")]
        public bool RegistrarEmpleado(Empleado empleado)
        {
            try
            {
                return modelo.RegistrarEmpleado(empleado);
            }
            catch (Exception)
            {
                return false;
            }
        }




    }
}
