﻿using System;
using System.Globalization;
using System.Linq;

namespace MultyCalculator
{
    class Start
    {
        static void Main(string[] args)
        {
            Preview();

            void Preview()
            {
                Console.WriteLine("Добро пожаловать вас в CalculateIncome :D");
                Console.WriteLine("________________________________________________");
                Console.WriteLine("Нажмите на любую клавишу, чтобы приступить к выполнению программы");

                Console.ReadKey();
                Console.Clear();

                MainMenu mainMenu = new MainMenu();
                mainMenu.TheMainMenu();
            }
        }
    }
}
