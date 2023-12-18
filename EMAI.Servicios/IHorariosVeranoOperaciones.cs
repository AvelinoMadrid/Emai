﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMAI.Comun.Models;

namespace EMAI.Servicios
{
    public interface IHorariosVeranoOperaciones
    {
        Task<List<HorariosVeranoModel>> GetAllHorariosVerano();
        Task<HorariosVeranoModel> GetHorariosVeranoById(int Id);
        Task<bool> InsertHorarioVerano(HorariosVeranoInsertModel value);
        Task<bool> UpdateHorarioVerano(int IdHorarioVerano,int IdMaestro, int IdClase, string Dia, DateTime Fecha, DateTime HoraInicio, DateTime HoraFin);
        Task<bool> DeleteHorarioVerano(int id);


        
    }

}
