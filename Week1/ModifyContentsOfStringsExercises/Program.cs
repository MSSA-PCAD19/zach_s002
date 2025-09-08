//string message = "Find what is (inside the parentheses)";

//int openingPosition = message.IndexOf('(');
//int closingPosition = message.IndexOf(')');

//Console.WriteLine(openingPosition);
//Console.WriteLine(closingPosition);
//openingPosition += 1;
//int length = closingPosition - openingPosition;
//Console.WriteLine(message.Substring(openingPosition, length));

//string message = "What is the value <span>between the tags</span>?";

//const string openSpan = "<span>";
//const string closeSpan = "</span>";

//int openingPosition = message.IndexOf(openSpan);
//int closingPosition = message.IndexOf(closeSpan);

//openingPosition += openSpan.Length;
//int length = closingPosition - openingPosition;
//Console.WriteLine(message.Substring(openingPosition, length));

//string message = "hello there!";

//int first_h = message.IndexOf('h');
//int last_h = message.LastIndexOf('h');

//Console.WriteLine($"For the message: '{message}', the first 'h' is at position {first_h} and the last 'h' is at position {last_h}");

//string message = "(What if) I am (only interested) in the last (set of parenthesis)?";
//int openingPosition = message.LastIndexOf('(');

//openingPosition += 1;
//int closingPosition = message.LastIndexOf(')');
//int length = closingPosition - openingPosition;
//Console.WriteLine(message.Substring(openingPosition, length));

//string message = "(What if) there are (more than) one (set of parentheses)?";
//while (true)
//{
//    int openingPosition = message.IndexOf('(');
//    if (openingPosition == -1) break;
//
//    openingPosition += 1;
//    int closingPosition = message.IndexOf(')');
//    int length = closingPosition - openingPosition;
//    Console.WriteLine(message.Substring(openingPosition, length));
//
// Note the overload of the Substring to return only the remaining
// unprocessed message
//    message = message.Substring(closingPosition + 1);
//}

//string message = "Hello, world!";
//char[] charsToFind = { 'a', 'e', 'i' };

//int index = message.IndexOfAny(charsToFind);

//Console.WriteLine($"Found '{message[index]}' in '{message}' at index: {index}.");

//string message = "Help (find) the {opening symbols}";
//Console.WriteLine($"Searching THIS message: {message}");
//char[] openSymbols = { '[', '{', '(' };
//int startPosition = 5;
//int openingPosition = message.IndexOfAny(openSymbols);
//Console.WriteLine($"Found WITHOUT using startPosition: {message.Substring(openingPosition)}");

//openingPosition = message.IndexOfAny(openSymbols, startPosition);
//Console.WriteLine($"Found WITH using startPosition {startPosition}: {message.Substring(openingPosition)}");

//string data = "12345John Smith          5000  3  ";
//string updatedData = data.Remove(5, 20);
//Console.WriteLine(updatedData);

//string message = "This--is--ex-amp-le--data";
//message = message.Replace("--", " ");
//message = message.Replace("-", "");
//Console.WriteLine(message);

const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

//string quantity = $"Quantity: {input.Substring(openingPosition, length)}";
//string output = $"";
// work here

// extract quantity

const string openSpan = "<span>";
const string closeSpan = "</span>";

int openingPosition = input.IndexOf(openSpan);
int closingPosition = input.IndexOf(closeSpan);
openingPosition += openSpan.Length;

int length = closingPosition - openingPosition;

// extract output

string output = input;

const string openDiv = "<div>";
const string closeDiv = "</div";

output = output.Replace(openDiv, "");
output = output.Replace(closeDiv, "");
output = output.Replace("&trade", "&reg");



string quantityPrint = $"Quantity: {input.Substring(openingPosition, length)}";
string outputPrint = $"Output: {output}";

Console.WriteLine(quantityPrint);
Console.WriteLine(outputPrint);
