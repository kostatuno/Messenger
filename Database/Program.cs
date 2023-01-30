using Database;
using Microsoft.VisualBasic.FileIO;
using Messenger.Extensions;
using Messenger;
using System.Reflection;
using Messenger.Models;

/*using (var db = ApplicationDbContext.GetInstance())
{
    // создаем два объекта User
    User ahmed = new User("ahmed", "ahmed", "ahmed");
    User ahmed2 = new User("ahmed2", "ahmed2", "ahmed2");

    // добавляем их в бд
    db.Users.Add(ahmed);
    db.Users.Add(ahmed2);
    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name}");
    }
}*/

