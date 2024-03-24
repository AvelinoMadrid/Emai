using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Base;
using EMAI.DTOS.Dtos.Request;
using EMAI.DTOS.Dtos.Response;
using Microsoft.AspNetCore.Http;

namespace EMAI.Servicios
{
    public interface IPrograma5sOperaciones
    {
        Task<List<Programa5sModel>> GetPrograma5s();

        Task<Programa5sIdModel> GetPrograma5sId(int Id);

        Task<bool> InsertarPrograma5s(Programa5sInsertarModel value);

        Task<string> GuadarFoto(IFormFile picture);

        Task<bool> ActualizarPrograma5s(int Id, string Area, string Supervisor, DateTime FechaAntes, DateTime FechaInicio, string Detalles);

        //sera otroa forma
        Task<BaseResponse<bool>> RegisterProgramV1(Programas5Request request);
        Task<BaseResponse<List<Programas5Response>>> GetAllProgramaV1();
        Task<BaseResponse<Programas5Response>> GetPrograma5sById(int IdPrograma);
        //sera otra forma
    }
}
