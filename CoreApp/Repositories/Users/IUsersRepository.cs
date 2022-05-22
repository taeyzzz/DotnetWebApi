using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreApp.Models;

namespace CoreApp.Repositories.Users
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> FetchAllUsers();
    }
}
