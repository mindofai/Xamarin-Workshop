using CrudLocalDb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudLocalDb.Database
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<IEnumerable<Item>> GetAllWithTags();
    }
}
