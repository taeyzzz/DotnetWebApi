using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreApp.Attributes;
using CoreApp.Models;
using CoreApp.Repositories.Users;
using NetCore.AutoRegisterDi;

namespace CoreApp.Services.Users
{
    [RegisterSingleton]
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _usersRepository.FetchAllUsers();
        }
    }
}
