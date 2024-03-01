using emai.Models;
using emai.Servicios.Commons;


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


        Task<bool> GuardarAlu(Alumnos Alumno);

        Task<bool> EditarAlu(Alumnos Alumno);

        Task<bool> EliminarAlu(int IdAlumno);


        // Nuevas APIS
        Task<bool> RegistrarAlumnos(Alumnos Alumno);


    }
}