using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.LND
{
    public class UsuariosOperaciones : IUsuariosOperaciones
    {
        //Mostrar todo
        public async Task<List<UsuariosModel>> GetUsuarios()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetUsuarios();
            return rsp;
        }

        //Mostrar por ID
        public async Task<UsuariosIDModel> GetUsuariosID(int IdUsuario)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetUsuariosID(IdUsuario);
            return rsp;
        }

        //Insertar un Usuario
        public async Task<bool> InsertarUsuario(UsuariosInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarUsuario(value);
            return rsp;
        }

        //Actualizar Usuario
        public async Task<bool> ActualizarUsuario(int IdUsuario, string Usuario, string Contraseña, string Email, string Direccion, string Telefono)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarUsuario(IdUsuario, Usuario, Contraseña, Email, Direccion, Telefono);
            return rsp;
        }

        //Eliminar Usuario
        public async Task<bool> EliminarUsuario(int IdUsuario)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarUsuario(IdUsuario);
            return rsp;
        }
    }
}
