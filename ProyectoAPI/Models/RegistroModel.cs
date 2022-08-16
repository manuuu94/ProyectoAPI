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
                if (registros.CEDULA_CLIENTE != null && registros.ID_EMPLEADO != 0)
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

                            if (datosclientes.Count == 0 && registros.NOMBRE_CLIENTE != null && registros.CORREO != null
                                    && registros.TELEFONO != null && (registros.ID_METODO == 1 || registros.ID_METODO ==2))
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
                                    registro.ID_METODO = registros.ID_METODO;
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

                            if (datosclientes.Count > 0 && (registros.ID_METODO == 1 || registros.ID_METODO == 2))
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
                                    registro.ID_METODO = registros.ID_METODO;
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
                                || registros.TELEFONO == null || registros.ID_METODO != 1 || registros.ID_METODO != 2)
                            {
                                return "Complete Nombre, Correo, " +
                                    "Teléfono del cliente y un Método de pago, para confirmar la compra";
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
    
        public List<Registros> ConsultarRegistrosCompras()
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
                        ID_METODO = (int)dato.ID_METODO,
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

        //vaciar carrito que no mueve las cantidades del inventario
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

        public List<RegistrosInventario> ConsultarRegistrosInventario()
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.REGISTROS_INVENTARIO
                                 select x).ToList();
                    List<RegistrosInventario> lista = new List<RegistrosInventario>();
                    foreach (var dato in datos)
                    {
                        lista.Add(new RegistrosInventario
                        {
                            ID = dato.ID,
                            ACCION = dato.ACCION,
                            DESCRIPCION = dato.DESCRIPCION,
                            CANTIDAD = (int)dato.CANTIDAD,
                            FECHA = (DateTime)dato.FECHA,
                            ID_SERVICIO = (int)dato.ID_SERVICIO,
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

        public List<Cliente> ConsultarRegistroClientesAtendidos()
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.CLIENTES_ATENDIDOS
                                 select x).ToList();

                    List<Cliente> lista = new List<Cliente>();
                    
                    foreach (var dato in datos)
                    {
                        lista.Add(new Cliente
                        {
                            ID_CLIENTE = dato.ID_CLIENTE,
                            CEDULA_CLIENTE = dato.CEDULA_CLIENTE,
                            NOMBRE_CLIENTE = dato.NOMBRE_CLIENTE,
                            CORREO = dato.CORREO,
                            TELEFONO = dato.TELEFONO,
                            FECHA = (DateTime)dato.FECHA,
                            ID_COMPRA = (int)dato.ID_COMPRA,
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

    }
}

/*
{
    "CEDULA_CLIENTE":1234299999,
    "NOMBRE_CLIENTE":"PRUEBA1",
    "CORREO":"CORREO@PRUEBA.COM",
    "TELEFONO":"12342423",
    "ID_EMPLEADO":1
}
*/