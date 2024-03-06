using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class GastosModel
    {
        public int IdGasto { get; set; }

        public DateTime Fecha { get; set; }
        public string NoPedidoE_S { get; set; }
        public string Proveedor { get; set; }

        public decimal Cantidad { get; set; }

        public string imagen { get; set; }
    }

    public class GastosIDModel
    {
        public int IdGasto { get; set; }

        public DateTime Fecha { get; set; }
        public string NoPedidoE_S { get; set; }
        public string Proveedor { get; set; }

        public decimal Cantidad { get; set; }

        public string imagen { get; set; }
    }

    public class GastosInsertarModel
    {

        public DateTime Fecha { get; set; }
        public string NoPedidoE_S { get; set; }
        public string Proveedor { get; set; }

        public decimal Cantidad { get; set; }

        public string imagen { get; set; }
    }

    public class GastosActualizarModel
    {
        public int IdGasto { get; set; }

        public DateTime Fecha { get; set; }
        public string NoPedidoE_S { get; set; }
        public string Proveedor { get; set; }

        public decimal Cantidad { get; set; }

        public string imagen { get; set; }
    }

    public class GastosEliminarModel
    {
        public int IdGasto { get; set; }
        public int IdColegiatura { get; set; }
        public int IdCooperaciones { get; set; }
        public int IdDotacion { get; set; }
        public int IdGastosDia { get; set; }
        public int IdNomina { get; set; }
        public DateTime Fecha { get; set; }
        public string NoPedidoE_S { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }

        public string imagen { get; set; }
    }
}
