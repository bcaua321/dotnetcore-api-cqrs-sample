using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCQRS.Core.UserContext
{
    public interface IUserReadOnlyRepository
    {
        Task<User> FindById(Guid id);
        
        Task<IEnumerable<User>> FindAll(int limit);
    }
}