using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Ping_Pong
{
    class Program
    {
        static int fieldSizeX = 50;
        static int fieldSizeY = 20;
        static int ballPositionX = fieldSizeX / 2;
        static int ballPositionY = fieldSizeY / 2;
        static bool UpDirection = true;
        static bool LeftDirection = false;
        static int playerPositionX = fieldSizeX / 2;
        static int playerPositionY = fieldSizeY-1;
        static bool youLose = false;
        static int speedPlayer = 400;
        static int score = 0;



        static void RemoveScroll()
        {
            
            Console.SetWindowSize(60, 25);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
        }

        static void DrowField()
        {
            Console.WriteLine(new String('═', fieldSizeX));
            for (int i = 0; i < fieldSizeY - 1; i++)
            {
                Console.Write('║' + new String(' ', fieldSizeX - 2) + '║');
                Console.WriteLine();
            }

            Console.WriteLine(new String('═', fieldSizeX));
            Console.WriteLine("SCORE:  " + score);
        }

        static void DrawBall()
        {
            Console.SetCursorPosition(ballPositionX, ballPositionY);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write('●');
        }

        static void RemoveBall()
        {
            Console.SetCursorPosition(ballPositionX, ballPositionY);

            Console.Write(' ');
        }

        static void MoveBall()
        {
            if (ballPositionY == 1)
            {
                UpDirection = false;
                Console.Beep(500, 100);
            }
            if (ballPositionY == fieldSizeY - 1)
            {
                Console.SetCursorPosition(20, fieldSizeY + 2);
                Console.Write("Game Over");
                youLose = true;
                Console.Beep(1320, 500);
                Console.Beep(990, 250);
                Console.Beep(1056, 250);
                Console.Beep(1188, 250);
                Console.Beep(1320, 125);
                Console.Beep(1188, 125);
                Console.Beep(1056, 250);
                Console.Beep(990, 250);
                Console.Beep(880, 500);
                Console.Beep(880, 250);
                Console.Beep(1056, 250);
                Console.Beep(1320, 500);
                Console.Beep(1188, 250);
                Console.Beep(1056, 250);
                Console.Beep(990, 750);
                Console.Beep(1056, 250);
                Console.Beep(1188, 500);
                Console.Beep(1320, 500);
                Console.Beep(1056, 500);
                Console.Beep(880, 500);
                Console.Beep(880, 500);
            }
            if (ballPositionX == 1)
            {
                LeftDirection = false;
                Console.Beep(1500, 100);
            }
            if (ballPositionX == fieldSizeX - 2)
            {
                LeftDirection = true;
                Console.Beep(1000, 100);
            }
            if(ballPositionY==playerPositionY-1)
            {
                if (ballPositionX == playerPositionX ||
                    ballPositionX == playerPositionX + 1 ||
                    ballPositionX == playerPositionX - 1 ||
                    ballPositionX == playerPositionX + 2 ||
                    ballPositionX == playerPositionX - 2)
                {
                    UpDirection = true;
                    speedPlayer -= 30;
                    Console.Beep(1500, 100);
                    Console.Beep(1700, 100);
                    Console.Beep(1900, 100);
                    Console.Beep(2100, 100);
                 
                    Console.SetCursorPosition(15, fieldSizeY + 1);
                    Console.Write(++score);
                }
            }

            if (UpDirection)
                ballPositionY--;
            else
                ballPositionY++;
            if (LeftDirection)
                ballPositionX--;
            else
                ballPositionX++;
            
        }

        
        static void MovePlayer()
        {
            if(Console.KeyAvailable)
            {
                Console.SetCursorPosition(playerPositionX, playerPositionY);
                Console.Write(' ');
                Console.SetCursorPosition(playerPositionX + 1, playerPositionY);
                Console.Write(' ');
                Console.SetCursorPosition(playerPositionX - 1, playerPositionY);
                Console.Write(' ');

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.RightArrow:
                        {
                            if(playerPositionX<fieldSizeX-3)
                            playerPositionX++;
                            
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            if (playerPositionX > 2)
                                playerPositionX--;
                          
                            break;
                        }
                }

                Console.SetCursorPosition(playerPositionX, playerPositionY);
                Console.Write('≡');
                Console.SetCursorPosition(playerPositionX + 1, playerPositionY);
                Console.Write('≡');
                Console.SetCursorPosition(playerPositionX - 1, playerPositionY);
                Console.Write('≡');
            }
        }
        

        static void Main(string[] args)
        {
            RemoveScroll();
            DrowField();
            DrawBall();
            while(true)
            {

                MovePlayer();
                DrawBall();
                Thread.Sleep(speedPlayer/30);

                for(int i =0; i<30;i++)
                {
                    MovePlayer();
                    Thread.Sleep(speedPlayer / 30); 
                }                                   

                RemoveBall();
                MoveBall();


                if (youLose)
                    break;
            }

            
            Console.ReadKey(false);
            Console.ReadKey(false);
        }

        
    }
}
