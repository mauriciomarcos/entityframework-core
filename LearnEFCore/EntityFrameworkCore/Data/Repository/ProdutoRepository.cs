using EntityFrameworkCore.Data.Repository.Common;
using EntityFrameworkCore.Domain;
using EntityFrameworkCore.Domain.Interface.Repository;

namespace EntityFrameworkCore.Data.Repository
{
    public class ProdutoRepository : EFRepositoryBase<Produto>, IProdutoRepository
    {
    }
}
