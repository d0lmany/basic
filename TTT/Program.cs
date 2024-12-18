
char[] board = [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '];
char player = 'X', winner = ' '; bool isGameOver = false;
while (!isGameOver)
{
    ShowBoard(board);
    board[Ask(board, player)] = player;
    if (CheckWin(board, player))
    {
        isGameOver = true;
        winner = player;
    }
    else if (isDraw(board))
    {
        isGameOver = true;
        winner = ' ';
    }
    player = (player == 'X') ? 'O' : 'X';
}

static bool isDraw(char[] board)
{
    foreach (char c in board){
        if (c == ' '){
            return false;
        }
    }
    return true;
}

static bool CheckWin(char[] board, char player)
{
    return (board[0] == player && board[1] == player && board[2] == player) ||
           (board[3] == player && board[4] == player && board[5] == player) ||
           (board[6] == player && board[7] == player && board[8] == player) ||
           (board[0] == player && board[3] == player && board[6] == player) ||
           (board[1] == player && board[4] == player && board[7] == player) ||
           (board[2] == player && board[5] == player && board[8] == player) ||
           (board[0] == player && board[4] == player && board[8] == player) ||
           (board[2] == player && board[4] == player && board[6] == player);
}

if (isGameOver)
{
    ShowBoard(board);
    Console.WriteLine($"Game Over!\n{winner} wins!!");
}
static void ShowBoard(char[] mas)
{
    Console.Clear();
    Console.WriteLine($" {mas[0]} | {mas[1]} | {mas[2]}");
    Console.WriteLine("-----------");
    Console.WriteLine($" {mas[3]} | {mas[4]} | {mas[5]}");
    Console.WriteLine("-----------");
    Console.WriteLine($" {mas[6]} | {mas[7]} | {mas[8]}");
}
static int Ask(char[] board, char man)
{
    Console.WriteLine($"Where is {man} going?\nEnter a number of cell:");
    int choice = int.Parse(Console.ReadLine())-1;
    if (choice > 9)
    {
        Console.WriteLine("It's a big num!\nTry again");
        return Ask(board, man);
    }
    if (board[choice] == ' ')
    {
        return choice;
    }
    else
    {
        Console.WriteLine("You select a busy cell, try again");
        return Ask(board, man);
    }
}