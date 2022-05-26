using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using TechPet.Data.Abstractions;

namespace TechPet.Data.Context
{
    public class TechPetReadContext : IDbReadContext
    {
        public IDbConnection Connection { get; }

        public TechPetReadContext(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("Npgsql"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
