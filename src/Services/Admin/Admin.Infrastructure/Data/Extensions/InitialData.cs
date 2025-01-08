using Admin.Domain.Models;
using Admin.Domain.ValueObjects;
using BuildingBlocks.Hashing;

namespace Admin.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        private static readonly List<Administrator> _administrators;
        private static readonly List<Department> _departments;
        private static readonly List<Rate> _rates;

        static InitialData()
        {
            var passwordHasher = new PasswordHasher();

            _administrators =
            [
                Administrator.Create(Guid.NewGuid(),
                    AdministratorName.Of("Andrea", "Reis"),
                    Email.Create("andreaccdreis@gmail.com"),
                    Password.Create(passwordHasher.Hash("123456"))),
                Administrator.Create(Guid.NewGuid(),
                    AdministratorName.Of("Andrea", "Cedeno"),
                    Email.Create("accedeno.21@est.ucab.edu.ve"),
                    Password.Create(passwordHasher.Hash("123456"))),
                Administrator.Create(Guid.NewGuid(),
                    AdministratorName.Of("Juan", "Hedderich"),
                    Email.Create("jghedderich@proton.me"),
                    Password.Create(passwordHasher.Hash("123456"))),
            ];

            _departments =
            [
                Department.Create(Guid.NewGuid(), DepartmentName.Create("RH"), "Este será el dpto de Recursos Humanos"),
                Department.Create(Guid.NewGuid(), DepartmentName.Create("TI"), "Y este el dpto de Tecnología e información"),
            ];

            _rates =
            [
                Rate.Create(Guid.NewGuid(), RateName.Create("Standard"), 100.00m, 10.00m, 50.00m, RateDescription.Create("Standard rate for all services")),
                Rate.Create(Guid.NewGuid(), RateName.Create("Premium"), 200.00m, 15.00m, 75.00m, RateDescription.Create("Premium rate for priority services")),
            ];

            //AddUsersToDepartment(_departments[0], "user1@example.com", "User One");
            //AddUsersToDepartment(_departments[1], "user2@example.com", "User Two");
        }

        public static IEnumerable<Administrator> Administrators() => _administrators;

        public static IEnumerable<Department> Departments() => _departments;

        public static IEnumerable<Rate> Rates() => _rates;

        //private static void AddUsersToDepartment(Department department, string email, string name)
        //{
        //    var userId = Guid.NewGuid(); 

        //    department.AddUser(userId, email, name);
        //    
        //}
    }
}
