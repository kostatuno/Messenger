namespace TestDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User() { Name = "Kostya" };
            User manager = new Manager() { Name = "Kostya", Departament = "aga"};
            User employer = new Employee() { Name = "Kostya", Salary = 123 };


            user = new Manager() { Name = user.Name };
            Manager manager2 = (Manager)user;

            manager2.Foo3();

            
        }
    }
}