using Admin.Domain.Models;
using Admin.Domain.ValueObjects;

namespace Admin.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        private static readonly List<Administrator> _administrators;
        private static readonly List<Department> _departments;
        private static readonly List<Rate> _rates;

        static InitialData()
        {
            _administrators = new List<Administrator>
            {
                Administrator.Create(Guid.NewGuid(),
                    "Andrea Josefina",
                    Email.Create("andreaccdreis@gmail.com"),
                    Password.Create("Chi7#ai9**")),
                Administrator.Create(Guid.NewGuid(),
                    "Andrea Valentina",
                    Email.Create("accedeno.21@est.ucab.edu.ve"),
                    Password.Create("Chi7#ai9**")),
            };

            _departments = new List<Department>
            {
                Department.Create(Guid.NewGuid(), DepartmentName.Create("RH"), "Este será el dpto de Recursos Humanos"),
                Department.Create(Guid.NewGuid(), DepartmentName.Create("TI"), "Y este el dpto de Tecnología e información"),
            };

            _rates = new List<Rate>
            {
                Rate.Create(Guid.NewGuid(), RateName.Create("Standard"), 100.00m, 10.00m, 50.00m, RateDescription.Create("Standard rate for all services")),
                Rate.Create(Guid.NewGuid(), RateName.Create("Premium"), 200.00m, 15.00m, 75.00m, RateDescription.Create("Premium rate for priority services")),
            };

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
