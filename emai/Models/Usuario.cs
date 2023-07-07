using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models


{
    public class Usuarios
    {
        public int idUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public List<Usuarios> Lista { get; set; }
    }

    //public class UsuariosIDModel
    //{
    //    public int IdUsuario { get; set; }
    //    public string Usuario { get; set; }
    //    public string Contraseña { get; set; }
    //    public string Email { get; set; }
    //    public string Direccion { get; set; }
    //    public string Telefono { get; set; }
    //}

    //public class UsuariosInsertarModel
    //{
    //    public int idUsuario { get; set; }
    //    public string Usuario { get; set; }
    //    public string Contraseña { get; set; }
    //    public string Email { get; set; }
    //    public string Direccion { get; set; }
    //    public string Telefono { get; set; }
    //}

    //public class UsuariosActualizarModel
    //{
    //    public int IdUsuario { get; set; }
    //    public string Usuario { get; set; }
    //    public string Contraseña { get; set; }
    //    public string Email { get; set; }
    //    public string Direccion { get; set; }
    //    public string Telefono { get; set; }
    //}

    //public class UsuariosEliminarModel
    //{
    //    public int IdUsuario { get; set; }
    //    public string Usuario { get; set; }
    //    public string Contraseña { get; set; }
    //    public string Email { get; set; }
    //    public string Direccion { get; set; }
    //    public string Telefono { get; set; }
    //}
}
