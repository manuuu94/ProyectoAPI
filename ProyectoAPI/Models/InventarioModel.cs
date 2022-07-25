using ProyectoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Models
{
    public class InventarioModel
    {
/* Muestra todo el inventario, un solo producto por ID, registrar un Producto nuevo,
 * actualizar productos existentes manteniendo sus ID, eliminar un producto por ID,
 * o vaciar completamente el inventario. 
 * El Inventario incluye un ID, una descripcion, precio, cantidad disponible y a qué
 * departamento de la tienda pertenece la oferta. 
 */

        //ConsultarInventario: Devuelve una lista de la tabla inventario_servicios
        public List<Inventario> ConsultarInventario()
        {
            using (var conexion = new PROYECTO_PAEntities()) 
            {
                try
                {
                    var datos = (from x in conexion.INVENTARIO_SERVICIOS
                                 select x).ToList();    
                    List<Inventario> lista = new List<Inventario>();
                    foreach (var dato in datos)
                    {
                        lista.Add(new Inventario{
                            ID_PRODUCTO = dato.ID_PRODUCTO,
                            DESCRIPCION = dato.DESCRIPCION,
                            PRECIO = dato.PRECIO,
                            CANTIDAD_DISPONIBLE = dato.CANTIDAD_DISPONIBLE,
                            URL_IMAGE = dato.URL_IMAGE,
                            ID_SERVICIO = dato.ID_SERVICIO,
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
        //ConsultarProducto: devuelve un producto por codigo
        public Inventario ConsultarProducto(int ID_PRODUCTO)
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.INVENTARIO_SERVICIOS
                                 where x.ID_PRODUCTO == ID_PRODUCTO
                                 select x).FirstOrDefault();
                    if (datos != null)
                    {
                        var producto = new Inventario();
                        producto.ID_PRODUCTO = datos.ID_PRODUCTO;
                        producto.DESCRIPCION= datos.DESCRIPCION;
                        producto.PRECIO = datos.PRECIO;
                        producto.CANTIDAD_DISPONIBLE = datos.CANTIDAD_DISPONIBLE;
                        producto.URL_IMAGE = datos.URL_IMAGE;
                        producto.ID_SERVICIO = datos.ID_SERVICIO;
                        return producto;
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
        public bool RegistrarProducto(Inventario producto)
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    INVENTARIO_SERVICIOS inventario_servicios = new INVENTARIO_SERVICIOS();
                    inventario_servicios.ID_PRODUCTO = producto.ID_SERVICIO;
                    inventario_servicios.DESCRIPCION = producto.DESCRIPCION;
                    inventario_servicios.PRECIO = producto.PRECIO;
                    inventario_servicios.CANTIDAD_DISPONIBLE = producto.CANTIDAD_DISPONIBLE;
                    inventario_servicios.URL_IMAGE = producto.URL_IMAGE;
                    inventario_servicios.ID_SERVICIO = producto.ID_SERVICIO;
                    conexion.INVENTARIO_SERVICIOS.Add(inventario_servicios);
                    conexion.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        }
        public bool ActualizarInventario(Inventario producto)
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.INVENTARIO_SERVICIOS
                                 where x.ID_PRODUCTO == producto.ID_PRODUCTO
                                 select x).FirstOrDefault();
                    if (datos != null)
                    {
                        datos.DESCRIPCION = producto.DESCRIPCION;
                        datos.PRECIO = producto.PRECIO;
                        datos.CANTIDAD_DISPONIBLE = producto.CANTIDAD_DISPONIBLE;
                        datos.URL_IMAGE = producto.URL_IMAGE;
                        datos.ID_SERVICIO = producto.ID_SERVICIO;
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
        public bool EliminarProducto(int ID_PRODUCTO)
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.INVENTARIO_SERVICIOS
                                 where x.ID_PRODUCTO == ID_PRODUCTO
                                 select x).FirstOrDefault();
                    if (datos != null)
                    {
                        conexion.INVENTARIO_SERVICIOS.Remove(datos);
                        conexion.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No existe");
                    }
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        }
        public bool VaciarInventario()
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.INVENTARIO_SERVICIOS
                                 select x).ToList();
                    if (datos.Count != 0)
                    {
                        foreach (var dato in datos) {
                            conexion.INVENTARIO_SERVICIOS.Remove(dato);
                        }
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












    }
}