
using TicTacToe;

// create an array 2-dim 3x3 char
// each slot should be initialized to nullable char represented by char?
// this means the absence of data is meaningful
// for ex, in group 5, 4, null, 3, 2, 1 the avg will be calculated at 15/5, it does not count the null
// note in C# nulls are equal to each other


char?[,] board = Game.GetBoard();
// int? x = null; // cannot initialize regular int to null, because null means referencing nothing
// this would be the same: Nullable<int>;

// display the board

Game.DisplayBoard(board);

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
while (Game.PlaceNextHand(board,nextHand)) // PlaceNextHand Prompt user for the position after collecting potition
    // reprint the board
{
    // flip nextHand from O => X and X => O
    Game.DisplayBoard(board);
    nextHand = nextHand == 'O' ? 'X' : 'O';
}

Console.WriteLine($"Game ends in {Game.DetermineOutcome(board)}");
Game.DisplayBoard(board);


string outcome = Game.DetermineOutcome(board); //O wins, X wins, or draw
// display outcome
// First Attempt, we will write all methods as local functions
// challenges
// 1- code not testable
// 2- no seperation of functionality and UI
// 3- can not automate interactions
// 4- code is not reusable




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
                        if (Game.BoardHasSpace(board))
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


