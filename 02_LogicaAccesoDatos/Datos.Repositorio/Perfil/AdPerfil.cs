using Dapper;
using Datos.Helper;
using Entidad.Configuracion.Proceso;
using Entidad.Dto.Perfil;
using System;
using System.Data;

namespace Datos.Repositorio.Perfil
{
    public class AdPerfil: Logger
    {
        public PerfilObtenerDto ObtenerPorIdUsuario(long idUsuario)
        {
            PerfilObtenerDto resultado = new PerfilObtenerDto();
            try
            {
                const string query = "Perfil.usp_Perfil_ObtenerPorIdUsuario";

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.QuerySingleOrDefault<PerfilObtenerDto>(query, new
                    {
                        IdUsuario = idUsuario
                    }, commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }

        public Entidad.Entidad.Perfil.Perfil ObtenerPorId(long id)
        {
            Entidad.Entidad.Perfil.Perfil resultado = new Entidad.Entidad.Perfil.Perfil();
            try
            {
                const string query = "Perfil.usp_Perfil_ObtenerPorId";

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.QuerySingleOrDefault<Entidad.Entidad.Perfil.Perfil>(query, new
                    {
                        IdPerfil = id
                    }, commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }

        public int Registrar(PerfilRegistrarDto modelo, ref long idNuevo)
        {
            int resultado = 0;
            try
            {
                const string query = "Perfil.usp_Perfil_Registrar";

                var p = new DynamicParameters();
                p.Add("IdPerfil", 0, DbType.Int64, ParameterDirection.Output);
                p.Add("FechaNacimiento", modelo.FechaNacimiento);
                p.Add("Biografia", modelo.Biografia);
                p.Add("Direccion", modelo.Direccion);
                p.Add("Telefono", modelo.Telefono);
                p.Add("IdEstadoOcupacional", modelo.IdEstadoOcupacional);
                p.Add("NombreInstitucionLaboral", modelo.NombreInstitucionLaboral);
                p.Add("DescripcionCargoLaboral", modelo.DescripcionCargoLaboral);
                p.Add("IdGradoAcademico", modelo.IdGradoAcademico);
                p.Add("NombreCortoInstitucionAcademica", modelo.NombreCortoInstitucionAcademica);
                p.Add("IdCarrera", modelo.IdCarrera);
                p.Add("IdPaisResidencia", modelo.IdPaisResidencia);
                p.Add("IdUsuario", modelo.IdUsuario);
                p.Add("IdGenero", modelo.IdGenero);
                p.Add("IdEstadoSituacionSentimental", modelo.IdEstadoSituacionSentimental);
                p.Add("IdInteresGenero", modelo.IdInteresGenero);
                p.Add("IdInteresSentimental", modelo.IdInteresSentimental);

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.Execute(query, commandType: CommandType.StoredProcedure, param: p);

                    idNuevo = p.Get<long>("IdPerfil");

                }
            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }

        public int Modificar(PerfilModificarDto modelo)
        {
            int resultado = 0;
            try
            {
                const string query = "Perfil.usp_Perfil_Modificar";

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    resultado = cn.Execute(query, new
                    {
                        modelo.IdPerfil,
                        modelo.FechaNacimiento,
                        modelo.Biografia,
                        modelo.Direccion,
                        modelo.Telefono,
                        modelo.IdEstadoOcupacional,
                        modelo.NombreInstitucionLaboral,
                        modelo.DescripcionCargoLaboral,
                        modelo.IdGradoAcademico,
                        modelo.NombreCortoInstitucionAcademica,
                        modelo.IdCarrera,
                        modelo.IdPaisResidencia,
                        modelo.IdGenero,
                        modelo.IdEstadoSituacionSentimental,
                        modelo.IdInteresGenero,
                        modelo.IdInteresSentimental,
                        modelo.IdUsuario
                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                Log(Level.Error, (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            return resultado;
        }

    }
}
