﻿using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;


namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestrosController
    {
        private readonly IMaestrosOperaciones _repository;

        public MaestrosController(IMaestrosOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaestrosModel>>> Get()
        {
            return await _repository.GetMaestros();
        }

        [HttpGet("{IdMaestro}")]
        public async Task<ActionResult<MaestrosIDModel>> GetMaestrosID(int IdMaestro)
        {
            return await _repository.GetMaestrosID(IdMaestro);
        }

        //Insertar Maestro

        [HttpPost("/api/Maestro/Insertar")]
        public async Task Post([FromBody] MaestrosInsertarModel value)
        {
            await _repository.InsertarMaestro(value);
        }

        [HttpPut("/api/Maestros/Actualizar")]
        public async Task Put([FromBody] MaestrosActualizarModel value)
        {
            await _repository.ActualizarMaestro(value.IdMaestro, value.Nombre, value.ApellidoP, value.ApellidoM,
                value.Direccion, value.Telefono, value.FechaNacimiento,
                value.Estatus, value.Pago, value.PagoSemanal, value.PagoHora, value.Area);
        }

        //Eliminar Maestros
        [HttpDelete("{IdMaestro}")]
        public async Task Delete(int IdMaestro)
        {
            await _repository.EliminarMaestro(IdMaestro);
        }


    }
}
