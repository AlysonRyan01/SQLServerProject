using Microsoft.Data.SqlClient;
using SQLServerProject.Models;
using SQLServerProject.Repositories;

namespace SQLServerProject.Services
{
    public static class Functions
    {
        public static void CreateUser(Repository<User> repository)
        {
            var user = new User
            {
                //users
            };

            repository.Create(user);
        }

        public static void ReadUsers(Repository<User> repository)
        {
            var users = repository.Read();
            foreach (var item in users)
                Console.WriteLine(item.Email);
        }

        public static void ReadUser(Repository<User> repository)
        {
            var user = repository.Read(2);
            Console.WriteLine(user?.Email);
        }

        public static void UpdateUser(Repository<User> repository)
        {
            var user = repository.Read(2);
            user.Email = "hello@balta.io";
            repository.Update(user);

            Console.WriteLine(user?.Email);
        }

        public static void DeleteUser(Repository<User> repository)
        {
            var user = repository.Read(2);
            repository.Delete(user);
        }

        public static void ReadWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.ReadWithRole();

            foreach (var user in users)
            {
                Console.WriteLine(user.Email);
                foreach (var role in user.Roles) Console.WriteLine($" - {role.Slug}");
            }
        }
    }
}