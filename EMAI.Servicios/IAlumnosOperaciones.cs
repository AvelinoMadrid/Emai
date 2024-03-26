using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Base;
using EMAI.DTOS.Dtos.Request;
using EMAI.DTOS.Dtos.Response;
using EMAI.Entidades;
using EMAI.Servicios;
namespace EMAI.Servicios
{
    public interface IAlumnosOperaciones
    {
        Task<bool> verificarExistFolio(string folio);
        Task<ListFolioResponse> FolioGenerate();
        Task<BaseResponse<AlumnoResponseV1>> GetAlumnosByIdV1(int IdAlumno);
        Task<BaseResponse<bool>> RegisterAlumno(AlumnoRequest request);
        Task<BaseResponse<bool>> EditarAlumnoV1(int IdAlumno,AlumnoRequestV1 request);
        Task<BaseResponse<List<SelectClasesHorarioResponse>>> SelectListClaseHorarioV1(int idClase);
        Task<BaseResponse<List<AlumnoResponseV1>>> GetListaAlumnoV1();
        Task<BaseResponse<bool>> DeleteByIdAlumnoV1(int IdAlumno);
        Task<BaseResponse<bool>> ReactivarByIdAlumnoV1(int IdAlumno);
    
    }
}
 