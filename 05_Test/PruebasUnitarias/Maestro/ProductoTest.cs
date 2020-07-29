using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebasUnitarias.Maestro
{
    public class ProductoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Producto_Registrar()
        {
            var request = new ModelosApi.Request.Maestro.RequestProductoRegistrarDtoApi();

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

        [Test]
        public void Producto_Modificar()
        {
            var request = new ModelosApi.Request.Maestro.RequestProductoModificarDtoApi();

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
