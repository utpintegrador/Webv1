using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebasUnitarias.Seguridad
{
    public class RecuperacionContraseniaTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RecuperacionContrasenia_Registrar()
        {
            var request = new ModelosApi.Request.Correo.RequestRecuperacionContraseniaRegistrarDtoApi();

            var contexto = new ValidationContext(request, null, null);
            var listaErrores = new List<ValidationResult>();
            var esModeloValido = Validator.TryValidateObject(request, contexto, listaErrores, true);

            if (listaErrores == null) listaErrores = new List<ValidationResult>();
            foreach (var error in listaErrores)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            var valorEsperado = false;
            Assert.AreEqual(valorEsperado, esModeloValido);
        }

    }
}
