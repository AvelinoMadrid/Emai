using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class UsuariosModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; } 
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

    public class UsuariosIDModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

    public class UsuariosInsertarModel
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

    public class UsuariosActualizarModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

    public class UsuariosEliminarModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
