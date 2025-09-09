
// create an array 2-dim 3x3 char
// each slot should be initialized to nullable char represented by char?
// this means the absence of data is meaningful
// for ex, in group 5, 4, null, 3, 2, 1 the avg will be calculated at 15/5, it does not count the null
// note in C# nulls are equal to each other


char?[,] board = GetBoard();
// int? x = null; // cannot initialize regular int to null, because null means referencing nothing
// this would be the same: Nullable<int>;

// display the board

DisplayBoard(board);

// ===================
// |  X  |  O  |     |
// ===================
// |     |     |     |
// ===================
// |     |     |     |
// ===================
// etc

// O starts first, collect position using row,col O = 1,0 and X = 0,0
char nextHand = 'O';
while (PlaceNextHand(board,nextHand)) // PlaceNextHand Prompt user for the position after collecting potition
    // reprint the board
{
    // flip nextHand from O => X and X => O
    DisplayBoard(board);
    nextHand = nextHand == 'O' ? 'X' : 'O';
}

Console.WriteLine($"Game ends in {DetermineOutcome(board)}");
DisplayBoard(board);


string outcome = DetermineOutcome(board); //O wins, X wins, or draw
// display outcome
// First Attempt, we will write all methods as local functions
// challenges
// 1- code not testable
// 2- no seperation of functionality and UI
// 3- can not automate interactions
// 4- code is not reusable

char?[,] GetBoard() => new char?[3, 3];

void DisplayBoard(char?[,] board)
{
    var hr = new string('-', 20);
    Console.WriteLine(hr);

    for (int row = 0; row < board.GetLength(0); row++)
    {
        Console.Write('|');
        for (int col = 0; col < board.GetLength(1); col++)
        {
            char? piece;
            if (board[row, col] is not null)
                piece = board[row, col];
            else
                piece = '_';

            Console.Write($"  {piece}  |");

        }
        Console.WriteLine($"\n{hr}");
    }
}

bool PlaceNextHand(char?[,] board, char nextHand)
{
    bool piecePlaced = false;
    do
    {
        Console.WriteLine($"{nextHand} player, please place your next piece with row col e.g 0 1 for row 0 col 1");
        string input = Console.ReadLine();
        int row = int.Parse(input.Split(' ')[0]);
        int col = int.Parse(input.Split(' ')[1]);
        if (board[row, col] is null)
        {
            board[row, col] = nextHand;
            break;
        }
        else
        {
            Console.WriteLine($"Position {row} {col} is already occupied by {board[row, col]}");
            continue;
            Console.WriteLine("You should not see this, because continue skips ahead to the next iteration");
        }
    } while (true);
    return BoardHasSpace(board) && DetermineOutcome(board) == "Continue";
}

bool BoardHasSpace(char?[,] board)
{
    //for (int row = 0; row < board.GetLength(0); row++)
    //{
    //    for (int col = 0; col < board.GetLength(1); col++)
    //    {
    //       if (board[row, col] == null)
    //        {
    //            return true;
    //        }


    //    }
    //}

    //alt

    foreach (char? item in board) // this will loop across ALL items in all dimensions
    {
        if (!item.HasValue)
        {
            return true;
        }
    }
    return false;
}

// mine
string DetermineOutcomeMine(char?[,] board)
{
    string response = "";
    bool winner = false;
    bool gameOver = false;
    // check rows
    for (int i = 0; i < board.GetLength(0); i++)
    {
        if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
        {
            response = $"{board[i, 0]} wins";
            winner = true;
            gameOver = true;
        }
        // check columns
        else
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[0, j] == board[1, j] && board[1, j] == board[2, j])
                {
                    response = $"{board[0, j]} wins";
                    winner = true;
                    gameOver = true;
                }
                // check diagonals
                else
                {
                    if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) || (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]))
                    {
                        response = $"{board[1, 1]} wins";
                        winner = true;
                        gameOver = false;
                    }
                    // check for game over
                    else
                    {
                        if (BoardHasSpace(board))
                        {
                            response = "Continue";
                            winner = false;
                            gameOver = false;
                        }
                        else
                        {
                            response = "Draw (board full)";
                            winner = false;
                            gameOver = true;
                        }
                    }
                }
            }
        }
    }
    // must return - "O wins" or "X wins" or "Draw"(board full) or "Continue"
    return response;
}


// Victor's
string DetermineOutcome(char?[,] board)
{
    //check rows
    //check cols
    //check diag
    // - "O wins"
    // - "X wins"
    // - "Draw" when board is full and no win
    // - "Continue" when board is NOT full and no win
    string[] lines = new string[8];

    lines[0] = $"{board[0, 0]}{board[0, 1]}{board[0, 2]}"; //row 0
    lines[1] = $"{board[1, 0]}{board[1, 1]}{board[1, 2]}"; //row 1
    lines[2] = $"{board[2, 0]}{board[2, 1]}{board[2, 2]}"; //row 2

    //lines[3] = $"{board[0,0]}{board[1,0]}{board[2,0]}"; //col 0
    //lines[4] = $"{board[0,1]}{board[1,1]}{board[2,1]}"; //col 1
    //lines[5] = $"{board[0,2]}{board[1,2]}{board[2,2]}"; //col 2
    for (int i = 0; i < board.GetLength(1); i++)
    {
        lines[i + 3] = $"{board[0, i]}{board[1, i]}{board[2, i]}";
    }

    lines[6] = $"{board[0, 0]}{board[1, 1]}{board[2, 2]}"; //diag \
    lines[7] = $"{board[0, 2]}{board[1, 1]}{board[2, 0]}"; //diag /
    foreach (var item in lines)
    {
        if (item == "OOO")
            return "O wins";

        if (item == "XXX")
            return "X wins";
    }
    // no wins
    if (BoardHasSpace(board))
        return "Continue";
    else
        return "Draw";
}
