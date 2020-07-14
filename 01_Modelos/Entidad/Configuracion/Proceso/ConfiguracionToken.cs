namespace Entidad.Configuracion.Proceso
{
    public class ConfiguracionToken
    {
        public static string ConfigToken;
        public static void EstablecerConfiguracion(string valorToken)
        {
            ConfigToken = valorToken;
        }
    }
}
