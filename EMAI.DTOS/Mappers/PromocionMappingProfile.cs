using AutoMapper;
using Emai.Utilities.Static;
using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Request;
using EMAI.DTOS.Dtos.Response;

namespace EMAI.DTOS.Mappers
{
    public class PromocionMappingProfile : Profile
    {
        public PromocionMappingProfile()
        {
            CreateMap<PromocionesRequest, PromocionesModelV1>().ReverseMap();
            CreateMap<PromocionesModelV1, PromocionesRequest>().ReverseMap();
            CreateMap<PromocionesModelV1, PromocionResponseV1>().
                       ForMember(x => x.statePromocion, x => x.MapFrom(y => y.Activo.Equals((int)StateTypes.Activo == 1) ? "Activo" : "InaActivo")).ReverseMap();

            CreateMap<PromocionesModelV1, PromocionResponseSelectV1>().ReverseMap();

        }
    }
}
