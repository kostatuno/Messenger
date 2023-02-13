using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDb
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
    }
    public class Employee : User
    {
        public int Salary { get; set; }
    }
    public class Manager : User
    {
        public string? Departament { get; set; }
    }
}
