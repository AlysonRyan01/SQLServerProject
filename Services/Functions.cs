using Microsoft.Data.SqlClient;
using SQLServerProject.Models;
using SQLServerProject.Repositories;

namespace SQLServerProject.Services
{
    public static class Functions
    {

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

        public static void CreateUserWithRole(UserRepository UserRepository, RoleRepository RoleRepository)
        {
            var user = ReturnUser(UserRepository);
            var role = ReturnRole(RoleRepository);

            UserRepository.Create(user);
            RoleRepository.Create(role);
        }

        public static User ReturnUser(Repository<User> repository)
        {
            System.Console.WriteLine("Vamos Criar um usuario: ");
            System.Console.WriteLine();

            System.Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            System.Console.WriteLine("Email: ");
            string email = Console.ReadLine();

            System.Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            System.Console.WriteLine("Bio: ");
            string bio = Console.ReadLine();

            System.Console.WriteLine("Image: ");
            string image = Console.ReadLine();

            System.Console.WriteLine("Slug: ");
            string slug = Console.ReadLine();

            var user = new User();
            user.Name = name;
            user.Email = email;
            user.PasswordHash = password;
            user.Bio = bio;
            user.Image = image;
            user.Slug = slug;
            
            return user;
        }

        public static Role ReturnRole(Repository<Role> repository)
        {
            System.Console.WriteLine("Vamos criar um perfil: ");
            System.Console.WriteLine();

            System.Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            System.Console.WriteLine("Slug: ");
            string slug = Console.ReadLine();

            var role = new Role();
            role.Name = name;
            role.Slug = slug;
            
            return role;
        }
    }
}