﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Game
    {
        public List<string> gestures;
        public Player pOne;
        public Player pTwo;

        //constructor

        public Game()
        {
            gestures = new List<string>();
            gestures.Add("Rock");
            gestures.Add("Paper");
            gestures.Add("Scissors");
            gestures.Add("Lizard");
            gestures.Add("Spock");
        }

        public void Welcome()
        {
            Console.WriteLine("Welcome to RPSLS!");
            Console.WriteLine("Also know as rock paper scissors lizard spock!");
            Console.WriteLine("In This game you will choose which gesture you would like to use and your oponent will do the same.");
            Console.WriteLine("Whoever has the winning gesture will get a point! First to three points wins!");
            Console.WriteLine("The relationships are as follows:");
            Console.WriteLine("Rock crushes Scissors");
            Console.WriteLine("Scissors cut paper");
            Console.WriteLine("Paper covers Rock");
            Console.WriteLine("Rock crushes Lizard");
            Console.WriteLine("Lizard poisons Spock");
            Console.WriteLine("Spock smashes Scissors");
            Console.WriteLine("Scissors decapitate Lizard");
            Console.WriteLine("Lizard eats Paper");
            Console.WriteLine("Paper disproves Spock");
            Console.WriteLine("Spock vaporizes Rock");
        }

        public void ChooseGameType()
        {
            bool looper = false;
            while(looper == false)
            {

            
                Console.WriteLine("Please enter 1 if this is a multiplayer game or 2 if this is a single player.");
                string typeChoice = Console.ReadLine();
                if(typeChoice == "1")
                {
                    pOne = new Human(null);
                    pTwo = new Human(null);
                    looper = true;
                }
                else if(typeChoice == "2")
                {
                    pOne = new Human(null);
                    pTwo = new AI(null);
                    looper = true;
                }
                else
                {
                    Console.WriteLine("Invalid response please try again.");
                    looper = false;
                }
            }
        }

        public void GiveNames()
        {
            Console.WriteLine("Please give a name to player one.");
            pOne.name = Console.ReadLine();
            Console.WriteLine("Please give a name to playter two.");
            pTwo.name = Console.ReadLine();
        }
        
        public void DisplayScore()
        {
            Console.WriteLine($"{pOne.name} has a score of {pOne.score}!");
            Console.WriteLine($"{pTwo.name} has a score of {pTwo.score}!");
        }

        public void DisplayWinner()
        {
            if(pOne.score >= 3)
            {
                Console.WriteLine($"{pOne.name} wins!");
            }
            else
            {
                Console.WriteLine($"{pTwo.name} wins!");
            }
        }

        // compair the chosen gestures 
        //should I make a method for each choice and in every choice have the chosen gestures it can beat 
        //or should I make the biggest if else then cut it up

        public void Compair(Player pOne, Player pTwo)
        {
            string choiceOne = pOne.chosenValue;
            string choiceTwo = pTwo.chosenValue;
            if(choiceOne == "Rock")
            {
                if (choiceTwo == "Paper" || choiceTwo == "Spock")
                {
                    pTwo.score++;
                }
                else
                {
                    pOne.score++;
                }
            }
            else if(choiceOne == "Paper")
            {
                if(choiceTwo == "Scissors" || choiceTwo == "Lizard")
                {
                    pTwo.score++;
                }
                else
                {
                    pOne.score++;
                }
            }
            else if(choiceOne == "Scissors")
            {
                if(choiceTwo == "Rock" || choiceTwo == "Spock")
                {
                    pTwo.score++;
                }
                else
                {
                    pOne.score++;
                }
            }
            else if(choiceOne == "Lizard")
            {
                if(choiceTwo == "Scissors" || choiceTwo == "Rock")
                {
                    pTwo.score++;
                }
                else
                {
                    pOne.score++;
                }
            }
            else
            {
                if(choiceTwo == "Paper" || choiceTwo == "Lizard")
                {
                    pTwo.score++;
                }
                else
                {
                    pOne.score++;
                }
            }
        }

        public void FullGame()
        {
            Welcome();
            ChooseGameType();
            GiveNames();
            while(pOne.score < 3 && pTwo.score < 3)
            {
                pOne.ChooseGesture(gestures);
                pTwo.ChooseGesture(gestures);
                Compair(pOne, pTwo);
                DisplayScore();
            }
            DisplayWinner();
        }
    }
}
