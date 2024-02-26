using AutoMapper;
using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Request;

namespace EMAI.DTOS.Mappers
{
    public class PromocionMappingProfile : Profile
    {
        public PromocionMappingProfile()
        {
            CreateMap<PromocionesRequest, PromocionesModel>().ReverseMap();


        }
    }
}
                                                                                                                                                                            