using Application.Features.GithubAddresses.Commands.CreateGithubAddress;
using Application.Features.GithubAddresses.Commands.DeleteGithubAddress;
using Application.Features.GithubAddresses.Commands.UpdateGithubAddress;
using Application.Features.GithubAddresses.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubAddress, CreatedGithubDto>().ReverseMap();
            CreateMap<GithubAddress, CreateGithubAddressCommand>().ReverseMap();

            CreateMap<GithubAddress, DeletedGithubDto>().ReverseMap();
            CreateMap<GithubAddress, DeleteGithubAddressCommand>().ReverseMap();

            CreateMap<GithubAddress, UpdatedGithubDto>().ReverseMap();
            CreateMap<GithubAddress, UpdateGithubAddressCommand>().ReverseMap();
        }
    }
}
