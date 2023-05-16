using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCQRS.Core.UserContext
{
    public interface IUserWriteOnlyRepository
    {

        Task<bool> Add(User user);
        Task<bool> Delete(User user);

        Task<bool> Update(User user);
    }
}