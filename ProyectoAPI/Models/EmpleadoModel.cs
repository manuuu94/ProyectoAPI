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

        public List<Empleado> ConsultarEmpleados()
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.EMPLEADOS
                                 select x).ToList();
                    List<Empleado> lista = new List<Empleado>();
                    foreach (var dato in datos)
                    {
                        lista.Add(new Empleado
                        {
                            ID_EMPLEADO = dato.ID_EMPLEADO,
                            NOMBRE = dato.NOMBRE,
                            APELLIDO1 = dato.APELLIDO1,
                            APELLIDO2 = dato.APELLIDO2,
                            USERNAME = dato.USERNAME,
                            PASSWORD = null,
                            FECHA_INGRESO = dato.FECHA_INGRESO,
                            ID_ROL = dato.ID_ROL,
                            CORREO = dato.CORREO
                        });
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        }

        public bool ActualizarEmpleado(Empleado empleado)
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.EMPLEADOS
                                 where x.ID_EMPLEADO == empleado.ID_EMPLEADO
                                 select x).FirstOrDefault();
                    if (datos != null)
                    {
                        datos.NOMBRE = empleado.NOMBRE;
                        datos.APELLIDO1 = empleado.APELLIDO1;
                        datos.APELLIDO2 = empleado.APELLIDO2;
                        datos.USERNAME = empleado.USERNAME;
                        // datos.PASSWORD = null;
                        datos.FECHA_INGRESO = empleado.FECHA_INGRESO;
                        datos.ID_ROL = empleado.ID_ROL;
                        datos.CORREO = empleado.CORREO;

                        conexion.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;

                }
            }
        }
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

        public ResPass RecuperarContraseña(ResPass respass)
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.EMPLEADOS
                                 where x.USERNAME == respass.USERNAME
                                 select x).FirstOrDefault();
                    if (datos != null)
                    {
                        respass = new ResPass();
                        respass.USERNAME = datos.USERNAME;
                        respass.PASSWORD = null;
                        respass.CORREO = datos.CORREO;
                        return respass;
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