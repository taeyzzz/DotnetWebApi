using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreApp.Models;

namespace CoreApp.Services.Users
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}
