// Create a deck of cards
// Randomly deal 5 cards
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using DeckLibrary;
using Spectre.Console;

Console.OutputEncoding = Encoding.UTF8;

string[] cards = new string[52];
cards = Deck.GetDeck();
//cards = ["\U0001F0A1", "\U0001F0A2", "\U0001F0A3", "\U0001F0A4", "\U0001F0A5", "\U0001F0A6", "\U0001F0A7", "\U0001F0A8", "\U0001F0A9", "\U0001F0AA", "\U0001F0AB",
//"\U0001F0AD","\U0001F0AE","\U0001F0B1", "\U0001F0B2", "\U0001F0B3", "\U0001F0B4", "\U0001F0B5", "\U0001F0B6", "\U0001F0B7", "\U0001F0B8", "\U0001F0B9", "\U0001F0BA", "\U0001F0BB",
//"\U0001F0BD","\U0001F0BE","\U0001F0C1", "\U0001F0C2", "\U0001F0C3", "\U0001F0C4", "\U0001F0C5", "\U0001F0C6", "\U0001F0C7", "\U0001F0C8", "\U0001F0C9", "\U0001F0CA", "\U0001F0CB",
//"\U0001F0CD","\U0001F0CE","\U0001F0D1", "\U0001F0D2", "\U0001F0D3", "\U0001F0D4", "\U0001F0D5", "\U0001F0D6", "\U0001F0D7", "\U0001F0D8", "\U0001F0D9", "\U0001F0DA", "\U0001F0DB",
//"\U0001F0DD","\U0001F0DE"];

// string test = "\U0001F0A1";
// Console.OutputEncoding = Encoding.UTF8;
// Console.WriteLine(test);
// Random rng = new Random();

AnsiConsole.Markup("[underline red]Hello[/] World!");
Console.WriteLine("");

// options
// show a shuffled deck
// deal cards from shuffled deck/how many cards

// prompt/present a menu
bool toContinue = true;
do
{
    var menuPrompt = new SelectionPrompt<string>()
           .Title("What can I do for you?")
           .PageSize(5)
           .AddChoices(
                   [
                    "Show me a new deck",
                 "Show me a shuffled deck",
                 "Deal me some cards",
                 "Quit"
                   ]
               );

    Style myStyle = new Style(Color.Salmon1, Color.Yellow);
    menuPrompt.HighlightStyle = myStyle;

    string choice = AnsiConsole.Prompt<string>(menuPrompt);

    //var choice = AnsiConsole.Prompt(
    //    new SelectionPrompt<string>()
    //    .Title("What can I do for you?")
    //    .PageSize(10)
    //    .AddChoices(new[]
    //    {
    //        "Show me a new deck",
    //        "Show me a shuffled deck",
    //        "Deal me some cards",
    //    }));

    switch (choice)
    {
        case "Show me a new deck": ShowDeck(); break;
        case "Show me a shuffled deck": ShowShuffledDeck(); break;
        case "Deal me some cards": DealCards(); break;
        default:
            toContinue = false;
            break;
    }
} while (toContinue);
void DealCards()
{
    // mine

    //bool acceptedEntry = false;
    //var deckToUse = Deck.GetDeck();
    //do
    //{
    //    // make a text prompt for int number of cards
    //    int cardsDrawn = AnsiConsole.Prompt(
    //        new TextPrompt<int>("How many cards do you want to draw (between 1-52)?"));
    //    if (cardsDrawn > 52 || cardsDrawn < 1)
    //    {
    //        Console.WriteLine("Please enter a valid number between 1 and 52 inclusive");
    //        continue;
    //    }
    //    else
    //    {
    //        Console.WriteLine("Here are your cards:");
    //        string[] drawnCards = Deck.DrawCards(ref deckToUse, cardsDrawn);
    //        foreach (var card in drawnCards)
    //        {
    //            Console.WriteLine($"{card}");
    //        }
    //        acceptedEntry = true;
    //    }
    //} while (!acceptedEntry);

    // Victors

    int numberOfCards = 0;
    var aDeck = Deck.GetDeck();

    TextPrompt<int> numberOfCardsPrompt = new TextPrompt<int>("How many cards would you like?");
    numberOfCardsPrompt.AllowEmpty = false;
    numberOfCardsPrompt.DefaultValue(5);
    numberOfCardsPrompt.ShowDefaultValue(true);

    //numberOfCardsPrompt.Validate(blah, "A deck has only 52 cards, please enter a sensible value.");
    numberOfCardsPrompt.Validate(
        (int i) => (i >= 1 && i <=aDeck.Length) // lambda expression
        , $"A deck has only 52 cards, please enter a sensible value."); // runs at the same scope at which it is defined, not another stack on top
    // how about an expression that can define a method

    numberOfCards = AnsiConsole.Prompt<int>(numberOfCardsPrompt);
    Deck.Shuffle(aDeck);
    var cards = Deck.DrawCards(ref aDeck, numberOfCards);
    DisplaySpectreTable(cards);
    //foreach (var card in cards)
    //{
    //    Console.OutputEncoding = Encoding.Unicode;
    //    Console.WriteLine(card);
    //}

}

void ShowShuffledDeck()
{
    var aDeck = Deck.GetDeck();
    Deck.Shuffle(aDeck);
    DisplaySpectreTable(aDeck);
}

void ShowDeck()
{
    var aDeck = Deck.GetDeck();
    DisplaySpectreTable(aDeck);
}


void MyDisplaySpectreTable(string[] cardsToDisplay)
{
    var cardTable = new Table();

    cardTable.AddColumn("Cards");
    foreach (string card in cardsToDisplay)
    {
        cardTable.AddRow($"{card}");
        //if (card.Substring(0, 2) == '♦' || card.Substring(0, 2) == '♥')
        //{
        //    cardTable.AddRow($"[red]{card}[/]");
        //}
        //else
        //{
        //    cardTable.AddRow($"{card}");
        //}
    }
    AnsiConsole.Write(cardTable);
}

//string[] myCards = Deck.MyChooseRandom5(cards);
//Console.WriteLine("Here is your hand:");
//Console.WriteLine("");
//foreach (string card in myCards)
//{
//    Console.Write(card);
//}
//Console.WriteLine("");
//Console.WriteLine("Good luck");
//var font = FigletFont.Load("starwars.flf");
//AnsiConsole.Write(new FigletText("MAY THE FORCE BE WITH YOU...").LeftJustified().Color(Color.Red));

//bool blah(int i)
//{
//    return (i >= 1 && i <= 52);
//}

void DisplaySpectreTable(string[] cardsToDisplay)
{
    var outputTable = new Table();
    outputTable.Caption = new TableTitle("©️2025");
    outputTable.Centered()
        .RoundedBorder();
    outputTable.AddColumn("Suit");
    outputTable.AddColumn("Rank");


    foreach (var card in cardsToDisplay)
    {
        string color = card[0] switch
        {
            '♥' => "red",
            '♦' => "fuchsia",
            '♣' => "green",
            '♠' => "blue",
            _ => "black"
        };
        outputTable.AddRow(
            [new Markup($"[{color}]{card[0]}[/]"), new Markup(card[1].ToString())]);


    }

    AnsiConsole.Write(outputTable);

}