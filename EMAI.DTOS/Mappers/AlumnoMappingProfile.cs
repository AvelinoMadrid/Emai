using AutoMapper;
using Emai.Utilities.Static;
using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Request;
using EMAI.DTOS.Dtos.Response;
namespace EMAI.DTOS.Mappers
{
    public class AlumnoMappingProfile : Profile
    {
        public AlumnoMappingProfile()
        {
            //mapear objetos de mi tabla 
            CreateMap<AlumnoResponseV1, InsertarAlumnoModelV1>().ReverseMap();
            CreateMap<InsertarAlumnoModelV1, AlumnoResponseV1>().ForMember(x => x.Facebook, x => x.MapFrom(y => string.IsNullOrEmpty(y.Facebook) ? "Sin Sociales" : y.Facebook))
                                                                .ForMember(x => x.StringActivo, x => x.MapFrom(y => y.Activo.Equals((int)StateTypes.Activo == 1) ? "Activo" : "Inactivo"))
                                                                .ForMember(x => x.ClaseOpcional, x => x.MapFrom(y => y.Activo.Equals((int)StateTypes.Activo == 1) ? "Si" : "No"))
                                                                .ForMember(x => x.DescuentoP, x => x.MapFrom(y => y.Activo.Equals((int)StateTypes.Activo == 1) ? "Si" : "No"))
                                                                .ForMember(x => x.Amables, x => x.MapFrom(y => y.Activo.Equals((int)StateTypes.Activo == 1) ? "Si" : "No"))
                                                                .ForMember(x => x.Estudios, x => x.MapFrom(y => y.Activo.Equals((int)StateTypes.Activo == 1) ? "Si" : "No"))
                                                                .ForMember(x => x.Trabajas, x => x.MapFrom(y => y.Activo.Equals((int)StateTypes.Activo == 1) ? "Si" : "No"))
                                                                .ForMember(x => x.InteresGnroMusical, x => x.MapFrom(y => y.Activo.Equals((int)StateTypes.Activo == 1) ? "Si" : "No"))
                                                                .ForMember(x => x.InstrumentoCasa, x => x.MapFrom(y => y.Activo.Equals((int)StateTypes.Activo == 1) ? "Si" : "No"))
                                                                //.ForMember(x => x.FechaInscripcion, y =>y.MapFrom(z => z.FechaInscripcion.ToString("dd/MMMM/yyyy")))
                                                                //.ForMember(x => x.FechaInicioClase, y => y.MapFrom(z => z.FechaInicioClase.ToString("dd/MMMM/yyyy")))
                                                                //.ForMember(x => x.FechaNacimiento, y => y.MapFrom(z => z.FechaNacimiento.ToString("dd/MMMM/yyyy")))
                                                                .ForMember(x => x.ConConocimiento, x => x.MapFrom(y => y.Activo.Equals((int)StateTypes.Activo == 1) ? "Si" : "No")).ReverseMap();
            CreateMap<AlumnoRequest, InsertarAlumnoModelV1>().ReverseMap();
            CreateMap<InsertarAlumnoModelV1, AlumnoRequest>().ReverseMap();

            CreateMap<InsertarAlumnoModelV1, AlumnoRequestV1>().ReverseMap();
            CreateMap<AlumnoRequestV1, InsertarAlumnoModelV1>().ForMember(d=>d.FacebookPapas,option=>option.MapFrom(scr=>string.IsNullOrEmpty(scr.FacebookPapas) ? "Sin Facebook" : scr.FacebookPapas)).
                                                                ForMember(d => d.Facebook, option => option.MapFrom(scr => string.IsNullOrEmpty(scr.Facebook) ? "Sin Facebook" : scr.Facebook)).
                                                                ForMember(d => d.Email, option => option.MapFrom(scr => string.IsNullOrEmpty(scr.Email) ? "Sin Correo" : scr.Email)).
                                                                ForMember(d => d.GradoEstudios, option => option.MapFrom(scr => string.IsNullOrEmpty(scr.GradoEstudios) ? "Sin Datos" : scr.GradoEstudios)).
                                                                ReverseMap();
        }
    }
}
