﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MobileStore
{
    class Program
    {
        public static void Main(string[] args)
        {
            Firstpg();

        }
        public static void Firstpg()
        {
            Console.WriteLine("\n<-------Welcome to our Mobile Store------>\n");
            Console.WriteLine("Click 1: Sign up\nClick 2: Login\nClick 3: Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Home.Signup();
                    break;

                case 2:
                    Home.Login();
                    break;

                default:
                    Console.WriteLine("Please click either 1 or 2");
                    break;
            }
        }
    }
}
