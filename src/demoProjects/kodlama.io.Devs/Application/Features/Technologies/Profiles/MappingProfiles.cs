﻿using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, TechnologyListDto>()
                .ForMember(t => t.LanguageName, opt => opt.MapFrom(t => t.Language.Name))
                .ReverseMap();

            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
        }
    }
}