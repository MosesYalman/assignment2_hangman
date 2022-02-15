using System;
using System.Collections.Generic;
using System.Text;

namespace assignment2_hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!!!");

            int fail_count = 0;
            int right_count = 0;
            bool guess = true;
            string[] words = { "hej", "hello", "goodbye", "stop", "read", "lol" };
            List<char> right_cahracters = new List<char>();
            StringBuilder user_characters = new StringBuilder();
            //get random word
            Random rnd = new Random();
            String one_word = words[rnd.Next(5)];//returns random integers < 5

            while (fail_count < 10 && (right_count <= one_word.Length - 1) && guess)
            {



                Console.WriteLine("Length of word is: ");

                
                for (int i = 0; i < one_word.Length; i++)
                {
                    if (right_cahracters.Contains(one_word[i]))
                    {
                        Console.Write(one_word[i]);
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                    
                }
                
                
                Console.WriteLine();
                Console.WriteLine("Enter your guess: ");

                String user_inputs = Console.ReadLine();

                //user inputs is one word
                if (user_inputs.Length > 1)
                {
                    if (String.Equals(one_word, user_inputs))
                    {
                     
                        guess = false;
                    }
                    else
                    {

                        fail_count = fail_count + 1;
                        Console.WriteLine("Fail!! Guess again!");
                        Console.WriteLine("You have a " + (10 - fail_count) + " times left!");
                        
                    }

                }
                else
                {
                    user_characters.Append(user_inputs);

                     if (one_word.Contains(user_inputs) && !right_cahracters.Contains(user_inputs[0]) )
                    {
                        
                        right_count = right_count + (one_word.Split(user_inputs).Length - 1);
                        right_cahracters.Add(user_inputs[0]);
                        Console.WriteLine("right letter!");
                        Console.WriteLine("your total amount of letter guessed : " + user_characters);
                        
                    }
                    else
                    {
                        fail_count = fail_count + 1;
                        Console.WriteLine("fail letter!");
                        Console.WriteLine("You have a " + (10 - fail_count) + " times left!");
                        Console.WriteLine("your total amount of letter guessed: " + user_characters);
                    }
                }

            }

            if (!guess || right_count == one_word.Length)
            {
               
                Console.WriteLine("Congratulations! you guessed the word!!");
                Console.WriteLine(one_word);
                   
            }
             



        }

    }
}
