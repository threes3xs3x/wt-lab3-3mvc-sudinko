namespace wt_lab3_3mvc_sudinko.Models;

public class Flight
{
    public int Id { get; set; }
    public string Number { get; set; } = "";
    public string From { get; set; } = "";
    public string To { get; set; } = "";
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
}