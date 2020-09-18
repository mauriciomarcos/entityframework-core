using EntityFrameworkCore.Data.Repository.Common;
using EntityFrameworkCore.Domain;
using EntityFrameworkCore.Domain.Interface.Repository;

namespace EntityFrameworkCore.Data.Repository
{
    public class ClienteRepository : EFRepositoryBase<Cliente>, IClienteRepository
    {
    }
}
