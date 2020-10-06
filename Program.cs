using System;

namespace SnakeAndLadderProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Start_Position = 0;
            const int NO_Play = 1;
            const int Ladder = 2;
            const int Snake = 3;
            const int No_Of_Players = 2;
            int winningPosition = 100;
            int[] PlayersCurrentPositions = new int[No_Of_Players];
            int noOfTurns = 0;
            for (int i = 0; i < No_Of_Players; i++)
                PlayersCurrentPositions[i] = Start_Position;  
            int currentIndex = 0;

            while (PlayersCurrentPositions[currentIndex] < winningPosition)
            {
                Random randObj = new Random();
                bool flag = true;
                while (flag)
                {
                    int dieNumber = randObj.Next(1, 7);
                    int option = randObj.Next(1, 4);
                    switch (option)
                    {
                        case NO_Play:
                            flag = false;
                            break;
                        case Ladder:
                            if (PlayersCurrentPositions[currentIndex] + dieNumber <= winningPosition)
                                PlayersCurrentPositions[currentIndex] += dieNumber;
                            if (PlayersCurrentPositions[currentIndex] == winningPosition)
                                flag = false;
                            break;
                        case Snake:
                            flag = false;
                            PlayersCurrentPositions[currentIndex] -= dieNumber;
                            if (PlayersCurrentPositions[currentIndex] < Start_Position)
                                PlayersCurrentPositions[currentIndex] = Start_Position;
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("Current Player is "+(currentIndex+1)+" Current Position is: "+PlayersCurrentPositions[currentIndex]);
                }
                noOfTurns++;
                if (currentIndex < No_Of_Players - 1)
                    currentIndex += 1;
                else currentIndex = 0;
            }
            for(int i = 0; i < No_Of_Players; i++)
            {
                Console.WriteLine("Player "+(i+1)+ ", Current Position "+ PlayersCurrentPositions[i]);
            }
            Console.WriteLine("Total Turns used {0}", noOfTurns);
            Console.WriteLine("Winner is Player {0}", currentIndex+1);
        }
    }
}
