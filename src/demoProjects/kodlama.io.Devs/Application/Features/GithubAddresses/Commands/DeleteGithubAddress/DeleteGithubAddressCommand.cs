using Application.Features.GithubAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Commands.DeleteGithubAddress
{
    public class DeleteGithubAddressCommand : IRequest<DeletedGithubDto>
    {
        public int Id { get; set; }

        public class DeleteGithubAddressCommandHandler : IRequestHandler<DeleteGithubAddressCommand, DeletedGithubDto>
        {
            private readonly IGithubAddressRepository _githubAddressRepository;
            private readonly IMapper _mapper;

            public DeleteGithubAddressCommandHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper)
            {
                _githubAddressRepository = githubAddressRepository;
                _mapper = mapper;
            }

            public async Task<DeletedGithubDto> Handle(DeleteGithubAddressCommand request, CancellationToken cancellationToken)
            {
                GithubAddress mappedGithubAddress = _mapper.Map<GithubAddress>(request);
                GithubAddress deletedGithubAddress = await _githubAddressRepository.DeleteAsync(mappedGithubAddress);
                DeletedGithubDto deletedGithubDto = _mapper.Map<DeletedGithubDto>(deletedGithubAddress);

                return deletedGithubDto;
            }
        }
    }
}
