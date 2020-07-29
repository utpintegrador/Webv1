using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using ModelosApi.Response.Comun;
using System.Collections.Generic;
using System.Linq;

namespace AppWeb.CustomHandler
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                try
                {
                    var listaValores = modelState.Select(x => x.Value).ToList();
                    if (listaValores.Any())
                    {
                        List<ErrorDtoApi> ListaError = new List<ErrorDtoApi>();
                        foreach (var item in listaValores)
                        {
                            if (item != null)
                            {
                                foreach (var erro in item.Errors)
                                {
                                    ListaError.Add(new ErrorDtoApi
                                    {
                                        Mensaje = erro.ErrorMessage
                                    });
                                }
                            }
                        }

                        ResponseValidacionModeloDtoApi response = new ResponseValidacionModeloDtoApi
                        {
                            ListaError = ListaError,
                            ProcesadoOk = 0,
                            Cuerpo = null,
                            IdGenerado = 0
                        };

                        var json = Newtonsoft.Json.JsonConvert.SerializeObject(response);
                        actionContext.HttpContext.Response.StatusCode = 400;
                        actionContext.HttpContext.Response.ContentType = "application/json";
                        actionContext.HttpContext.Response.WriteAsync(json);
                    }
                }
                catch { }
            }

            base.OnActionExecuting(actionContext);
        }
    }
}
