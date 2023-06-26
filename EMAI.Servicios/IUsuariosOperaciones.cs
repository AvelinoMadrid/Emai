using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IUsuariosOperaciones
    {
        Task<List<UsuariosModel>> GetUsuarios();

        Task<UsuariosIDModel> GetUsuariosID(int IdUsuario);

        Task<bool> InsertarUsuario(UsuariosInsertarModel value);

        Task<bool> ActualizarUsuario(int IdUsuario, string Usuario, string Contraseña, string Email, string Direccion, string Telefono);

        Task<bool> EliminarUsuario(int IdUsuario);
    }
}
