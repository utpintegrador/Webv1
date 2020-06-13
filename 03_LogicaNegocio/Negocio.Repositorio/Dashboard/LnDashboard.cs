using Entidad.Dto.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Repositorio.Dashboard
{
    public class LnDashboard
    {
        public List<DashboardResumenDto> ObtenerCabecera(long idUsuario)
        {
            List<DashboardResumenDto> lista = new List<DashboardResumenDto>();
            lista.Add(new DashboardResumenDto
            {
                Orden = 1,
                ColorFondo = "bg-primary",
                Icono = "fa fa-television",
                Titulo = "Cantidad productos ofrecidos",
                Valor = 658
            });
            lista.Add(new DashboardResumenDto
            {
                Orden = 2,
                ColorFondo = "bg-success",
                Icono = "fa fa-shopping-cart",
                Titulo = "Cantidad de ventas realizadas",
                Valor = 23
            });
            lista.Add(new DashboardResumenDto
            {
                Orden = 3,
                ColorFondo = "bg-info",
                Icono = "fa fa-star-o",
                Titulo = "Valoracion obtenida como comprador",
                Valor = 4.2M
            });
            lista.Add(new DashboardResumenDto
            {
                Orden = 4,
                ColorFondo = "bg-danger",
                Icono = "fa fa-star-o",
                Titulo = "Valoracion obtenida como vendedor",
                Valor = 1.3M
            });
            return lista;
        }

        #region Grafico 1
        /// <summary>
        /// Grafico 1
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public List<DashboardTotalVentasDto> ObtenerTotalVentas(long idUsuario)
        {
            List<DashboardTotalVentasDto> lista = new List<DashboardTotalVentasDto>();
            lista.Add(new DashboardTotalVentasDto
            {
                Periodo = "12/2019",
                CodigoColorHexadecimal = "#28a745",
                Valor = 2
            });
            lista.Add(new DashboardTotalVentasDto
            {
                Periodo = "01/2020",
                CodigoColorHexadecimal = "#28a745",
                Valor = 1
            });
            lista.Add(new DashboardTotalVentasDto
            {
                Periodo = "02/2020",
                CodigoColorHexadecimal = "#28a745",
                Valor = 3
            });
            lista.Add(new DashboardTotalVentasDto
            {
                Periodo = "03/2020",
                CodigoColorHexadecimal = "#28a745",
                Valor = 5
            });
            lista.Add(new DashboardTotalVentasDto
            {
                Periodo = "04/2020",
                CodigoColorHexadecimal = "#28a745",
                Valor = 4
            });
            lista.Add(new DashboardTotalVentasDto
            {
                Periodo = "05/2020",
                CodigoColorHexadecimal = "#28a745",
                Valor = 2
            });
            return lista;
        }
        #endregion

        #region Grafico 2
        /// <summary>
        /// Grafico 2
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public DashboardProductoRootDto ObtenerProductosTop(long idUsuario, int cantidad)
        {
            DashboardProductoRootDto respuesta = new DashboardProductoRootDto();
            /*******************************************************************************************************************/
            List<DashboardPeriodoOrdenDto> listaPeriodo = new List<DashboardPeriodoOrdenDto>();
            int conteo = 1;
            for (int i = 4; i >= 1; i--)
            {
                DateTime fechaEvaluada = DateTime.Now.AddMonths(i * -1);

                listaPeriodo.Add(new DashboardPeriodoOrdenDto
                {
                    Orden = conteo,
                    Periodo = Entidad.Utilitario.Util.Derecha("0" + fechaEvaluada.Month.ToString(), 2) + "/" + fechaEvaluada.Year.ToString()
                });
                conteo++;
            }

            listaPeriodo = listaPeriodo.OrderBy(x => x.Orden).ToList();
            respuesta.ListaPeriodo = listaPeriodo;
            /*******************************************************************************************************************/
            //Calcular desde cuando debe traer la data
            DateTime fechaInicio = DateTime.Now.AddMonths(-4);
            fechaInicio = new DateTime(fechaInicio.Year, fechaInicio.Month, 1);

            //Obtener la data de productos mas solicitados
            List<DashboardProductoObtenerDto> listaObtenidaDesdeBd = ProductosDummy(idUsuario, cantidad, fechaInicio);
            listaObtenidaDesdeBd = listaObtenidaDesdeBd.OrderBy(x => x.Periodo).ThenBy(x => x.IdProducto).ToList();

            List<DashboardProductoDto> listaProducto = new List<DashboardProductoDto>();
            if (listaObtenidaDesdeBd.Any())
            {
                //Agrupar por productos
                List<long> listaIdProducto = new List<long>();
                listaIdProducto = listaObtenidaDesdeBd.Select(x => x.IdProducto).Distinct().ToList();
                /*
                var colorPrimary = '#007bff';
                var colorSuccess = '#28a745';
                var colorDanger = '#dc3545';
                */
                int iteracionProducto = 1;
                foreach (var idProducto in listaIdProducto)
                {
                    string color = string.Empty;
                    switch (iteracionProducto)
                    {
                        case 1:
                            color = "#007bff";
                            break;
                        case 2:
                            color = "#28a745";
                            break;
                        case 3:
                            color = "#dc3545";
                            break;
                        default:
                            break;
                    }

                    List<DashboardProductoDetalleDto> productoDetalle = (from det in listaObtenidaDesdeBd
                                                                   where det.IdProducto == idProducto
                                                                   orderby det.Periodo
                                                                   select new DashboardProductoDetalleDto
                                                                   {
                                                                       Valor = det.Cantidad,
                                                                       CodigoColorHexadecimal = color
                                                                   }).ToList();

                    DashboardProductoDto productoCabecera = (from cab in listaObtenidaDesdeBd
                                                            where cab.IdProducto == idProducto
                                                            select new DashboardProductoDto
                                                            {
                                                                IdProducto = cab.IdProducto,
                                                                DescripcionProducto = cab.DescripcionProducto,
                                                                ListaValores = productoDetalle
                                                            }).FirstOrDefault();

                    listaProducto.Add(productoCabecera);
                    iteracionProducto++;
                }
            }
            respuesta.ListaProducto = listaProducto;

            return respuesta;
        }

        private List<DashboardProductoObtenerDto> ProductosDummy(long idUsuario, int cantidad, DateTime periodoDesde)
        {
            List<DashboardProductoObtenerDto> listaObtenidaDesdeBd = new List<DashboardProductoObtenerDto>();
            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 2, 1),
                IdProducto = 1,
                DescripcionProducto = "Producto 1",
                Cantidad = 12
            });
            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 3, 1),
                IdProducto = 1,
                DescripcionProducto = "Producto 1",
                Cantidad = 19
            });
            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 4, 1),
                IdProducto = 1,
                DescripcionProducto = "Producto 1",
                Cantidad = 3
            });
            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 5, 1),
                IdProducto = 1,
                DescripcionProducto = "Producto 1",
                Cantidad = 5
            });


            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 2, 1),
                IdProducto = 2,
                DescripcionProducto = "Producto 2",
                Cantidad = 6
            });
            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 3, 1),
                IdProducto = 2,
                DescripcionProducto = "Producto 2",
                Cantidad = 33
            });
            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 4, 1),
                IdProducto = 2,
                DescripcionProducto = "Producto 2",
                Cantidad = 1
            });
            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 5, 1),
                IdProducto = 2,
                DescripcionProducto = "Producto 2",
                Cantidad = 9
            });


            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 2, 1),
                IdProducto = 3,
                DescripcionProducto = "Producto 3",
                Cantidad = 2
            });
            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 3, 1),
                IdProducto = 3,
                DescripcionProducto = "Producto 3",
                Cantidad = 15
            });
            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 4, 1),
                IdProducto = 3,
                DescripcionProducto = "Producto 3",
                Cantidad = 9
            });
            listaObtenidaDesdeBd.Add(new DashboardProductoObtenerDto
            {
                Periodo = new DateTime(2020, 5, 1),
                IdProducto = 3,
                DescripcionProducto = "Producto 3",
                Cantidad = 5
            });

            return listaObtenidaDesdeBd;
        }
        #endregion

        #region Grafico 3
        /// <summary>
        /// Grafico 3
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public DashboardCategoriaRootDto ObtenerCategoriasTop(long idUsuario, int cantidad)
        {
            DashboardCategoriaRootDto respuesta = new DashboardCategoriaRootDto();
            /*******************************************************************************************************************/
            List<DashboardPeriodoOrdenDto> listaPeriodo = new List<DashboardPeriodoOrdenDto>();
            int conteo = 1;
            for (int i = 4; i >= 1; i--)
            {
                DateTime fechaEvaluada = DateTime.Now.AddMonths(i * -1);

                listaPeriodo.Add(new DashboardPeriodoOrdenDto
                {
                    Orden = conteo,
                    Periodo = Entidad.Utilitario.Util.Derecha("0" + fechaEvaluada.Month.ToString(), 2) + "/" + fechaEvaluada.Year.ToString()
                });
                conteo++;
            }

            listaPeriodo = listaPeriodo.OrderBy(x => x.Orden).ToList();
            respuesta.ListaPeriodo = listaPeriodo;
            /*******************************************************************************************************************/
            //Calcular desde cuando debe traer la data
            DateTime fechaInicio = DateTime.Now.AddMonths(-4);
            fechaInicio = new DateTime(fechaInicio.Year, fechaInicio.Month, 1);

            //Obtener la data de categorias mas solicitados
            List<DashboardCategoriaObtenerDto> listaObtenidaDesdeBd = CategoriasDummy(idUsuario, cantidad, fechaInicio);
            listaObtenidaDesdeBd = listaObtenidaDesdeBd.OrderBy(x => x.Periodo).ThenBy(x => x.IdCategoria).ToList();

            List<DashboardCategoriaDto> listaCategoria = new List<DashboardCategoriaDto>();
            if (listaObtenidaDesdeBd.Any())
            {
                //Agrupar por categorias
                List<int> listaIdCategoria = new List<int>();
                listaIdCategoria = listaObtenidaDesdeBd.Select(x => x.IdCategoria).Distinct().ToList();
                /*
                var colorPrimary = '#007bff';
                var colorSuccess = '#28a745';
                var colorDanger = '#dc3545';
                */
                int iteracionCategoria = 1;
                foreach (var idCategoria in listaIdCategoria)
                {
                    string color = string.Empty;
                    switch (iteracionCategoria)
                    {
                        case 1:
                            color = "#007bff";
                            break;
                        case 2:
                            color = "#28a745";
                            break;
                        case 3:
                            color = "#dc3545";
                            break;
                        default:
                            break;
                    }

                    List<DashboardCategoriaDetalleDto> categoriaDetalle = (from det in listaObtenidaDesdeBd
                                                                         where det.IdCategoria == idCategoria
                                                                         orderby det.Periodo
                                                                         select new DashboardCategoriaDetalleDto
                                                                         {
                                                                             Valor = det.Cantidad,
                                                                             CodigoColorHexadecimal = color
                                                                         }).ToList();

                    DashboardCategoriaDto categoriaCabecera = (from cab in listaObtenidaDesdeBd
                                                             where cab.IdCategoria == idCategoria
                                                             select new DashboardCategoriaDto
                                                             {
                                                                 IdCategoria = cab.IdCategoria,
                                                                 DescripcionCategoria = cab.DescripcionCategoria,
                                                                 ListaValores = categoriaDetalle
                                                             }).FirstOrDefault();

                    listaCategoria.Add(categoriaCabecera);
                    iteracionCategoria++;
                }
            }
            respuesta.ListaCategoria = listaCategoria;

            return respuesta;
        }

        private List<DashboardCategoriaObtenerDto> CategoriasDummy(long idUsuario, int cantidad, DateTime periodoDesde)
        {
            List<DashboardCategoriaObtenerDto> listaObtenidaDesdeBd = new List<DashboardCategoriaObtenerDto>();
            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 2, 1),
                IdCategoria = 1,
                DescripcionCategoria = "Categoria 1",
                Cantidad = 12
            });
            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 3, 1),
                IdCategoria = 1,
                DescripcionCategoria = "Categoria 1",
                Cantidad = 19
            });
            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 4, 1),
                IdCategoria = 1,
                DescripcionCategoria = "Categoria 1",
                Cantidad = 3
            });
            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 5, 1),
                IdCategoria = 1,
                DescripcionCategoria = "Categoria 1",
                Cantidad = 5
            });


            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 2, 1),
                IdCategoria = 2,
                DescripcionCategoria = "Categoria 2",
                Cantidad = 6
            });
            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 3, 1),
                IdCategoria = 2,
                DescripcionCategoria = "Categoria 2",
                Cantidad = 33
            });
            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 4, 1),
                IdCategoria = 2,
                DescripcionCategoria = "Categoria 2",
                Cantidad = 1
            });
            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 5, 1),
                IdCategoria = 2,
                DescripcionCategoria = "Categoria 2",
                Cantidad = 9
            });


            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 2, 1),
                IdCategoria = 3,
                DescripcionCategoria = "Categoria 3",
                Cantidad = 2
            });
            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 3, 1),
                IdCategoria = 3,
                DescripcionCategoria = "Categoria 3",
                Cantidad = 15
            });
            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 4, 1),
                IdCategoria = 3,
                DescripcionCategoria = "Categoria 3",
                Cantidad = 9
            });
            listaObtenidaDesdeBd.Add(new DashboardCategoriaObtenerDto
            {
                Periodo = new DateTime(2020, 5, 1),
                IdCategoria = 3,
                DescripcionCategoria = "Categoria 3",
                Cantidad = 5
            });

            return listaObtenidaDesdeBd;
        }
        #endregion

        #region Grafico 4

        #endregion
    }
}
