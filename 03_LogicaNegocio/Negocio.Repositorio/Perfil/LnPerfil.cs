using Datos.Repositorio.Perfil;
using Entidad.Dto.Perfil;

namespace Negocio.Repositorio.Perfil
{
    public class LnPerfil
    {
        private readonly AdPerfil _adPerfil = new AdPerfil();
        public PerfilObtenerDto ObtenerPorIdUsuario(long idUsuario)
        {
            return _adPerfil.ObtenerPorIdUsuario(idUsuario);
        }

        public Entidad.Entidad.Perfil.Perfil ObtenerPorId(long id)
        {
            return _adPerfil.ObtenerPorId(id);
        }

        public int Registrar(PerfilRegistrarDto modelo, ref long idNuevo)
        {
            return _adPerfil.Registrar(modelo, ref idNuevo);
        }

        public int Modificar(PerfilModificarDto modelo)
        {
            return _adPerfil.Modificar(modelo);
        }
    }
}
