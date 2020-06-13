using Datos.Repositorio.Seguridad;
using Entidad.Dto.Seguridad;
using Entidad.Entidad.Seguridad;
using Negocio.Repositorio.Helper;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Negocio.Repositorio.Seguridad
{
    public class LnUsuario
    {
        private readonly AdUsuario _adUsuario = new AdUsuario();
        private readonly ApiHelper _apiHelper = new ApiHelper();
        public List<UsuarioObtenerDto> Obtener(UsuarioObtenerFiltroDto filtro)
        {

            filtro.Buscar = "";
            filtro.IdEstado = 1;
            filtro.NumberPage = 1;
            filtro.Length = 200;
            filtro.ColumnOrder = "IdUsuario";
            filtro.OrderDirection = "desc";

            return _adUsuario.Obtener(filtro);
        }

        public async Task<List<UsuarioObtenerDto>> Obtener2(UsuarioObtenerFiltroDto filtro)
        {
            List<UsuarioObtenerDto> lista = new List<UsuarioObtenerDto>();
            HttpClient cliente = _apiHelper.Initial();
            HttpResponseMessage res = await cliente.GetAsync("Usuario");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
            }

            filtro.Buscar = "";
            filtro.IdEstado = 1;
            filtro.NumberPage = 1;
            filtro.Length = 200;
            filtro.ColumnOrder = "IdUsuario";
            filtro.OrderDirection = "desc";

            return _adUsuario.Obtener(filtro);
        }

        public Usuario ObtenerPorId(int id)
        {
            return _adUsuario.ObtenerPorId(id);
        }

        public int Registrar(UsuarioRegistrarDto modelo)
        {
            return _adUsuario.Registrar(modelo);
        }

        public int Modificar(UsuarioModificarDto modelo)
        {
            return _adUsuario.Modificar(modelo);
        }

        public int Eliminar(int id)
        {
            return _adUsuario.Eliminar(id);
        }

        public List<UsuarioObtenerComboDto> ObtenerCombo(int idEstado)
        {
            return _adUsuario.ObtenerCombo(idEstado);
        }






        /*En otro entregable completar*/

        public UsuarioLoginDto ObtenerPorLogin(UsuarioCredencialesDto modelo)
        {
            return null;
        }
        public int ModificarContrasenia(UsuarioCambioContraseniaDto modelo)
        {
            return 0;
        }

    }
}
