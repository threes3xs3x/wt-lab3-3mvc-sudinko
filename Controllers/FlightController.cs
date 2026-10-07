using wt_lab3_3mvc_sudinko.Models;
using wt_lab3_3mvc_sudinko.Views;

namespace wt_lab3_3mvc_sudinko.Controllers;

public class FlightController
{
    private readonly List<Flight> flights;
    private readonly FlightView view;

    public FlightController()
    {
        flights = new List<Flight>
        {
            new Flight
            {
                Id = 1,
                Number = "B2-101",
                From = "Минск",
                To = "Москва",
                Price = 250,
                IsAvailable = true
            },
            new Flight
            {
                Id = 2,
                Number = "B2-202",
                From = "Минск",
                To = "Варшава",
                Price = 300,
                IsAvailable = true
            },
            new Flight
            {
                Id = 3,
                Number = "B2-303",
                From = "Минск",
                To = "Стамбул",
                Price = 450,
                IsAvailable = false
            }
        };

        view = new FlightView();
    }

    public void Index()
    {
        view.ShowFlights(flights);
    }

    public void Show(int id)
    {
        var flight = flights.FirstOrDefault(f => f.Id == id);

        if (flight == null)
        {
            view.ShowMessage("Рейс не найден.");
            return;
        }

        view.ShowFlight(flight);
    }

    public void Add(Flight flight)
    {
        flights.Add(flight);
        view.ShowMessage("Рейс успешно добавлен.");
    }

    public void Delete(int id)
    {
        var flight = flights.FirstOrDefault(f => f.Id == id);

        if (flight == null)
        {
            view.ShowMessage("Рейс не найден.");
            return;
        }

        flights.Remove(flight);
        view.ShowMessage("Рейс успешно удалён.");
    }

        public void ShowAvailable()
    {
        var result = flights
            .Where(f => f.IsAvailable)
            .ToList();

        view.ShowFlights(result);
    }
        public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1. Показать рейсы");
            Console.WriteLine("2. Найти рейс");
            Console.WriteLine("3. Добавить рейс");
            Console.WriteLine("4. Удалить рейс");
            Console.WriteLine("5. Рейсы с местами");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Index();
                    break;
                case "2":
                    ShowFlightByUserInput();
                    break;
                case "3":
                    AddFlightByUserInput();
                    break;
                case "4":
                    DeleteFlightByUserInput();
                    break;
                case "5":
                    ShowAvailable();
                    break;
                case "0":
                    return;
                default:
                    view.ShowMessage("Неизвестная команда.");
                    break;
            }
        }
    }

    private void ShowFlightByUserInput()
    {
        Console.Write("Введите ID рейса: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Show(id);
    }

    private void AddFlightByUserInput()
    {
        Console.Write("Введите ID рейса: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Console.Write("Введите номер рейса: ");
        var number = Console.ReadLine() ?? "";

        Console.Write("Откуда: ");
        var from = Console.ReadLine() ?? "";

        Console.Write("Куда: ");
        var to = Console.ReadLine() ?? "";

        Console.Write("Цена: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            view.ShowMessage("Некорректная цена.");
            return;
        }

        Console.Write("Есть места? (да/нет): ");
        var answer = Console.ReadLine() ?? "";
        var isAvailable = answer.Trim().ToLower() is "да" or "yes" or "y";

        Add(new Flight
        {
            Id = id,
            Number = number,
            From = from,
            To = to,
            Price = price,
            IsAvailable = isAvailable
        });
    }

    private void DeleteFlightByUserInput()
    {
        Console.Write("Введите ID рейса: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Delete(id);
    }
}