using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CoreApp.Models;
using CoreApp.Repositories.Users;
using Infrastructure.Config;
using Microsoft.Extensions.Options;
using NetCore.AutoRegisterDi;

namespace Infrastructure.Repositories.Users
{
    [RegisterAsSingleton]
    public class UsersRepository : IUsersRepository
    {
        private readonly HttpClient _client;
        private readonly IHttpClientFactory _factory;
        private readonly DatabaseConfig _databaseConfig;

        public UsersRepository(IHttpClientFactory factory, IOptions<DatabaseConfig> databaseConfig)
        {
            _factory = factory;
            _client = _factory.CreateClient("mock");
            _databaseConfig = databaseConfig.Value;
        }

        public async Task<IEnumerable<User>> FetchAllUsers()
        {
            var users = await _client.GetFromJsonAsync<List<User>>("/users");
            var x = _databaseConfig.Username;
            return users;
        }
    }
}
