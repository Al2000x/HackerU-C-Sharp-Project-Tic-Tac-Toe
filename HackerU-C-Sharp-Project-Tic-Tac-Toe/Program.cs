using System;
using System.Linq;
using System.Numerics;

namespace MyApp
{
    // Hello This is a project for hackeru campus
    //This will demonstrate my skills of making a tic tac toe game from scratch
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(
                "**************************************************************\r\n" +
                "INSTRUCTIONS:\r\n" +
                "Welcome to Tic Tac Toe\r\n" +
                "The game is played on a grid that's 3 squares by 3 squares.\r\n" +
                "You will pick either X or O the oponent against you will get the choice you didn't pick.\r\n" +
                "Players take turns putting their marks in empty squares.\r\n" +
                "The first player to get 3 of her marks in a row (up, down, across, or diagonally) is the winner.\r\n" +
                "When all 9 squares are full, the game is over.\r\n" +
                "**************************************************************\n\n");
            TicTacToeGame();
        }
        static void TicTacToeGame()
        {
            //character selection section
            Console.WriteLine("***********************************************************");
            //player1
            string playerName1 = PlayerAssign(1);
            string p1 = PlayersChoice(playerName1);
            //player1

            //player2
            string playerName2 = PlayerAssign(2);
            string p2;
            string firstPlayerInGame;
            string secondPlayerInGame;
            if (p1 == "X")
            {
                p2 = "O";
                firstPlayerInGame = playerName1;
                secondPlayerInGame = playerName2;
            }
            else
            {
                p2 = "X";
                firstPlayerInGame = playerName2;
                secondPlayerInGame = playerName1;

            }
            Console.WriteLine($"Acknowledge {playerName2} you're assigned {p2} thanks to {playerName1}");
            //player2
            Console.WriteLine("**************************************************************\n\n");
            //character selection section

            // game section

            Console.Clear();

            Console.WriteLine($"{playerName1.ToUpper()} AND {playerName2.ToUpper()} LET THE GAMES BEGIN!!");
            bool compleateGameFlag = false;

            double gameTurnNum = 0;
            double p1Turn = 0;
            double p2Turn = 0;
            double[] player1PicksArr = new double[5];
            double[] player2PicksArr = new double[5];
            char[] gameArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool p1WonGame = false;
            while (compleateGameFlag == false)
            {
                if (gameTurnNum % 2 == 0)
                {
                    Console.WriteLine(
                        "***********************************\n" +
                        "*          |           |          *\n" +
                        "*          |           |          *\n" +
                       $"*    {gameArray[0]}     |     {gameArray[1]}     |     {gameArray[2]}    *\n" +
                        "*   (1)    |    (2)    |    (3)   *\n" +
                        "*          |           |          *\n" +
                        "*----------|-----------|----------*\n" +
                        "*          |           |          *\n" +
                        "*          |           |          *\n" +
                       $"*    {gameArray[3]}     |     {gameArray[4]}     |     {gameArray[5]}    *\n" +
                        "*   (4)    |    (5)    |    (6)   *\n" +
                        "*          |           |          *\n" +
                        "*----------|-----------|----------*\n" +
                        "*          |           |          *\n" +
                        "*          |           |          *\n" +
                       $"*   {gameArray[6]}      |     {gameArray[7]}     |     {gameArray[8]}    *\n" +
                        "*   (7)    |    (8)    |    (9)   *\n" +
                        "*          |           |          *\n" +
                        "***********************************\n");

                    double pInput = PlayersInput(secondPlayerInGame, firstPlayerInGame, player1PicksArr, player2PicksArr, gameTurnNum);
                    gameArray[(int)pInput - 1] = 'X';
                    player1PicksArr[(int)p1Turn] = pInput;
                    p1WonGame = WinStateChecker(player1PicksArr, player2PicksArr);
                    Console.WriteLine($"{firstPlayerInGame} picked {pInput}\n\n");
                    p1Turn++;




                }
                else
                {
                    Console.WriteLine(
                         "***********************************\n" +
                         "*          |           |          *\n" +
                         "*          |           |          *\n" +
                        $"*    {gameArray[0]}     |     {gameArray[1]}     |     {gameArray[2]}    *\n" +
                         "*   (1)    |    (2)    |    (3)   *\n" +
                         "*          |           |          *\n" +
                         "*----------|-----------|----------*\n" +
                         "*          |           |          *\n" +
                         "*          |           |          *\n" +
                        $"*    {gameArray[3]}     |     {gameArray[4]}     |     {gameArray[5]}    *\n" +
                         "*   (4)    |    (5)    |    (6)   *\n" +
                         "*          |           |          *\n" +
                         "*----------|-----------|----------*\n" +
                         "*          |           |          *\n" +
                         "*          |           |          *\n" +
                        $"*   {gameArray[6]}      |     {gameArray[7]}     |     {gameArray[8]}    *\n" +
                         "*   (7)    |    (8)    |    (9)   *\n" +
                         "*          |           |          *\n" +
                         "***********************************\n");


                    double pInput = PlayersInput(secondPlayerInGame, firstPlayerInGame, player1PicksArr, player2PicksArr, gameTurnNum);
                    gameArray[(int)pInput - 1] = 'O';
                    player2PicksArr[(int)p2Turn] = pInput;
                    Console.WriteLine($"{secondPlayerInGame} picked {pInput}\n\n");
                    p2Turn++;

                }
                gameTurnNum++;
                if (p1WonGame == true)
                {
                    Console.WriteLine($"CONGRATULATIONS {firstPlayerInGame.ToUpper()} YOU HAVE PREVAILED AND WON THE GAME!!!!!! ♥♥♥♥♥♥♥");
                    break;
                }
                else if (gameTurnNum == 9)
                {
                    compleateGameFlag = true;
                    Console.WriteLine("no one wins you both suck");
                }
            }
        }


        static bool WinStateChecker(double[] player1PicksArr, double[] player2PicksArr)
        {
            if (player1PicksArr.Contains(1) && player1PicksArr.Contains(2) && player1PicksArr.Contains(3) ||
                player2PicksArr.Contains(1) && player2PicksArr.Contains(2) && player2PicksArr.Contains(3) ||
                player1PicksArr.Contains(4) && player1PicksArr.Contains(5) && player1PicksArr.Contains(6) ||
                player2PicksArr.Contains(4) && player2PicksArr.Contains(5) && player2PicksArr.Contains(6) ||
                player1PicksArr.Contains(7) && player1PicksArr.Contains(8) && player1PicksArr.Contains(9) ||
                player2PicksArr.Contains(7) && player2PicksArr.Contains(8) && player2PicksArr.Contains(9) ||
                player1PicksArr.Contains(1) && player1PicksArr.Contains(4) && player1PicksArr.Contains(7) ||
                player2PicksArr.Contains(1) && player2PicksArr.Contains(4) && player2PicksArr.Contains(7) ||
                player1PicksArr.Contains(2) && player1PicksArr.Contains(5) && player1PicksArr.Contains(8) ||
                player2PicksArr.Contains(2) && player2PicksArr.Contains(5) && player2PicksArr.Contains(8) ||
                player1PicksArr.Contains(3) && player1PicksArr.Contains(6) && player1PicksArr.Contains(9) ||
                player2PicksArr.Contains(3) && player2PicksArr.Contains(6) && player2PicksArr.Contains(9) ||
                player1PicksArr.Contains(1) && player1PicksArr.Contains(5) && player1PicksArr.Contains(9) ||
                player2PicksArr.Contains(1) && player2PicksArr.Contains(5) && player2PicksArr.Contains(9) ||
                player1PicksArr.Contains(3) && player1PicksArr.Contains(5) && player1PicksArr.Contains(7) ||
                player2PicksArr.Contains(3) && player2PicksArr.Contains(5) && player2PicksArr.Contains(7))
            {
                return true;
            }
            else return false;
        }
        static double PlayersInput(string playerName2, string playerName1, double[] player1PicksArr, double[] player2PicksArr, double turnNum)
        {
            if (turnNum % 2 == 0)
            {

                double playerInput = -1;
                Console.WriteLine($"{playerName1} make your choice based on the numbers on the playing board");
                while (playerInput <= 0 || playerInput >= 0)
                {
                    double.TryParse(Console.ReadLine(), out double num);
                    playerInput = num;
                    if (turnNum >= 1)
                    {
                        while (player1PicksArr.Contains(playerInput) || player2PicksArr.Contains(playerInput))
                        {
                            Console.WriteLine("this number already got picked");
                            double.TryParse(Console.ReadLine(), out double newPlayerInput);
                            playerInput = newPlayerInput;

                        }

                    }
                    if (playerInput <= 0 || playerInput >= 10)
                    {
                        Console.WriteLine("Remember you can pick between 1-9");

                    }
                    else
                    {
                        break;
                    }
                }
                Console.Clear();
                return playerInput;

            }
            else
            {
                double playerInput = -1;
                Console.WriteLine($"{playerName2} make your choice based on the numbers on the playing board");
                while (playerInput <= 0 || playerInput >= 0)
                {
                    double.TryParse(Console.ReadLine(), out double num);
                    playerInput = num;

                    while (player1PicksArr.Contains(playerInput) || player2PicksArr.Contains(playerInput))
                    {
                        Console.WriteLine("this number already got picked");
                        double.TryParse(Console.ReadLine(), out double newPlayerInput);
                        playerInput = newPlayerInput;

                    }
                    if (playerInput <= 0 || playerInput >= 10)
                    {
                        Console.WriteLine("Remember you can pick between 1-9");

                    }
                    else
                    {
                        break;
                    }
                }
                Console.Clear();
                return playerInput;
            }
        }



        static string PlayersChoice(string playerName1)
        {
            Console.WriteLine($"Dear {playerName1} please choose if you're X or O");
            string Choice = Console.ReadLine();
            while (Choice != "X" && Choice != "O")
            {
                Console.WriteLine("Remember your only choices are ('X' or 'O')");
                Choice = Console.ReadLine();
            }
            Console.WriteLine(playerName1 + " you picked " + Choice);

            return Choice;
        }


        static string PlayerAssign(int playerNum)
        {
            Console.WriteLine($"Player {playerNum} state your name no numbers allowed");
            bool player1Info = false;
            bool firstIteration = true;
            while (player1Info == false)
            {
                if (firstIteration == false)
                {
                    Console.WriteLine("Remember no numbers!");
                    Console.WriteLine("try again");
                }
                bool intFlag = false;
                string player = Console.ReadLine();
                int i = 9;
                while (i >= 0)
                {
                    if (player.IndexOf($"{i}") >= 0)
                    {
                        intFlag = true;
                    }
                    i--;
                };
                if (intFlag == false)
                {
                    Console.WriteLine($"hello {player}");
                    player1Info = true;
                    return player;
                };
                firstIteration = false;
            };
            return null;
        }

    }
}