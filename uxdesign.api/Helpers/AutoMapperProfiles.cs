﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uxdesign.api.Dtos;
using uxdesign.api.Models;

namespace uxdesign.api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest=>dest.PhotoUrl, opt=> {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest=>dest.Age, opt=>
                {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}