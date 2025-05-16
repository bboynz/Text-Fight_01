using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace Text_Fight.PlayerActions
{

    class QuickTime
    {


        //This is the method for a quick time where you input a word to the method and it splits it into chars and records total time
        public static bool WordQuickTime(int timeLimit, string inputedWord, string hit = "", string miss = "")
        {
            bool achieved;

            List<char> word = new List<char>(inputedWord);//makes the string a collection of chars
            int wordLength = word.Count;    //may be unneeded but cleans up code - This means the loop will runn through all chars in the string

            var timer = new Stopwatch();
            timer.Start();

            Console.WriteLine("!QUICK! - Input the word: " + inputedWord); // warns user
            Thread.Sleep(10 * 100); //10 seconds
            DramaticWrite(3, "3", "2", "1", "GO!");

            //Loops through the string causing a quick time event for every character
            Console.WriteLine(wordLength);
            for (int i = 0; i < wordLength; i++)
            {


                char key = word[i];     //Letter from Word



                if (QuickTimeCharEvent(key) == true) //this causes a quick time event 
                {
                    int curPosition = Console.CursorTop - 1; //this sets how many lines back the line goes
                    for (int k = 0; k < 5; k++)//this obilirates the line by looping through the columns setting all the stings to empty
                    {
                        Console.SetCursorPosition(0, curPosition);
                        ClearLine(k);
                    }
                }
                else
                {
                    i--;
                    DramaticWrite(3, miss); //writes custom fail message

                }


            }

            timer.Stop();
            TimeSpan totalTimeTaken = timer.Elapsed;

            int timeTaken = totalTimeTaken.Seconds;

            if (timeTaken > timeLimit)
            {
                Console.WriteLine("!!!TOO LONG FAILED!!!\n\nEnter to continue:"); //if you take too long
                Console.ReadLine();
                achieved = false;
            }
            else
            {
                string[] words = inputedWord.Split(' '); //Splits the sentence into words
                DramaticWrite(4, words); // This dramaticly says all the words in the inputed sentence

                Console.WriteLine("!!!success!!!\n\nEnter to continue:");
                Console.ReadLine();
                achieved = true;
            }
            return achieved;
        }

        public static void DramaticWrite(int secs, params string[] words)
        {
            for (int i = 0; i < words.Count(); i++) //prints all words from first to last
            {

                string text = words[i];
                int time = secs * 100;

                int lines = 0;
                lines += AddLine(text); //If i wanted to do multiple lines I wouldn't delete them with clear line till after writing all lines

                Thread.Sleep(time);

                int curPosition = Console.CursorTop - 1; //this sets how many lines back the line goes
                for (int k = 0; k < 5; k++)//this obilirates the line by looping through the columns setting all the stings to empty
                {
                    Console.SetCursorPosition(0, curPosition);
                    ClearLine(k);
                }
                Thread.Sleep(50);

            }

        }

        //Requests the user to input key in arguement
        public static bool QuickTimeCharEvent(char key)
        {
            bool KeyPressed; //Returns if the correct key was pressed
            char input; //This is the variable keeping track of 


            Console.WriteLine(key);
            Thread.Sleep(100);

            try //Incase there is any bad input or other issues
            {
                input = Console.ReadKey(true).KeyChar;
                Console.WriteLine(input);
                Thread.Sleep(100);

                input = char.ToLower(input); //so it doesn't matter if it is caps or not only the correct character.
                key = char.ToLower(key);

                if (input == key)
                {
                    KeyPressed = true; // key was pressed
                }
                else
                {
                    KeyPressed = false;// didn't press correct key
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                KeyPressed = false; // says that user falled if there is error
            }

            return KeyPressed;

        }

        //outputs a random interger between 0 the the arguement
        public static int RandomInt(int max)
        {
            Random random = new Random();
            int output = random.Next(0, max);

            return output;
        }

        //This is used to write something to console and add to a variable counting amount of lines 
        //       (This can be used in couple with ClearLine method to delete specific lines)
        public static int AddLine(string text)
        {
            Console.WriteLine(text);
            return 1;
        }

        //Clears specific line
        public static void ClearLine(int back) //NEED TO MAKE BETTER METHOD WHERE YOU CAN INPUT COLUMNS AND ROWS AND IT DOES FOR YOU (using loops)
        {


            int currentLineCursor = Console.CursorTop;//last line
            Console.SetCursorPosition(0, Console.CursorTop - back);//the line where we want the cursor to end up
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);//then deletes line with clear line

         
            
        }




      
    }
}



