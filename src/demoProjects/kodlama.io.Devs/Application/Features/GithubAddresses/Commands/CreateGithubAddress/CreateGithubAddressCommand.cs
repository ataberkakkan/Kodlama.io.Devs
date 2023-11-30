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

namespace Application.Features.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGithubAddressCommand : IRequest<CreatedGithubDto>
    {
        public int UserId { get; set; }
        public string GithubLink { get; set; }

        public class CreateGithubAddressCommandHandler : IRequestHandler<CreateGithubAddressCommand, CreatedGithubDto>
        {
            private readonly IGithubAddressRepository _githubAddressRepository;
            private readonly IMapper _mapper;

            public CreateGithubAddressCommandHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper)
            {
                _githubAddressRepository = githubAddressRepository;
                _mapper = mapper;
            }

            public async Task<CreatedGithubDto> Handle(CreateGithubAddressCommand request, CancellationToken cancellationToken)
            {
                GithubAddress mappedGithubAddress = _mapper.Map<GithubAddress>(request);
                GithubAddress createdGithubAddress = await _githubAddressRepository.AddAsync(mappedGithubAddress);
                CreatedGithubDto createdGithubDto = _mapper.Map<CreatedGithubDto>(createdGithubAddress);

                return createdGithubDto;
            }
        }
    }
}
