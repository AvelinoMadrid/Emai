using EMAI.Comun.Models;
using EMAI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EMAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController
    {
        private readonly IUsuariosOperaciones _repository;

        public UsuariosController(IUsuariosOperaciones repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuariosModel>>> Get()
        {
            return await _repository.GetUsuarios();
        }

        //Buscar por ID
        [HttpGet("{IdUsuario}")]
        public async Task<ActionResult<UsuariosIDModel>> GetUsuariosID(int IdUsuario)
        {
            return await _repository.GetUsuariosID(IdUsuario);
        }

        //Loggeo
        [HttpGet("{usuario}/{contraseña}")]
        public async Task<ActionResult<UsuariosModel>> Loggeo(string usuario, string contraseña)
        {
            return await _repository.Loggeo(usuario, contraseña);
        }


        //Insertar Usuario

        [HttpPost("/api/Usuario/Insertar")]
        public async Task Post([FromBody] UsuariosInsertarModel value)
        {
            await _repository.InsertarUsuario(value);
        }

        //Actualizar Usuarios
        [HttpPut("/api/Usuarios/Actualizar")]
        public async Task Put([FromBody] UsuariosActualizarModel value)
        {
            await _repository.ActualizarUsuario(value.IdUsuario, value.Usuario, value.Contraseña, value.Email,
                value.Direccion, value.Telefono);
        }

        //Eliminar Usuarios
        [HttpDelete("Eliminar/{IdUsuario}")]
        public async Task Delete(int IdUsuario)
        {
            await _repository.EliminarUsuario(IdUsuario);
        }
    }
}
