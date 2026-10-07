using wt_lab3_3mvc_sudinko.Models;

namespace wt_lab3_3mvc_sudinko.Views;

public class FlightView
{
    public void ShowFlights(List<Flight> flights)
    {
        Console.WriteLine("=== СПИСОК РЕЙСОВ ===");

        foreach (var flight in flights)
        {
            Console.WriteLine(
                $"{flight.Id}. " +
                $"{flight.Number} | " +
                $"{flight.From} - {flight.To} | " +
                $"{flight.Price} руб. | " +
                $"Есть места: {flight.IsAvailable}"
            );
        }
    }

    public void ShowFlight(Flight flight)
    {
        Console.WriteLine("=== РЕЙС ===");
        Console.WriteLine($"ID: {flight.Id}");
        Console.WriteLine($"Номер рейса: {flight.Number}");
        Console.WriteLine($"Откуда: {flight.From}");
        Console.WriteLine($"Куда: {flight.To}");
        Console.WriteLine($"Цена: {flight.Price} руб.");
        Console.WriteLine($"Есть места: {flight.IsAvailable}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}