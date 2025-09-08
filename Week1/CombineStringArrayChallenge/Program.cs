string[] values = { "12.3", "45", "ABC", "11", "DEF" };
string message = "";
decimal total = 0m;

foreach (var x in values)
{
    decimal number;
    if (decimal.TryParse(x, out number))
    {
        total += number;
    }
    else
    {
        message += x;
    }
}

Console.WriteLine($"Message: {message}");
Console.WriteLine($"Total: {total}");
