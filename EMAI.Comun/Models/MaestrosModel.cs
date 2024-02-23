﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class MaestrosModel
    {
        public int IdMaestro { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Estatus { get; set; }

        public decimal Pago { get; set; }
        public decimal PagoSemanal { get; set; }
        public decimal PagoHora { get; set; }



    }

    public class MaestrosIDModel
    {
        public int IdMaestro { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Estatus { get; set; }

        public decimal Pago { get; set; }

        public decimal PagoSemanal { get; set; }

        public decimal PagoHora { get; set; }

    }

    public class MaestrosInsertarModel
    {
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Estatus { get; set; }

        public decimal Pago { get; set; }

        public decimal PagoSemanal { get; set; }

        public decimal PagoHora { get; set; }

    }

    public class MaestrosActualizarModel
    {
        public int IdMaestro { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Estatus { get; set; }

        public decimal Pago { get; set; }
        public decimal PagoSemanal { get; set; }

        public decimal PagoHora { get; set; }


    }

    public class MaestrosEliminarModel
    {
        public int IdMaestro { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Estatus { get; set; }

        public decimal Pago { get; set; }
        public decimal PagoSemanal { get; set; }

        public decimal PagoHora { get; set; }

    }
}
