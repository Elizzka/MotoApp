using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Components.CsvReader;
using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICarsProvider, CarsProvider>();
services.AddSingleton<ICsvReader, CsvReader>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();



//using MotoApp.Data;
//using MotoApp.Entities;
//using MotoApp.Repositories;
//using MotoApp.Repositories.Extensions;

//var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
//employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;

//void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
//{
//    Console.WriteLine($"Employee added => {e.FirstName} from {sender?.GetType().Name}");
//}

//AddEmployees(employeeRepository);
//WriteAllToConsole(employeeRepository);

//static void EmployeeAdded(object item)
//{
//    var employee = (Employee)item;
//    Console.WriteLine($"{employee.FirstName} added");
//}

//static void AddEmployees(IRepository<Employee> repository)
//{
//    var employees = new[]
//    {
//        new Employee { FirstName = "Antek" },
//        new Employee { FirstName = "Natan" },
//        new Employee { FirstName = "Maja" }
//    };

//    repository.AddBatch(employees);
//    //"string".AddBatch(employees);
//   // AddBatch(employeeRepository, employees);
    
//    //repository.Add(new Employee { FirstName = "Antek" });
//   // repository.Add(new Employee { FirstName = "Natan" });
//   // repository.Add(new Employee { FirstName = "Maja" });
//   // repository.Save();
//}

////static void AddBatch<T>(IRepository<T> repository, T[] items) 
// //   where T : class, IEntity
////{
//  //  foreach (var item in items)
//   // {
//   //     repository.Add(item);
//  //  }
////
//   // repository.Save();
////}

//static void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}