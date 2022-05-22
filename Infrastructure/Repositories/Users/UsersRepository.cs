using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CoreApp.Models;
using CoreApp.Repositories.Users;
using NetCore.AutoRegisterDi;

namespace Infrastructure.Repositories.Users
{
    [RegisterAsSingleton]
    public class UsersRepository : IUsersRepository
    {
        private readonly HttpClient _client;
        private readonly IHttpClientFactory _factory;

        public UsersRepository(IHttpClientFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient("mock");
        }

        public async Task<IEnumerable<User>> FetchAllUsers()
        {
            var users = await _client.GetFromJsonAsync<List<User>>("/users");
            return users;
        }
    }
}
