using Azure.Core;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using Transportes_API.Services;

namespace Transportes_API.Controllers
{
    [Route("api/[controller]")]//Se declara el espacio de nombres 
    [ApiController]//establece el trato del controlador
    public class CamionesController : ControllerBase
    {//Variable para la interfaz y el contexto 
        private readonly ICamiones _service;
        private readonly TransportContext _context;

        //constructor para incializar mi servicio y mi contexto

        public CamionesController(ICamiones service, TransportContext context)
        {
            this._service = service;
            this._context = context;
        }

        [HttpGet]
        [Route("getCamion/{id}")]//además de la ruta, etablezc un parámetro a llegar desde la ruta

        public Camiones_DTO GetCamiones(int id)
        {
            Camiones_DTO camion = new Camiones_DTO(); // creo el objeto del modelo original 
            camion = _service.GetCamionbyID(id); //lleno este objeto desde la lista
            return camion;
        }

        //POST
        [HttpPost]
        [Route("insertarCamion")]
        //los metodos IActionResult retornan na respuesta a las API en un formato preestablecido capaz de ser leido por cualquier cliente http por otro lado FromBody determina que el parámetro que se espera será tomado del propio cuerpo de la peticion POST
        public IActionResult InsertarCamion([FromBody] Camiones_DTO camion)
        {
            string respuesta = _service.UpdateCamion(camion);
            return Ok(new { respuesta });//su retorno es un nuevo objeto de tipo OK
            //Siendo OK la respuesta a la peticion HTTP
        }

        [HttpPut]
        [Route("updateCamion")]
        public IActionResult updateCamion([FromBody] Camiones_DTO camion)
        {
            string respuesta = _service.UpdateCamion(camion);
            return Ok(new { respuesta });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult deleteCamion(int id)
            {
            string respuesta = _service.DeleteCamion(id);
            return Ok(new {respuesta});       
            }
    }
}
