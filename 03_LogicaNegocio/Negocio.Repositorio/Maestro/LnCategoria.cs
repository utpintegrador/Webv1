using Entidad.Dto.Maestro;
using System.Collections.Generic;

namespace Negocio.Repositorio.Maestro
{
    public class LnCategoria
    {
        public List<CategoriaObtenerDto> Obtener(CategoriaObtenerFiltroDto filtro)
        {
            List<CategoriaObtenerDto> lista = new List<CategoriaObtenerDto>();
            lista.Add(new CategoriaObtenerDto
            {
                IdCategoria = 1,
                Descripcion = "Categoria 1",
                Estado = "Activo",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/1.jpg"
            });

            lista.Add(new CategoriaObtenerDto
            {
                IdCategoria = 2,
                Descripcion = "Categoria 2",
                Estado = "Activo",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/2.jpg"
            });

            lista.Add(new CategoriaObtenerDto
            {
                IdCategoria = 3,
                Descripcion = "Categoria 3",
                Estado = "Activo",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/3.jpg"
            });

            lista.Add(new CategoriaObtenerDto
            {
                IdCategoria = 4,
                Descripcion = "Categoria 4",
                Estado = "Activo",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/4.jpg"
            });

            lista.Add(new CategoriaObtenerDto
            {
                IdCategoria = 5,
                Descripcion = "Categoria 5",
                Estado = "Activo",
                UrlImagen = "https://encuentralo.s3.us-east-2.amazonaws.com/Categoria/5.jpg"
            });

            return lista;
        }
    }
}
