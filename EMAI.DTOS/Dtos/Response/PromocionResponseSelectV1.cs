﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.DTOS.Dtos.Response
{
    public class PromocionResponseSelectV1
    {
        public int IdPromociones { get; set; }
        public string NombrePromocion { get; set; } = null!;
        public Decimal Porcentaje { get; set; }
    }
}