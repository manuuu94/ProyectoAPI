using ProyectoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Models
{
    public class CarritoModel
    {
/* Permite añadir al carrito, mostrar el carrito, eliminar un solo producto del carrito
 * o vaciar completamente el carrito. 
 * Cuando añade o elimina del carrito, siempre se va a actualizar automáticamente 
 * la cantidad disponible en el inventario. 
 * No permite añadir productos que no tienen cantidad disponible suficiente en el inventario.
 * 
 */

 /*       public string AñadirCarrito(carro carrito)
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {                    
                    var datos = (from x in conexion.INVENTARIO_SERVICIOS
                                   where x.ID_PRODUCTO == carrito.ID_PROD
                                   select x).FirstOrDefault();
                    if (datos.CANTIDAD_DISPONIBLE >= carrito.CANTIDAD && datos != null && 
                        datos.CANTIDAD_DISPONIBLE != 0 && carrito.CANTIDAD > 0)
                {
                        datos.CANTIDAD_DISPONIBLE = datos.CANTIDAD_DISPONIBLE - carrito.CANTIDAD;

                        CARRITO carro = new CARRITO();
                        carro.DESCRIPCION = datos.DESCRIPCION;
                        carro.PRECIO = datos.PRECIO;
                        carro.CANTIDAD = carrito.CANTIDAD;
                        carro.TOTAL = carro.PRECIO * carro.CANTIDAD;
                        carro.ID_PRODUCTO = datos.ID_PRODUCTO;
                        conexion.CARRITO.Add(carro);
                        conexion.SaveChanges();
                        
                        return "Producto añadido";
                    }
                    else
                    {
                        return "Error";
                    }
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        } */
        public bool AñadirCarrito2(string descripcion, decimal precio, int cantidad, int id_producto)
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.INVENTARIO_SERVICIOS
                                 where x.ID_PRODUCTO == id_producto
                                 select x).FirstOrDefault();
                    if (datos.CANTIDAD_DISPONIBLE >= cantidad && datos != null &&
                        datos.CANTIDAD_DISPONIBLE != 0 && cantidad > 0)
                    {
                        datos.CANTIDAD_DISPONIBLE = datos.CANTIDAD_DISPONIBLE - cantidad;

                        CARRITO carro = new CARRITO();
                        carro.DESCRIPCION = datos.DESCRIPCION;
                        carro.PRECIO = datos.PRECIO;
                        carro.CANTIDAD = cantidad;
                        carro.TOTAL = carro.PRECIO * carro.CANTIDAD;
                        carro.ID_PRODUCTO = datos.ID_PRODUCTO;
                        conexion.CARRITO.Add(carro);
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
        public List<carro> mostrarCarrito()
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.CARRITO
                                 select x).ToList();
                    List<carro> listacarrito = new List<carro>();
                    foreach (var dato in datos)
                    {
                        listacarrito.Add(new carro
                        {
                            ID_PROD = dato.ID_PROD,
                            DESCRIPCION = dato.DESCRIPCION,
                            PRECIO = dato.PRECIO,
                            CANTIDAD = dato.CANTIDAD,
                            TOTAL = dato.TOTAL,
                            ID_PRODUCTO = dato.ID_PRODUCTO,
                        });
                    }
                    return listacarrito;
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        }
        public bool EliminarProductoCarrito(int ID_PROD)
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.CARRITO
                                 where x.ID_PROD == ID_PROD
                                 select x).FirstOrDefault();
                    if (datos != null)
                    {
                    var datosx = (from x in conexion.INVENTARIO_SERVICIOS
                                   where x.ID_PRODUCTO == datos.ID_PRODUCTO
                                   select x).FirstOrDefault();
                        datosx.CANTIDAD_DISPONIBLE = datosx.CANTIDAD_DISPONIBLE + datos.CANTIDAD;
                        conexion.CARRITO.Remove(datos);
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
        //llama procedimiento almacenado que vacía el carrito
        public bool vaciarCarrito()
        {
            using (var conexion = new PROYECTO_PAEntities())
            {
                try
                {
                    var datos = (from x in conexion.CARRITO
                                 select x).ToList();
                    if (datos.Count != 0)
                    {
                        foreach (var dato in datos)
                        {
                        var datosx = (from x in conexion.INVENTARIO_SERVICIOS
                                      where x.ID_PRODUCTO == dato.ID_PRODUCTO
                                      select x).FirstOrDefault();
                        datosx.CANTIDAD_DISPONIBLE = datosx.CANTIDAD_DISPONIBLE + dato.CANTIDAD;
                        conexion.CARRITO.Remove(dato);
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