using System;

namespace SnakeAndLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NO_PLAY = 1;
            const int LADDER = 2;
            const int SNAKE = 3;
            const int winningPosition = 100;
            int checkingThePosition = 0;
            Console.WriteLine("Welcome to snake and Ladder Game");
            //int currentPosition = 0;
            int iterationNo = 1;
            int noOfPlayers = 2;
            int[] currentPosition = new int[noOfPlayers];
            for (int item = 0; item < currentPosition.Length; item++)
            {
                currentPosition[item] = 0;
            }
            int playersCount = 0;
            Random random = new Random();
            //do
            //{
            //for (int playersCount = 0; playersCount < noOfPlayers; playersCount++)
            while (currentPosition[playersCount] < winningPosition)
            {
                do
                {
                    int RollingDieNumber = random.Next(1, 7);
                    checkingThePosition = random.Next(1, 4);
                    switch (checkingThePosition)
                    {
                        case LADDER:
                            if (currentPosition[playersCount] + RollingDieNumber > winningPosition)
                            {
                                Console.WriteLine($"no is getting greater than 100 for player {playersCount + 1}");
                                continue;
                            }
                            else
                                currentPosition[playersCount] = currentPosition[playersCount] + RollingDieNumber;
                            break;
                        case SNAKE:
                            if (currentPosition[playersCount] >= RollingDieNumber)
                            {
                                currentPosition[playersCount] = currentPosition[playersCount] - RollingDieNumber;
                                break;
                            }
                            else
                            {
                                currentPosition[playersCount] = 0;
                                break;
                            }
                        case NO_PLAY:
                            break;
                    }
                    Console.WriteLine($"Current Position of {playersCount + 1} Player:{currentPosition[playersCount]},iteration no. {iterationNo}");
                    iterationNo++;
                    if (currentPosition[playersCount] == winningPosition)
                    {
                        Console.WriteLine($"{playersCount + 1} is winner of the game.");
                        break;
                    }
                } while (checkingThePosition == LADDER);
                if (playersCount < noOfPlayers - 1)
                    playersCount += 1;
                else
                    playersCount = 0;
            }

        }
    } //while (currentPosition[0] < winningPosition && currentPosition[1]< winningPosition);
}