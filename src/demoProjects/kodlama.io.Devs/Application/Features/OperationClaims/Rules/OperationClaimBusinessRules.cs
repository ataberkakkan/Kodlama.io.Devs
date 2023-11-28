using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task CheckIfClaimExists(string name)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(c => c.Name == name);
            if (operationClaim != null)
            {
                throw new BusinessException("Claim already exists");
            }
        }

        public async Task ClaimShouldExistWhenRequested(OperationClaim operationClaim)
        {
            if (operationClaim == null)
            {
                throw new BusinessException("Claim does not exist");
            }
        }
    }
}
