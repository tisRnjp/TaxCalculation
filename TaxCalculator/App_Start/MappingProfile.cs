using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxCalculator.DTOS;
using TaxCalculator.Models;

namespace TaxCalculator.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CitizenHouse, CitizenHouseDto>();
            Mapper.CreateMap<CitizenHouseDto, CitizenHouse>();
        }
    }
}