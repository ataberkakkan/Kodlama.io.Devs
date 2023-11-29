using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetByUserIdOperationClaim
{
    public class GetByUserIdOperationClaimQuery : IRequest<UserOperationClaimGetByIdModel>
    {
        public int UserId { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetByUserIdOperationClaimQueryHandler : IRequestHandler<GetByUserIdOperationClaimQuery, UserOperationClaimGetByIdModel>
        {
            private readonly IUserOperationClaimRepository _userOpreationClaimRepository;
            private readonly IMapper _mapper;

            public GetByUserIdOperationClaimQueryHandler(IUserOperationClaimRepository userOpreationClaimRepository, IMapper mapper)
            {
                _userOpreationClaimRepository = userOpreationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimGetByIdModel> Handle(GetByUserIdOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaims = await _userOpreationClaimRepository.GetListAsync(u => u.UserId == request.UserId,
                                                                                                                    index: request.PageRequest.Page,
                                                                                                                    size: request.PageRequest.PageSize,
                                                                                                                    include: uop => uop.Include(u => u.User).Include(oc => oc.OperationClaim));

                UserOperationClaimGetByIdModel userOperationClaimGetByIdModel = 
                    _mapper.Map<UserOperationClaimGetByIdModel>(userOperationClaims);

                return userOperationClaimGetByIdModel;
            }
        }
    }
}
