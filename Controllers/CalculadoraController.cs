using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Transactions;

namespace Transportes_API.Controllers
{


    //Decoradores/ Data Annotations
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        //GET
        [HttpGet]
        [Route("suma")]
        public IActionResult suma(double a, double b)
        {
            double resultado = a + b;
            return Ok(new { resultado });
        }

        [HttpGet]
        [Route("resta")]
        public IActionResult resta(double a, double b)
        {
            double resultado = a - b;
            return Ok(new { resultado });
        }

       

        public class operadores
        { 
        public double a { get; set; }

        public double b { get; set; }
        }

        [HttpPost]
        [Route ("multiplicacion")]
        public IActionResult multiplicacion(operadores operador)
        {
            double resultado = operador.a * operador.b;
            return Ok(new { resultado});
        }

        [HttpPost]
        [Route("division")]
        public IActionResult division(operadores operador)
        {
            double resultado = operador.a / operador.b;
            return Ok(new { resultado });
        }
    }
}
