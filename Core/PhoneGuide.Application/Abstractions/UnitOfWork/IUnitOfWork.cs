using PhoneGuide.Application.Repositories;

namespace PhoneGuide.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IContactRepository ContactRepository { get; }

        public IPersonRepository PersonRepository { get; }

        Task SaveAsync();
    }
}
