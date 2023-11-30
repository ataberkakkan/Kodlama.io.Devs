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

namespace Application.Features.GithubAddresses.Commands.UpdateGithubAddress
{
    public class UpdateGithubAddressCommand : IRequest<UpdatedGithubDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubLink { get; set; }

        public class UpdateGithubAddressCommandHandler : IRequestHandler<UpdateGithubAddressCommand, UpdatedGithubDto>
        {
            private readonly IGithubAddressRepository _githubAddressRepository;
            private readonly IMapper _mapper;

            public UpdateGithubAddressCommandHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper)
            {
                _githubAddressRepository = githubAddressRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedGithubDto> Handle(UpdateGithubAddressCommand request, CancellationToken cancellationToken)
            {
                GithubAddress mappedGithubAddress = _mapper.Map<GithubAddress>(request);
                GithubAddress updatedGithubAddress = await _githubAddressRepository.UpdateAsync(mappedGithubAddress);
                UpdatedGithubDto updatedGithubDto = _mapper.Map<UpdatedGithubDto>(updatedGithubAddress);

                return updatedGithubDto;
            }
        }
    }
}
