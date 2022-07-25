using ProyectoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Models
{
    public class RegistroModel
    {

        /* Añade un registro de la compra que incluye un ID, Cedula, nombre, correo, teléfono del cliente,
         * la fecha de la compra y el total del carrito.
         * Muestra todos los registros de compras completadas.
         * No muestra los productos que se incluían en el carrito. 
         * Solicita el ID al empleado y su nombre.
         * Permite que el nombre, correo y telefono del cliente sean en blanco.
         * El nombre del empleado tambien puede estar en blanco.
         * 
         */
        public string ConfirmaCompra(Registros registros)
        {
            if (validaCarrito())
            {
                if (registros.CEDULA_CLIENTE != null)
                {
                    using (var conexion = new PROYECTO_PAEntities())
                    {
                        try
                        {
                            //if que valide si la cedula existe. si existe, permitir campos en blanco.
                            //si no existe, pedir NOMBRE CORREO TELEFONO del cliente.
                            var datosclientes = (from x in conexion.CLIENTES_ATENDIDOS
                                                 where x.CEDULA_CLIENTE == registros.CEDULA_CLIENTE
                                                 select x).ToList();
                            if (datosclientes.Count == 0 && registros.NOMBRE_CLIENTE != null & registros.CORREO != null
                                    && registros.TELEFONO != null)
                            {
                                var datos = (from x in conexion.CARRITO
                                             select x).ToList();
                                if (datos != null)
                                {
                                    decimal TOTAL_COMPRA = 0;
                                    foreach (var dato in datos)
                                    {
                                        TOTAL_COMPRA = TOTAL_COMPRA + dato.TOTAL;
                                    }
                                    REGISTRO_COMPRAS registro = new REGISTRO_COMPRAS();
                                    registro.CEDULA_CLIENTE = registros.CEDULA_CLIENTE;
                                    registro.NOMBRE_CLIENTE = registros.NOMBRE_CLIENTE;
                                    registro.CORREO = registros.CORREO;
                                    registro.TELEFONO = registros.TELEFONO;
                                    registro.FECHA = DateTime.Now;
                                    registro.TOTAL_COMPRA = TOTAL_COMPRA;
                                    registro.ID_EMPLEADO = registros.ID_EMPLEADO;
                                    registro.NOMBRE_EMPLEADO = registros.NOMBRE_EMPLEADO;
                                    conexion.REGISTRO_COMPRAS.Add(registro);
                                    CLIENTES_ATENDIDOS clientes_atendidos = new CLIENTES_ATENDIDOS();
                                    clientes_atendidos.CEDULA_CLIENTE = registros.CEDULA_CLIENTE;
                                    clientes_atendidos.NOMBRE_CLIENTE = registros.NOMBRE_CLIENTE;
                                    clientes_atendidos.CORREO = registros.CORREO;
                                    clientes_atendidos.TELEFONO = registros.TELEFONO;
                                    clientes_atendidos.FECHA = DateTime.Now;
                                    clientes_atendidos.ID_COMPRA = registro.ID_COMPRA;
                                    conexion.CLIENTES_ATENDIDOS.Add(clientes_atendidos);
                                    conexion.SaveChanges();
                                    vaciarCarrito();
                                    return "Compra Confirmada - cliente registrado con éxito";
                                }
                            }
                            if (datosclientes.Count > 0)
                            {
                                var datos = (from x in conexion.CARRITO
                                             select x).ToList();
                                if (datos != null)
                                {
                                    decimal TOTAL_COMPRA = 0;
                                    foreach (var dato in datos)
                                    {
                                        TOTAL_COMPRA = TOTAL_COMPRA + dato.TOTAL;
                                    }
                                    REGISTRO_COMPRAS registro = new REGISTRO_COMPRAS();
                                    registro.CEDULA_CLIENTE = registros.CEDULA_CLIENTE;
                                    registro.NOMBRE_CLIENTE = registros.NOMBRE_CLIENTE;
                                    registro.CORREO = registros.CORREO;
                                    registro.TELEFONO = registros.TELEFONO;
                                    registro.FECHA = DateTime.Now;
                                    registro.TOTAL_COMPRA = TOTAL_COMPRA;
                                    registro.ID_EMPLEADO = registros.ID_EMPLEADO;
                                    registro.NOMBRE_EMPLEADO = registros.NOMBRE_EMPLEADO;
                                    conexion.REGISTRO_COMPRAS.Add(registro);
                                    CLIENTES_ATENDIDOS clientes_atendidos = new CLIENTES_ATENDIDOS();
                                    clientes_atendidos.CEDULA_CLIENTE = registros.CEDULA_CLIENTE;
                                    clientes_atendidos.NOMBRE_CLIENTE = registros.NOMBRE_CLIENTE;
                                    clientes_atendidos.CORREO = registros.CORREO;
                                    clientes_atendidos.TELEFONO = registros.TELEFONO;
                                    clientes_atendidos.FECHA = DateTime.Now;
                                    clientes_atendidos.ID_COMPRA = registro.ID_COMPRA;
                                    conexion.CLIENTES_ATENDIDOS.Add(clientes_atendidos);
                                    conexion.SaveChanges();
                                    vaciarCarrito();
                                    return "Compra Confirmada - cliente existente";
                                }
                            }
                            if (datosclientes.Count == 0 && registros.NOMBRE_CLIENTE == null || registros.CORREO == null
                                || registros.TELEFONO == null)
                            {
                                return "Complete Nombre, Correo y Teléfono del cliente para confirmar la compra";
                            }
                            else
                            {
                                return "Ingrese cédula del cliente y su ID de empleado";
                            }
                        }
                        catch (Exception ex)
                        {
                            conexion.Dispose();
                            throw ex;
                        }
                    }
                }
                else
                {
                    return "Ingrese cédula del cliente y su ID de empleado";
                }
            }
            else
            {
                return "El carrito está vacío";
            }
        }
    
        public List<Registros> ConsultarRegistros()
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.REGISTRO_COMPRAS
                                 select x).ToList();
                    List<Registros> lista = new List<Registros>();
                    foreach (var dato in datos)
                    {
                        lista.Add(new Registros
                        {
                        ID_COMPRA = dato.ID_COMPRA,
                        CEDULA_CLIENTE = dato.CEDULA_CLIENTE,
                        NOMBRE_CLIENTE = dato.NOMBRE_CLIENTE,
                        CORREO = dato.CORREO,
                        TELEFONO = dato.TELEFONO,
                        FECHA = (DateTime)dato.FECHA,
                        TOTAL_COMPRA = (decimal)dato.TOTAL_COMPRA,
                        ID_EMPLEADO = dato.ID_EMPLEADO,
                        NOMBRE_EMPLEADO = dato.NOMBRE_EMPLEADO
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

        public void vaciarCarrito()
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.CARRITO
                                 select x).ToList();
                        foreach (var dato in datos)
                        {
                            conexion.CARRITO.Remove(dato);
                        }
                        conexion.SaveChanges();
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        }
        public bool validaCarrito()
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.CARRITO
                                 select x).ToList();
                    if(datos.Count == 0)
                    {
                        return false;
                    }
                    else {
                        return true;
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

//hace falta que vacie el carrito despues de confirmar una compra
//hace falta que valide que el carrito no está vacio si quiere confirmar la compra

/*
{
    "CEDULA_CLIENTE":1234299999,
    "NOMBRE_CLIENTE":"PRUEBA1",
    "CORREO":"CORREO@PRUEBA.COM",
    "TELEFONO":"12342423",
    "ID_EMPLEADO":1
}
*/