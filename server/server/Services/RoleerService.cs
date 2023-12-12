using Grpc.Core;
using MySql.Data.MySqlClient;
using server;

namespace server.Services
{
    public class RoleerService : Roleer.RoleerBase
    {
        const string connectionString = "Server=localhost;Database=pyramid;Uid=root;Pwd=123456;";
        private readonly ILogger<RoleerService> _logger;
        public RoleerService(ILogger<RoleerService> logger)
        {
            _logger = logger;
        }

        public override Task<LoginReply> RoleLogin(LoginRequest request, ServerCallContext context)
        {
            return Task.FromResult(new LoginReply
            {
                State = DataSQL(request.Account, request.Pwd) ? 1 : 0
            });
        }

        bool DataSQL(string account, string pwd)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("-------------open mysql-----------------");
                // 使用参数化查询以防止 SQL 注入
                string query = "SELECT * FROM role WHERE  account = @account and pwd=@pwd";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@account", account);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }



    }
}