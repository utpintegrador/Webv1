using Entidad.Dto.Maestro;
using Entidad.Dto.Transaccion;
using System.Collections.Generic;

namespace Negocio.Repositorio.Transaccion
{
    public class LnPasarelaProducto
    {
        public List<ProductoObtenerPasarelaDto> ObtenerProductos()
        {
            List<ProductoObtenerPasarelaDto> lista = new List<ProductoObtenerPasarelaDto>();
            lista.Add(new ProductoObtenerPasarelaDto
            {
                IdProducto = 1,
                Descripcion = "Descripcion del producto",
                DescripcionExtendida = "Empaque de 1Kg",
                SimboloMoneda = "S/.",
                Precio = 4.5M,
                IdNegocio = 1,
                NombreNegocio = "Nombre Vendedor",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/5.jpg"
            });

            lista.Add(new ProductoObtenerPasarelaDto
            {
                IdProducto = 2,
                Descripcion = "Descripcion del producto",
                DescripcionExtendida = "Empaque de 1Kg",
                SimboloMoneda = "S/.",
                Precio = 4.5M,
                IdNegocio = 2,
                NombreNegocio = "Nombre Vendedor",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/1.jpg"
            });

            lista.Add(new ProductoObtenerPasarelaDto
            {
                IdProducto = 3,
                Descripcion = "Descripcion del producto",
                DescripcionExtendida = "Empaque de 1Kg",
                SimboloMoneda = "S/.",
                Precio = 4.5M,
                IdNegocio = 3,
                NombreNegocio = "Nombre Vendedor",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/3.jpg"
            });

            lista.Add(new ProductoObtenerPasarelaDto
            {
                IdProducto = 4,
                Descripcion = "Descripcion del producto",
                DescripcionExtendida = "Empaque de 1Kg",
                SimboloMoneda = "S/.",
                Precio = 4.5M,
                IdNegocio = 4,
                NombreNegocio = "Nombre Vendedor",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/4.jpg"
            });

            lista.Add(new ProductoObtenerPasarelaDto
            {
                IdProducto = 5,
                Descripcion = "Descripcion del producto",
                DescripcionExtendida = "Empaque de 1Kg",
                SimboloMoneda = "S/.",
                Precio = 4.5M,
                IdNegocio = 5,
                NombreNegocio = "Nombre Vendedor",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/2.jpg"
            });

            lista.Add(new ProductoObtenerPasarelaDto
            {
                IdProducto = 6,
                Descripcion = "Descripcion del producto",
                DescripcionExtendida = "Empaque de 1Kg",
                SimboloMoneda = "S/.",
                Precio = 4.5M,
                IdNegocio = 6,
                NombreNegocio = "Nombre Vendedor",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/5.jpg"
            });

            return lista;
        }

        public CarroItemObtenerPorIdDto ObtenerPorId(long id)
        {
            List<CarroItemImagenObtener> listaImagen = new List<CarroItemImagenObtener>();
            //Predeterminado = true es quien estará como activo
            listaImagen.Add(new CarroItemImagenObtener
            {
                Indice = 0,
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/1.jpg",
                Descripcion = "Primera descripcion",
                Predeterminado = true
            });

            listaImagen.Add(new CarroItemImagenObtener
            {
                Indice = 1,
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/2.jpg",
                Descripcion = "Segunda descripcion",
                Predeterminado = false
            });

            listaImagen.Add(new CarroItemImagenObtener
            {
                Indice = 2,
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/3.jpg",
                Descripcion = "Tercera descripcion",
                Predeterminado = false
            });

            listaImagen.Add(new CarroItemImagenObtener
            {
                Indice = 3,
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/4.jpg",
                Descripcion = "Cuarta descripcion",
                Predeterminado = false
            });

            listaImagen.Add(new CarroItemImagenObtener
            {
                Indice = 4,
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/5.jpg",
                Descripcion = "Quinta descripcion",
                Predeterminado = false
            });

            CarroItemObtenerPorIdDto item = new CarroItemObtenerPorIdDto
            {
                Descripcion = "Esta es la descripcion principal",
                DescripcionExtendida = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                Categoria = "Panaderia",
                Moneda = "Sol",
                Negocio = "Tambo",
                Precio = 4563.14M,
                ListaImagen = listaImagen
            };

            return item;
        }
    }
}
