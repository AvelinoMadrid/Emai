﻿using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IGastosOperaciones
    {
        Task<List<GastosModel>> GetGastos();
        Task<GastosIDModel> GetGastosID(int IdGasto);
        Task<bool> InsertarGastos(GastosInsertarModel value);
        Task<bool> ActualizarGastos(int IdGasto, int IdCooperaciones, int IdDotacion, int IdGastosDia, int IdNomina, DateTime Fecha, string NoPedidoE_S,
          string Proveedor, string Descripcion, decimal Cantidad);
        Task<bool> EliminarGastos(int IdGasto);


    }
}
