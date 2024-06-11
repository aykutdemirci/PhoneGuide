﻿using PhoneGuide.Application.Dto;

namespace PhoneGuide.Application.Abstractions.Services
{
    public interface IPersonService
    {
        Task<bool> CreateAsync(DtoPerson dtoPerson);

        Task<bool> CreateMultipleAsync(List<DtoPerson> dtoPersons);

        Task<bool> UpdateAsync(DtoPerson dtoPerson);

        Task<bool> DeleteByIdAsync(Guid id);

        List<DtoPerson> GetAll();

        Task<DtoPerson> GetByIdAsync(Guid id);
    }
}
