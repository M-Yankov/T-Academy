/*Problem 12.** Falling Rocks

    Implement the "Falling Rocks" game in the text console.
        A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
        A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
        Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O).
    Ensure a constant game speed by Thread.Sleep(150).
    Implement collision detection and scoring system.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


class FalingRocks
{
   
    struct Rocks
    {
        public int x;
        public int y;
        public string text;
        public ConsoleColor color;
    }
    static void PrintPosition(int x, int y, string c, ConsoleColor color = ConsoleColor.White)
    {
        Console.SetCursorPosition(x,y);
        Console.ForegroundColor = color;
        Console.Write(c);

    }
    static void PrintInfo(int x, int y, string str, ConsoleColor color = ConsoleColor.White)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        
        Console.Write(str);

    }
    static void Line()// That method adds a line border around playfield
    {
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            PrintPosition(52, i, "|", ConsoleColor.White);
        }
    }
    
    static void Main()
    {
        int score = 0;
        int leveL = 1;
        ConsoleColor damageColor = ConsoleColor.White;
        Console.CursorVisible = false;
        Line();
        int playfield = 50;
        int damage = 0;
        Console.BufferHeight = Console.WindowHeight =40;
        Console.BufferWidth = Console.WindowWidth = 100;
        Rocks player = new Rocks();
        player.x = 25 - (3 / 2);
        player.y = Console.WindowHeight - 1;
        player.text = "<O>";
        player.color = ConsoleColor.DarkGreen;
        Random generator = new Random();
        List<Rocks> fallingRocks = new List<Rocks>();

        while (true)
        {
            bool hitted = false;
            bool gameOver = false;
            int chance = generator.Next(0,100);
            if (chance > 20)
            {
            }
            else
            {
                Rocks rock = new Rocks();
                rock.color = ConsoleColor.DarkMagenta;
                rock.x = generator.Next(0, playfield);
                rock.y = 0;
                rock.text = "###";
                fallingRocks.Add(rock);
            }

            if (Console.KeyAvailable)//Was player pressed a key?
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (player.x - 1 >= 0) //left movement
                    {
                        player.x = player.x - 1;
                        
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (player.x + 1 < playfield) // right movement
                    {
                        player.x = player.x + 1;
                        

                    }
                }
            }
            // move players (key pressed)
            // Move rocks
            List<Rocks> newList = new List<Rocks>();
            for (int i = 0; i < fallingRocks.Count; i++)//Moving rock down
            {
                Rocks oldRcok = fallingRocks[i];
                Rocks newRock = new Rocks();
                newRock.x = oldRcok.x;
                newRock.y = oldRcok.y + 1;
                newRock.text = oldRcok.text;
                newRock.color = oldRcok.color;
                if (newRock.y == player.y && ((newRock.x == player.x + 2 || newRock.x == player.x -2) && newRock.text.Length == 3))//by10
                {
                    hitted = true;
                    damage += 10;
                    if(damage >= 100) //if damage reachs 100 the game will over
                    {
                        gameOver = true;
                    }
                }
                if (newRock.y == player.y && ((newRock.x == player.x + 1 || newRock.x == player.x - 1) && newRock.text.Length == 3))//by 20
                {
                    hitted = true;
                    damage += 20;
                    if (damage >= 100) //if damage reachs 100 the game will over
                    {
                        
                        gameOver = true;
                    }
                }
                if (newRock.y == player.y && newRock.x == player.x && newRock.text.Length == 3)//by 30
                {
                    hitted = true;
                    damage += 30;
                    if (damage >= 100) //if damage reachs 100 the game will over
                    {
                        gameOver = true;
                    }
                }
                
                if (newRock.y < Console.WindowHeight)
                {
                    newList.Add(newRock);
                }
                
                
            }//End loop "for"
            fallingRocks = newList;
            
            
            // Crashing rocks in player
            // Clear console.
            Console.Clear();
            Line();
            // Redraw Playfield
            foreach (Rocks rack in fallingRocks)//This show faling rocks
            {
                PrintPosition(rack.x, rack.y, rack.text, rack.color);
                if (rack.y == player.y)
                {
                    score += 1;
                }
            }
            if (hitted)
            {
                
                PrintPosition(player.x, player.y, "XXX" , ConsoleColor.Red);
                Console.Beep(130, 260);
                fallingRocks.Clear();
            }
            else
            {
                PrintPosition(player.x, player.y, player.text, player.color);
            }
            
            // Draw info
            if (damage >= 20 && damage <= 40)
            {
                damageColor = ConsoleColor.Green;
            }
            if (damage > 40 && damage <= 60)
            {
                damageColor = ConsoleColor.Yellow;
            }
            if (damage > 60)
            {
                damageColor = ConsoleColor.DarkYellow;
            }
            PrintInfo(62, 5, "Score: " + score, ConsoleColor.White);
            PrintInfo(62, 6, "Damage: " + damage, damageColor);
            
            if (gameOver)
            {
                PrintInfo(62, 6, "Damage: " + damage, ConsoleColor.Red);
                PrintInfo(62, 7, "***GAME OVER***", ConsoleColor.Red);
                PrintInfo(62, 8, "Press any key to exit.", ConsoleColor.White);
                Console.ReadLine();
                return;
            }
            // Slow down program
            // Console.Beep(13000, 150);Program moves faster without sound
            Thread.Sleep(150);
        }
    }
}

