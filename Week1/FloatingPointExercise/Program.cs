//Console.WriteLine("");
//Console.WriteLine("Floating point types:");
//Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
//Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
//Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");


Console.WriteLine("Floating point types:");
Console.WriteLine($"float  : {float.MinValue,30:N0} to {float.MaxValue,30:N0} (with ~6-9 digits of precision)");
Console.WriteLine($"double : {double.MinValue,30:N0} to {double.MaxValue,30:N0} (with ~15-17 digits of precision)");
Console.WriteLine($"decimal: {decimal.MinValue,30:N0} to {decimal.MaxValue,30:N0} (with 28-29 digits of precision)");

