using System.Text;
using wt_lab3_3mvc_sudinko.Controllers;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

var controller = new FlightController();

controller.Run();