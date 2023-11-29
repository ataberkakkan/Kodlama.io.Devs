using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Proiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, UserOperationClaimListDto>()
                .ForMember(uop => uop.UserName, opt => opt.MapFrom(u => $"{u.User.FirstName} {u.User.LastName}"))
                .ForMember(uop => uop.OperationClaimName, opt => opt.MapFrom(oc => oc.OperationClaim.Name))
                .ReverseMap();
            CreateMap<IPaginate<UserOperationClaim>, UserOpreationClaimListModel>().ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimGetByIdModel>().ReverseMap();
            CreateMap<UserOperationClaim, UserOperationClaimGetByIdDto>()
                .ForMember(uop => uop.UserName, opt => opt.MapFrom(u => $"{u.User.FirstName} {u.User.LastName}"))
                .ForMember(uop => uop.OperationClaimName, opt => opt.MapFrom(oc => oc.OperationClaim.Name))
                .ReverseMap();
        }
    }
}
