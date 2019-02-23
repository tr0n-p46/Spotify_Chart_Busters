using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Chartbusters, ChartbustersResourceModel>();
            CreateMap<Chartbusters, ChartbusterViewModel>();
        }      
    }
}