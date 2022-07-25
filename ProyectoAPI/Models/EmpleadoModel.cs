using ProyectoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace ProyectoAPI.Models
{
    public class EmpleadoModel
    {
            public Empleado ValidarUsuario(Empleado empleado)
            {
                using (var conexion = new PROYECTO_PAEntities())
                {
                    try
                    {
                    var datos = conexion.validarUsuario
                        (empleado.USERNAME, empleado.PASSWORD).FirstOrDefault();

                       if (datos != null)
                       {
                            empleado = new Empleado();

                            empleado.USERNAME = datos.USERNAME;
                            empleado.ID_ROL = datos.ID_ROL;
                            empleado.NOMBRE = datos.NOMBRE;
                            empleado.PASSWORD = null;
                            empleado.APELLIDO1 = datos.APELLIDO1;

                        return empleado;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        conexion.Dispose();
                        throw ex;
                    }
                }
            }




        }

    }