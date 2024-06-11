﻿using PhoneGuide.Application.Dto;

namespace PhoneGuide.Application.Abstractions.Services
{
    public interface IPersonService
    {
        Task<bool> CreateAsync(DtoPerson person);

        Task<bool> CreateMultipleAsync(List<DtoPerson> persons);

        Task<bool> UpdateAsync(DtoPerson dto);

        bool DeleteById(Guid id);

        List<DtoPerson> GetAll();

        Task<DtoPerson> GetByIdAsync(Guid id);
    }
}
