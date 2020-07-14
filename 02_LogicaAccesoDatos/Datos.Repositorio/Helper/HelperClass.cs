using Entidad.Configuracion.Proceso;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Helper
{
    internal class HelperClass
    {
        //SQL SERVER
        internal static IDbConnection ObtenerConeccion()
        {
            return new SqlConnection(ConfiguracionJson.Conf.Cn);
        }
        //MYSQL
        //return new MySqlConnection(ConfiguracionJson.Conf.Cn);

        //Oracle
        //return new OracleConnection(ConfiguracionJson.Conf.Cn);
    }
}
