using Microsoft.Data.SqlClient;
using SQLServerProject.Models;

namespace SQLServerProject.Repositories
{
    public class RoleRepository : Repository<Role>
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        
    }
}