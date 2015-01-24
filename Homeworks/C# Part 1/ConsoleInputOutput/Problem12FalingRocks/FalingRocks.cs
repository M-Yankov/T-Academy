/*Problem 12.** Falling Rocks

    Implement the "Falling Rocks" game in the text console.
        A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
        A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
        Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O).
    Ensure a constant game speed by Thread.Sleep(150).
    Implement collision detection and scoring system.
 * My rules:
 * Avoid falling rules.
 * Can gets a bonuses with dollar sigh in green for faster level up.
 * 10 levels
 * Get 250 points to level up.
 * Don't make 100 damage or Die.
 * Good luck
 * --Based on JustCars by Niki
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
        Console.SetCursorPosition(x, y);
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
    static void ShowLevel()
    {
        PrintInfo(23, 20, "Level: ", ConsoleColor.White);
    }
    static void Main()                                      //-------------------------------------Static Void Method --------------------------\\
    {
        int score = 0;                                      //player starts with 0 score
        int leveL = 1;                                      //First level
        ConsoleColor damageColor = ConsoleColor.White;      
        Console.CursorVisible = false;                      // Disable  console crusor - it's better
        Line();                                             // That's is some method drawing a vertical line in x= 52 - 
        int playfield = 50;                                 // Playground width
        int damage = 0;                                     // Starts with 0 damage if it's =>100 - Game over
        Console.BufferHeight = Console.WindowHeight = 40;   // Disable scrollbar at right
        Console.BufferWidth = Console.WindowWidth = 100;    // same
        Rocks player = new Rocks();                         // creating player with atributes
        player.x = 25 - (3 / 2);                            // x position 
        player.y = Console.WindowHeight - 1;                // y position (bottom)
        player.text = "<O>";                                // My dwarf is <0>
        player.color = ConsoleColor.DarkGreen;              // PLayer Color
        Random generator = new Random();                    // Variable generator witch will contains random numbers
        List<Rocks> fallingRocks = new List<Rocks>();       // Collection for "###" this objects
        List<Rocks> symbols = new List<Rocks>();            // Other symbols. with two collection can make a more object to display at one line
        Rocks crusor = new Rocks();                         // This will use for Menu cursor
        crusor.x = 3;                                       // Position of cursor for x
        crusor.y = 10;                                      // Position of cursor for y
        crusor.color = ConsoleColor.Green;                  // Color
        crusor.text = ">";                                  // Vision
        Rocks bad = new Rocks();                            // new object that will hide old position of cursor, 
        bad.x = 3;
        bad.y = 13;
        bad.text = " ";                                     // That's the empty space that will hide
        bad.color = ConsoleColor.DarkBlue;                  // sensless - no matter for color
        int temp = 0; 
        
        while (true)                                        // Here starts Menu 
        {
            
            if (Console.KeyAvailable)                               //That is some condition if we pressing a key
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.UpArrow)         // exchanging positions of cursor and 'bad' variable
                {
                    temp = crusor.y;
                    crusor.y = bad.y;
                    bad.y = temp;

                }
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    temp = crusor.y;
                    crusor.y = bad.y;
                    bad.y = temp; //-============================================ yes beeeee
                }
                if (pressedKey.Key == ConsoleKey.Enter && crusor.y == 10) // Must press enter on 'Start game ' to exit from this menu and start play
                {
                    break;
                }
                else if (pressedKey.Key == ConsoleKey.Enter && crusor.y == 13) // Or exit from game
                {
                    Console.WriteLine();
                    return;
                }
            }

            PrintPosition(crusor.x, crusor.y, crusor.text, crusor.color);  // Printing cursor
            PrintPosition(bad.x, bad.y, bad.text, bad.color);
            PrintPosition(5, 10, "Start game", ConsoleColor.White);
            PrintPosition(5, 13, "Exit", ConsoleColor.White);


        }

        while (true)
        {
            
            bool hitbonus = false;                              // Bool for if player takes bonus (dollar symbol) 
            bool hitted = false;                                // If player hitted by other object
            bool gameOver = false;                              // If damage is above or equal to 100
            int chance = generator.Next(0, 110);                // Generating a random number from 0 to 100
            int lenght = generator.Next(1,11);                  // Another random from 1 to 11 uses for level 5 for objects lengt
            if (chance < 30)                                    // Creating objects depends on chance value
            {
                Rocks rock = new Rocks();
                rock.color = ConsoleColor.DarkMagenta;
                rock.x = generator.Next(0, playfield);
                rock.y = 0;
                rock.text = "###";
                fallingRocks.Add(rock);                         // Adding new object to collection
            }
            if (chance > 10 && chance < 20)                     // Symbol Objects
            {
                Rocks symbol = new Rocks();
                symbol.color = ConsoleColor.Yellow;
                symbol.x = generator.Next(0, playfield);
                symbol.y = 0;
                symbol.text = "^";
                if (leveL >= 5)                                 // After level 5 it's get harder
                {
                    symbol.text = new string('^', lenght);
                }
                symbols.Add(symbol);
            }
            else if (chance > 20 && chance < 30)                // If some object is created other statements will not checked (beacuse of "if else...")
            {
                Rocks symbol = new Rocks();
                symbol.color = ConsoleColor.Blue;
                symbol.x = generator.Next(0, playfield);
                symbol.y = 0;
                symbol.text = "@";
                if (leveL >= 5)
                {
                    symbol.text = new string('@', lenght);
                }
                symbols.Add(symbol);
            }
            else if (chance > 30 && chance < 40)
            {
                Rocks symbol = new Rocks();
                symbol.color = ConsoleColor.Cyan;
                symbol.x = generator.Next(0, playfield);
                symbol.y = 0;
                symbol.text = "*";
                if (leveL >= 5)
                {
                    symbol.text = new string('*', lenght);
                }
                symbols.Add(symbol);
            }
            else if (chance > 40 && chance < 50)
            {
                Rocks symbol = new Rocks();
                symbol.color = ConsoleColor.Red;
                symbol.x = generator.Next(0, playfield);
                symbol.y = 0;
                symbol.text = "&";
                if (leveL >= 5)
                {
                    symbol.text = new string('&', lenght);
                }
                symbols.Add(symbol);
            }
            else if (chance > 50 && chance < 60)
            {
                Rocks symbol = new Rocks();
                symbol.color = ConsoleColor.Magenta;
                symbol.x = generator.Next(0, playfield);
                symbol.y = 0;
                symbol.text = "+";
                if (leveL >= 5)
                {
                    symbol.text = new string('+', lenght);
                }
                symbols.Add(symbol);
            }
            else if (chance > 60 && chance < 70)
            {
                Rocks symbol = new Rocks();
                symbol.color = ConsoleColor.DarkRed;
                symbol.x = generator.Next(0, playfield);
                symbol.y = 0;
                symbol.text = "%";
                if (leveL >= 5)
                {
                    symbol.text = new string('%', lenght);
                }
                symbols.Add(symbol);
            }
            else if (chance > 70 && chance < 80)
            {
                Rocks symbol = new Rocks();
                symbol.color = ConsoleColor.Gray;
                symbol.x = generator.Next(0, playfield);
                symbol.y = 0;
                symbol.text = ",";
                if (leveL >= 5)
                {
                    symbol.text = new string(',', lenght);
                }
                symbols.Add(symbol);
            }
            else if (chance > 80 && chance < 90)
            {
                Rocks symbol = new Rocks();
                symbol.color = ConsoleColor.DarkYellow;
                symbol.x = generator.Next(0, playfield);
                symbol.y = 0;
                symbol.text = ".";
                if (leveL >= 5)
                {
                    symbol.text = new string('.', lenght);
                }
                symbols.Add(symbol);
            }
            else if (chance > 90 && chance < 100)
            {
                Rocks symbol = new Rocks();
                symbol.color = ConsoleColor.Green;
                symbol.x = generator.Next(0, playfield);
                symbol.y = 0;
                symbol.text = "$";
                symbols.Add(symbol);
            }
            if (Console.KeyAvailable)                                   // Was player pressed a key?
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (player.x - 1 >= 0)                              // Left movement
                    {
                        player.x = player.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (player.x + 1 < playfield)                       // Right movement
                    {
                        player.x = player.x + 1;
                    }
                }
            }
            
            
            List<Rocks> newList = new List<Rocks>();                    // Using new collection to transfer old properties to new object
            for (int i = 0; i < fallingRocks.Count; i++)                // Moving rock down
            {
                Rocks oldRcok = fallingRocks[i];
                Rocks newRock = new Rocks();
                newRock.x = oldRcok.x;
                newRock.y = oldRcok.y + 1;
                newRock.text = oldRcok.text;
                newRock.color = oldRcok.color;

                if (newRock.y == player.y && (Math.Abs(player.x - newRock.x) < newRock.text.Length)) // Checks for rock on player - hit 
                {
                    hitted = true;
                    if (player.x - newRock.x == newRock.text.Length -3 )
                    {
                        damage += 30;                                   // Adding 30 damage. Depends on how many part form object are hited.
                        if (damage >= 100)                              // If damage reachs 100 the game will over.
                        {
                            gameOver = true;
                        }
                    }
                    else if (Math.Abs(player.x - newRock.x) < newRock.text.Length - 1) // Gets 20 damage
                    {
                        damage += 20;
                        if (damage >= 100) 
                        {
                            gameOver = true;
                        }
                    }
                    else                                                // 10 Damage
                    {
                        damage += 10;
                        if (damage >= 100) 
                        {
                            gameOver = true;                            // Bewol is my old logic that was not working well. But the new is better
                        }
                    }
                } 
                                                                            /*if (newRock.y == player.y && ((newRock.x == player.x + 2 || newRock.x == player.x - 2) && newRock.text.Length == 3))//by10
                                                                            {
                                                                                hitted = true;
                                                                                damage += 10;
                                                                                if (damage >= 100) //if damage reachs 100 the game will over
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
                                                                            }*/
                if (newRock.y < Console.WindowHeight)                        // Adding to newlist. Only if a object is on play field
                {
                    newList.Add(newRock);
                }


            }//End loop "for"

            List<Rocks> nListSymbols = new List<Rocks>();                   // Some method like before
            if (leveL >= 2)                                                 // Only on level 2
            {

                for (int i = 0; i < symbols.Count; i++)
                {
                    Rocks oldSymbol = symbols[i];
                    Rocks newSymbol = new Rocks();
                    newSymbol.x = oldSymbol.x;
                    newSymbol.y = oldSymbol.y + 1;
                    newSymbol.text = oldSymbol.text;
                    newSymbol.color = oldSymbol.color;
                    if(newSymbol.x + newSymbol.text.Length-1 >= 52)         // This checks if object text gets out from playfield
                        {
                            
                            newSymbol.x -= (newSymbol.x + newSymbol.text.Length - 1) - 51; // And then fix it
                        }
                    //da maxna out of playfield objects
                    if (newSymbol.text != "$" && newSymbol.y == player.y && (player.x == newSymbol.x + newSymbol.text.Length - 1 || newSymbol.x == player.x + 2)) // Check if rock is over player with different symbol than dollar ($)
                    {
                        hitted = true;
                        damage += 10;
                        if (damage >= 100) //if damage reachs 100 the game will over
                        {
                            gameOver = true;
                        }
                    }
                    else if (newSymbol.text != "$" && newSymbol.y == player.y && (player.x == newSymbol.x + newSymbol.text.Length - 2 || newSymbol.x == player.x + 1)) // If symbol with Lenght = 1 falls on the midlle of player
                    {
                        hitted = true;
                        if (newSymbol.text.Length == 1)
                        {
                            damage += 10;
                            if (damage >= 100) 
                            {
                                gameOver = true;
                            }
                        }
                        else
                        {
                            damage += 20;
                            if (damage >= 100) 
                            {
                                gameOver = true;
                            }
                        }
                    }
                    else if (newSymbol.text != "$" && newSymbol.y == player.y && ((player.x >= newSymbol.x && player.x <= newSymbol.x + newSymbol.text.Length - 3)))
                    {
                        hitted = true;
                        damage += 30;
                        if (damage >= 100) //if damage reachs 100 the game will over
                        {
                            gameOver = true;
                        }
                    }
                    /*} //some old logics Skip it
                    if (newSymbol.text != "$" && newSymbol.y == player.y && (newSymbol.x == player.x || newSymbol.x == player.x + 1 || newSymbol.x == player.x + 2))//crash
                    {
                        hitted = true;
                        if (leveL >= 5)
                        {
                            
                        }
                        else
                        {
                            damage += 10;
                            if (damage >= 100) //if damage reachs 100 the game will over
                            {
                                gameOver = true;
                            }
                        }
                    }
                    */
                    if (newSymbol.text == "$" && newSymbol.y == player.y && (newSymbol.x == player.x || newSymbol.x == player.x + 1 || newSymbol.x == player.x + 2)) // Getting bonus
                    {
                        hitbonus = true;
                        score += 50;
                    }
                    if (newSymbol.y < Console.WindowHeight)                 //Adding symbols
                    {
                        nListSymbols.Add(newSymbol);
                    }
                }
            }
            

            fallingRocks = newList;         // Adding changed objects  to old collection 

            symbols = nListSymbols;         // For symbols 

            
            Console.Clear();                // Clears whole Console
            Line();

            foreach (Rocks sex in symbols)                          // Printing rocks from first collection
            {
                PrintPosition(sex.x, sex.y, sex.text, sex.color);   
                if (sex.y == player.y)//Console.WindowHeigh         // And get score +1 for each passed rock
                {
                    score += 1;
                }
            }
            foreach (Rocks rack in fallingRocks)                    // This show faling rocks from second collection 
            { 
                PrintPosition(rack.x, rack.y, rack.text, rack.color);
                if (rack.y == player.y)
                {
                    score += 1;
                }
            }

            if (hitted)                                             // Crash
            {
                PrintPosition(player.x, player.y, "XXX", ConsoleColor.Red); // Player changes text with red color and three XXX
                Console.Beep(130, 260);
                fallingRocks.Clear();                               // After hit play field is cleared Clears objects in collection 
                symbols.Clear();                                    // same
            }
            else if (hitbonus)                                      // get bonus
            {
                PrintPosition(player.x, player.y, "+++", ConsoleColor.Green); // PLayer changes  with green pluses "+++"

            }
            else
            {
                PrintPosition(player.x, player.y, player.text, player.color); // Just prints player
            }
            
            if (damage >= 20 && damage <= 40)                               // Depends how bad is contition of player damage shows in right in different colors
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
            PrintInfo(62, 4, "Level: " + leveL, ConsoleColor.White);        // Shows info
            PrintInfo(62, 5, "Score: " + score, ConsoleColor.White);        
            PrintInfo(62, 6, "Damage: " + damage, damageColor);
            if (fallingRocks.Count < 5)                                     //-----shows witch level starts //and when player dies it shows up again
            {
                PrintPosition(23, 20, "Level: " + leveL, ConsoleColor.White);
            }

            if (score >= 250)                                               // Level up above 250 score
            {
                leveL++;
                score = 0;
                fallingRocks.Clear();
                symbols.Clear();
            }
            if (leveL == 11)                                                // You Win here :)
            {
                Console.Clear();
                Line();
                PrintPosition(player.x, player.y, player.text, player.color);
                PrintInfo(62, 4, "Level: " + leveL, ConsoleColor.White);
                PrintInfo(62, 5, "Score: " + score, ConsoleColor.White);
                PrintInfo(62, 6, "Damage: " + damage, damageColor);
                
                PrintInfo(62, 7, "-=YOU WIN=-", ConsoleColor.Green);
                PrintInfo(23, 20, "-=YOU WIN=-", ConsoleColor.Green);
                Console.ReadLine();
                PrintInfo(63, 8, "One Beer!", ConsoleColor.Yellow);
                PrintInfo(24, 21, "One Beer!", ConsoleColor.Yellow);
                PrintInfo(62, 9, "Press any key to exit.", ConsoleColor.White);
                Console.WriteLine();
                Console.ReadLine();
                return;
            }
            if (gameOver)                                                   // Game over and exitiong from game :(
            {
                PrintInfo(62, 6, "Damage: " + damage, ConsoleColor.Red);
                PrintInfo(62, 7, "***GAME OVER***", ConsoleColor.Red);
                PrintInfo(62, 8, "Press any key to exit.", ConsoleColor.White);
                Console.ReadLine();
                Console.Write("                                  ");
                return;
            }
            
            // Console.Beep(13000, 150);Program moves faster without sound
            Thread.Sleep(150);
        }
    }
}