using Negocio.Repositorio.Seguridad;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void Usuario_Registrar()
        //{
        //    LnUsuario lnUsuario = new LnUsuario();
        //    var t = Task.Run(() => lnUsuario.Registrar(new Entidad.Dto.Seguridad.UsuarioRegistrarDto
        //    {
        //        CorreoElectronico = "correo40@correo.com",
        //        Nombre = "Nombre 40",
        //        Apellido = "Apellido 40",
        //        Contrasenia = "987654"
        //    }));
        //    t.Wait();
        //    Assert.AreEqual(1, t.Result);
        //}

        [Test]
        public void Usuario_Login()
        {
            LnUsuario lnUsuario = new LnUsuario();
            var t = Task.Run(() => lnUsuario.ObtenerPorLogin(new Entidad.Dto.Seguridad.UsuarioLoginFiltroDto
            {
               CorreoElectronico = "frank@app.com",
               Contrasenia = "123456"
            }));
            t.Wait();
            Assert.Greater(t.Result.IdUsuario, 0);
        }
    }
}