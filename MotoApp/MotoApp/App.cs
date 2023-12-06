using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

namespace MotoApp;

public class App : IApp
{
    private readonly IRepository<Employee> _employeesRepository;
    private readonly IRepository<Car> _carsRepository;
    private readonly ICarsProvider _carsProvider;

    public App(
        IRepository<Employee> employeesRepository,
        IRepository<Car> carsRepository,
        ICarsProvider carsProvider)
    {
        _employeesRepository = employeesRepository;
        _carsRepository = carsRepository;
        _carsProvider = carsProvider;
    }

    public void Run()
    {
        Console.WriteLine("I'm here in Run() method");

        //adding
        var employees = new[]
        {
            new Employee { FirstName = "Antek" },
            new Employee { FirstName = "Natan" },
            new Employee { FirstName = "Maja" },
        };

        foreach (var employee in employees)
        {
            _employeesRepository.Add(employee);
        }

        _employeesRepository.Save();

        //reading
        var items = _employeesRepository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        //cars
        var cars = GenerateSampleCars();
        foreach (var car in cars)
        {
            _carsRepository.Add(car);
        }

        foreach (var car in _carsProvider.GetUniqueCarColors())
        {
            Console.WriteLine(car);
        }
    }

    public static List<Car> GenerateSampleCars()
    {
        return new List<Car>
        {
            new Car
            {
                Id = 680,
                Name = "Car 1",
                Color = "Black",
                StandardCost = 1059.31M,
                ListPrice = 1431.50M,
                Type = "58",
            },
            new Car
            {
                 Id = 706,
                Name = "Car 2",
                Color = "Red",
                StandardCost = 1059.31M,
                ListPrice = 1431.50M,
                Type = "58",
            },
            new Car
            {
                 Id = 707,
                Name = "Car 3",
                Color = "Red",
                StandardCost = 13.08M,
                ListPrice = 34.99M,
                Type = null,
            },
            new Car
            {
                 Id = 708,
                Name = "Car 4",
                Color = "White",
                StandardCost = 14.09M,
                ListPrice = 34.99M,
                Type = "M",
            }
        };
    }
}
