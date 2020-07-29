using Entidad.Configuracion.Proceso;
using Entidad.Dto.Comun;
using ModelosApi.Dto.Transaccion;
using ModelosApi.Response.Transaccion;
using Entidad.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Entidad.Dto.Transaccion;

namespace Negocio.Repositorio.Transaccion
{
    public class LnPedidoDetalle: Logger
    {
        private readonly string _nombreControlador = "PedidoDetalle";

        public async Task<ResultDataTable> Obtener(PedidoDetalleObtenerFiltroDto prm)
        {
            ResultDataTable resultado = new ResultDataTable();
            long totalRegistros = 0;
            List<PedidoDetalleObtenerPorIdPedidoDtoApi> lista = new List<PedidoDetalleObtenerPorIdPedidoDtoApi>();
            int statusCode = 0;
            try
            {
                try
                {
                    prm.Length = 100;
                }
                catch
                {
                }

                var response = string.Empty;
                string url = string.Format("{0}{1}/ObtenerPorIdPedido/{2}", ConstanteVo.UrlBaseApi, _nombreControlador, prm.IdPedido);

                using (var client = new HttpClient())
                {
                    if (ConstanteVo.ActivarLLamadasConToken && !string.IsNullOrEmpty(ConfiguracionToken.ConfigToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfiguracionToken.ConfigToken.Trim());
                    }

                    HttpResponseMessage result = await client.GetAsync(new Uri(url));
                    if (result != null)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        statusCode = (int)result.StatusCode;
                    }
                }

                ResponsePedidoDetalleObtenerPorIdPedidoDtoApi root = JsonConvert.DeserializeObject<ResponsePedidoDetalleObtenerPorIdPedidoDtoApi>(response);
                if (root != null && root.Cuerpo != null)
                {
                    lista = root.Cuerpo;
                    totalRegistros = root.CantidadTotalRegistros;
                    if (lista.Any())
                    {
                        int indice = Convert.ToInt32(prm.Start) + 1;
                        foreach (var item in lista)
                        {
                            item.Item = indice;
                            indice++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string exMessage = (ex.InnerException == null ? ex.Message : ex.InnerException.Message).Replace(Environment.NewLine, " ");
                Log(Level.Error, exMessage);
                resultado.error = exMessage;
            }
            finally
            {
                resultado.data = lista;
                resultado.draw = prm.Draw;
                resultado.recordsTotal = (int)totalRegistros;
                resultado.recordsFiltered = (int)totalRegistros;
                if (resultado != null)
                {
                    resultado.StatusCode = statusCode;
                }
            }

            return resultado;

        }
    }
}
