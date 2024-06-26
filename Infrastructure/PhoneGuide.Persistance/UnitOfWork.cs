﻿using PhoneGuide.Application.Abstractions.UnitOfWork;
using PhoneGuide.Application.Repositories;
using PhoneGuide.Persistance.Contexts;

namespace PhoneGuide.Persistance
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly PhoneGuideDbContext _dbContext;

        public IContactRepository ContactRepository { get; }

        public IPersonRepository PersonRepository { get; }

        public UnitOfWork(PhoneGuideDbContext dbContext,
                          IContactRepository contactRepository,
                          IPersonRepository personRepository)
        {
            _dbContext = dbContext;
            ContactRepository = contactRepository;
            PersonRepository = personRepository;
        }

        public async Task SaveAsync()
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
