﻿using EMAI.Comun.Models;
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
    public class HorariosVeranoOperaciones: IHorariosVeranoOperaciones
    {
        public async Task<List<HorariosVeranoModel>> GetAllHorariosVerano()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAllHorariosVerano();
            return rsp;
        }

        public async Task<HorariosVeranoModel> GetHorariosVeranoById(int Id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetHorariosVeranoById( Id);
            return rsp;
        }

        public async Task<bool> InsertHorarioVerano(HorariosVeranoInsertModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertHorarioVerano(value);
            return rsp;
        }

        public async Task<bool> UpdateHorarioVerano(int IdHorarioVerano,int IdMaestro, int IdClase, string Dia, DateTime Fecha, DateTime HoraInicio, DateTime HoraFin)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.UpdateHorarioVerano(IdHorarioVerano,IdMaestro,IdClase, Dia, Fecha, HoraInicio, HoraFin);
            return rsp;
        }

        public async Task<bool> DeleteHorarioVerano(int Id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.DeleteHorarioVerano(Id);
            return rsp;
        }
    }
}