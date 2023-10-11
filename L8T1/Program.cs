using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_Crosses
{
    internal class Program
    {
        static int[] go(string player, string[,] board)
        {
            int x, y;
            bool invalid = false;
            List<String> stringCoords;
            bool xSuccess = false;
            bool ySuccess = false;
            bool spaceFree = true;
            do
            {
                if (invalid){
                    Console.WriteLine("Invalid Input!");
                }
                if (!spaceFree) {
                    Console.WriteLine("There is already a symbol there!");
                }

                invalid = false;
                spaceFree = true;
                Console.WriteLine($"{player}, input your go in the form x, y");
                stringCoords = Console.ReadLine().Split(',').ToList();

                for (int i = 0; i < stringCoords.Count; i++)
                {
                    stringCoords[i] = stringCoords[i].Trim();
                }
                try {
                    xSuccess = int.TryParse(stringCoords[0], out x);
                    ySuccess = int.TryParse(stringCoords[1], out y);
                } catch (ArgumentOutOfRangeException e){
                Console.WriteLine("Falied Conversion");
                    ySuccess = false;
                    xSuccess = false;
                    x = 0;
                    y = 0;
                }
                if (xSuccess == true && ySuccess == true && x > 0 && x < 4 && y > 0 && y < 4){
                    Console.WriteLine(board[y-1,x-1]);
                    spaceFree = (board[y-1, x-1] == " ");
                    invalid = !spaceFree;
                } else {
                    invalid = true;
                }
            } while (invalid);
            return new int[] {x-1, y-1};
        }

        static bool printBoard(string[,] board)
        {
            bool returnVal = false;
            string player = "hi";
            int emptys = 0;
            Console.WriteLine("   1| 2| 3|");
            for (int i = 0;i < board.GetLength(0); i++)
            {
                Console.Write($"{i+1}| ");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i,j] + "| ");
                    emptys += board[i,j] == " " ? 1 : 0;
                }
                Console.WriteLine();
                if (board[0, i] != " " && board[0, i] == board[1, i] && board[1, i] == board[2, i] ) {
                    player = board[0,i] == "x" ? "Player 1" : "Player 2";
                    returnVal = true;
                }
                if (board[i, 0] != " " && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] ){
                    player = board[i,0] == "x" ? "Player 1" : "Player 2";
                    returnVal = true;
                }                
            }
            if (board[1, 1] != " " && ((board[0,0] == board[1,1] && board[1,1] == board[2,2]) || (board[2,0] == board[1,1] && board[1,1] == board[0,2]))) {
                player = board[1,1] == "x" ? "Player 1" : "Player 2";
                returnVal = true;
            }
            if (returnVal) {
                Console.WriteLine($"{player} has won!");
            } else if (emptys < 1){
                Console.WriteLine("Draw!");
                returnVal = true;
            }
            return returnVal;
        }

        static void Main(string[] args)
        {
            string[,] board = { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
            bool won = false;
            int[] coords;
            while (true)
            {
                coords = go("Player 1", board);
                board[coords[1], coords[0]] = board[coords[1], coords[0]] != "o" ? "x": "o";
                won = printBoard(board);
                if (won){
                    Environment.Exit(0);
                }
                coords = go("Player 2", board);
                board[coords[1], coords[0]] = board[coords[1], coords[0]] != "x" ? "o" : "x";
                won = printBoard(board);
                if (won){
                    Environment.Exit(0);
                }
            }
        }
    }
}