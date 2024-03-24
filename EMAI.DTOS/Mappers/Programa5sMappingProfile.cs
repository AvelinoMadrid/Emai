using AutoMapper;
using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Request;
using EMAI.DTOS.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.DTOS.Mappers
{
    public class Programa5sMappingProfile : Profile
    {
        public Programa5sMappingProfile()
        {
            CreateMap<Programas5Request, Programa5ModelV1>().ForMember(x => x.ImagenAntes, y => y.MapFrom(src =>"Estar Nulo")).ReverseMap();
            CreateMap<Programa5ModelV1, Programas5Request>().ReverseMap();

            CreateMap<Programa5ModelV1, Programas5Response>().ReverseMap();
            CreateMap<Programas5Response, Programa5ModelV1>().ReverseMap();
        }
    }
}
