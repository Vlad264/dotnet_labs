using System;
using System.Collections.Generic;

namespace GuessGame
{
    class Game
    {
        private int _neededNumber;
        private string _name;
        private int _iterations = 1;
        private bool _finishFlag = false;
        private DateTime _startTime;
        private Random _random = new Random();
        private List<string> _history = new List<string>();

        private const string _LESS = "Less";
        private const string _GREATER = "Greater";
        private string[] _messages = {
            "Try again,",
            "Just try again,",
            "You can't surrended,",
            "Do it,",
            "Just do it,"
        };

        public Game() 
        {
            _neededNumber = _random.Next(51);
        }

        public void StartGame()
        {
            AskName();
            Play();
            PrintResult();
        }

        private void AskName()
        {
            Console.WriteLine("Enter your name:");
            _name = Console.ReadLine();
            Console.WriteLine();
        }

        private void Play()
        {
            _startTime = DateTime.Now;
            int number = -1;
            string str;

            Console.WriteLine("Try to guess number between 0 and 50:");
            while (number != _neededNumber)
            {
                str = Console.ReadLine();
                if (str == "q") 
                {
                    break;
                }
                try
                {
                    number = int.Parse(str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect input!!!");
                    continue;
                }

                if (number < 0 || number > 50) 
                {
                    Console.WriteLine("Number must be in range [0, 50]");
                    continue;
                }

                if (number == _neededNumber) 
                {
                    break;
                }

                if (number > _neededNumber) 
                {
                    Console.WriteLine(_LESS);
                    _history.Add(String.Format("{0, 3}: Less ({1})", _iterations, number));
                }
                else
                {
                    Console.WriteLine(_GREATER);
                    _history.Add(String.Format("{0, 3}: Greater ({1})", _iterations, number));
                }

                if (_iterations % 4 == 0)
                {
                    Console.WriteLine(_messages[_random.Next(_messages.Length)] + " " + _name);
                }
                _iterations++;
            }
            if (number == _neededNumber) 
            {
                _finishFlag = true;
            }
            Console.WriteLine();
        }

        private void PrintResult()
        {
            Console.WriteLine("You're " + (_finishFlag ? "win" : "lose"));
            Console.WriteLine("The number is {0}", _neededNumber);
            Console.WriteLine("Play time: {0:hh\\:mm\\:ss}", DateTime.Now - _startTime);
            Console.WriteLine("You tried to guess {0} times", _iterations - 1);
            if (_history.Count != 0)
            {
                Console.WriteLine("History:");
                foreach (var str in _history) 
                {
                    Console.WriteLine(str);
                }
            }
            Console.WriteLine();
        }
    }
}
