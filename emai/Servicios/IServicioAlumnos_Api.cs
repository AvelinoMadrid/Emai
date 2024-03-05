using emai.Models;
using emai.Servicios.Commons;
using emai.Servicios.Dtos.Response;


namespace emai.Servicios
{
    public interface IServicioAlumnos_Api
    {
        Task<List<Alumnos>> Lista();

        Task<Alumnos> ObtenerAlu(int IdAlumno);

        Task<BaseResponseV1<AlumnoModel>> ListarAllAlumnos();
        //puedo mapearlo
        //Task<BaseResponseV2<bool>> InsertarAlumno(AlumnoResponse entity);//No esto reciendo los datos acuados otra entiodad
        Task<BaseResponseV2<bool>> EliminarAlumnoV1(int IdAlumno);
        Task<BaseResponseV2<bool>> InsertarAlumnoV1(Alumnos entity);
        Task<List<ClasesResponse>> ListarClasesSelect();
        Task<BaseResponseV1<Promosiones>> ListSelectPromocion();
        Task<List<MesesModel>> ListarMesesSelect();
        Task<string> GenerarFolio();
        Task<bool> GuardarAlu(Alumnos Alumno);
        Task<bool> EditarAlu(Alumnos Alumno);
        Task<bool> EliminarAlu(int IdAlumno);
        Task<bool> RegistrarAlumnos(Alumnos Alumno);


    }
}