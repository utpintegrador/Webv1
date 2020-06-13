using Entidad.Dto.Maestro;
using System.Collections.Generic;

namespace Negocio.Repositorio.Maestro
{
    public class LnProducto
    {
        public List<ProductoObtenerDto> ObtenerListadoPorIdUsuario(ProductoObtenerFiltroDto filtro)
        {
            List<ProductoObtenerDto> lista = new List<ProductoObtenerDto>();
            lista.Add(new ProductoObtenerDto
            {
                IdProducto = 1,
                Descripcion = "Producto 1",
                DescripcionExtendida = "Descripcion extendida 1",
                Precio = 4.5M,
                Estado = "Activo",
                Moneda = "Sol",
                Categoria = "Categoria 1",
                Negocio = "Negocio 1",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/1.jpg"
            });

            lista.Add(new ProductoObtenerDto
            {
                IdProducto = 2,
                Descripcion = "Producto 2",
                DescripcionExtendida = "Descripcion extendida 2",
                Precio = 5.9M,
                Estado = "Activo",
                Moneda = "Sol",
                Categoria = "Categoria 1",
                Negocio = "Negocio 1",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/2.jpg"
            });

            lista.Add(new ProductoObtenerDto
            {
                IdProducto = 3,
                Descripcion = "Producto 3",
                DescripcionExtendida = "Descripcion extendida 3",
                Precio = 1.2M,
                Estado = "Activo",
                Moneda = "Sol",
                Categoria = "Categoria 1",
                Negocio = "Negocio 1",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/3.jpg"
            });

            lista.Add(new ProductoObtenerDto
            {
                IdProducto = 4,
                Descripcion = "Producto 4",
                DescripcionExtendida = "Descripcion extendida 4",
                Precio = 3.6M,
                Estado = "Activo",
                Moneda = "Sol",
                Categoria = "Categoria 1",
                Negocio = "Negocio 1",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/4.jpg"
            });

            lista.Add(new ProductoObtenerDto
            {
                IdProducto = 5,
                Descripcion = "Producto 5",
                DescripcionExtendida = "Descripcion extendida 5",
                Precio = 0.1M,
                Estado = "Activo",
                Moneda = "Sol",
                Categoria = "Categoria 1",
                Negocio = "Negocio 1",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/5.jpg"
            });

            return lista;
        }
    }
}
