﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class HorariosModel
    {
        public int IdHorario { get; set; }

        public string Dia { get; set; }

    }

    public class HorariosIDModel
    {
        public int IdHorario { get; set; }

        public string Dia { get; set; }

    }

    public class HorariosInsertarModel
    {

        public string Dia { get; set; }

    }

    public class HorariosActualizarModel
    {
        public int idHorario { get; set; }
        public string Dia { get; set; }

    }

    public class HorariosEliminarModel
    {
        public int idHorario { get; set; }
        public string Dia { get; set; }

    }
}
