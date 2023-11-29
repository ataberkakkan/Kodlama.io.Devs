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

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQuery : IRequest<UserOpreationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, UserOpreationClaimListModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UserOpreationClaimListModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(include: uop => uop
                                                                                                               .Include(u => u.User)
                                                                                                               .Include(op => op.OperationClaim),
                                                                                                               index: request.PageRequest.Page,
                                                                                                               size: request.PageRequest.PageSize);

                UserOpreationClaimListModel mappedUserOperationListModel = _mapper.Map<UserOpreationClaimListModel>(userOperationClaims);

                return mappedUserOperationListModel;
            }
        }
    }
}
