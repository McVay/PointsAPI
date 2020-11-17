using AutoMapper;
using PointsAPI.Domain.Models;
using PointsAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<Point, PointResource>();
            CreateMap<Point, UserBalanceResource>()
                .ForMember(src => src.PointsBalance, opt => opt.MapFrom(src => src.Amount));
        }
    }
}