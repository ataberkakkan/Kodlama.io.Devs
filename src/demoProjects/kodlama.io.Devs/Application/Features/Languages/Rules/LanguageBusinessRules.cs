﻿using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(l => l.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("This programming language already exists");
            }
        }

        public async Task LanguageShouldExistWhenRequested(int id)
        {
            Language? language = await _languageRepository.GetAsync(l => l.Id == id);
            if (language == null)
            {
                throw new BusinessException("Language does not exist");
            }
        }
    }
}
