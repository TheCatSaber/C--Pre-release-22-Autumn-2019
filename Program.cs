using System;
using System.Collections.Generic;

namespace PreRelease22Autumn2019
{
    class Program
    {
        static int GetUserIndex(List<string> list, string name)
        {
            while (true)
            {
                Console.WriteLine($"\n{char.ToUpper(name[0])}{name.Substring(1)}s:");
                for (int index = 0; index < list.Count; index++)
                {
                    Console.WriteLine($"{index+1}: {list[index]}");
                }
                Console.WriteLine($"Enter the {name} you want: ");
                string userChoice = Console.ReadLine();
                try
                {
                    int userIndex = Convert.ToInt32(userChoice);
                    if (1 <= userIndex && userIndex <= list.Count)
                    {
                        return userIndex;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid {name} number.");
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine($"Please enter a number between 1 and {list.Count}.");
                }

            }
        }
        static int GetUserInt(List<int> list, string name)
        {

            while (true)
            {
                Console.WriteLine($"\n{char.ToUpper(name[0])}{name.Substring(1)}s:");
                foreach (int item in list)
                {
                    Console.WriteLine(item);
                } 
                Console.WriteLine($"Enter the {name} you want: ");
                string userChoice = Console.ReadLine();
                try
                {
                    int userInt = Convert.ToInt32(userChoice);
                    foreach (int item in list)
                    {
                        if (item == userInt)
                        {
                            return userInt;
                        }
                    }
                    Console.WriteLine($"Invalid {name} choice.");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter a number from the list.");
                }

            }
        }
        static int GetUserInt(string name, int lowerBound, int upperBound)
        {
            while (true)
            {
                Console.WriteLine($"Enter the number of {name}s you want: ");
                string answer = Console.ReadLine();
                try
                {
                    int answerInt = Convert.ToInt32(answer);
                    if (lowerBound <= answerInt && answerInt <= upperBound)
                    {
                        return answerInt;
                    }
                    else
                    {
                        Console.WriteLine($"The number you enter must be between {lowerBound} and {upperBound}.");
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine($"Please enter a number between {lowerBound} and {upperBound}");
                }
            }
        }
        static void Main(string[] args)
        {
            List<string> colours = new List<string>()
            {
                "Grey",
                "Red",
                "Green",
                "Custom"
            };
            int colourIndex = GetUserIndex(colours, "colour");
            List<int> depths = new List<int>()
            {
                38,
                45
            };
            int depth = GetUserInt(depths, "depth");
            List<string> sizes = new List<string>()
            {
                "600x600 square",
                "450x450 square",
                "600x700 rectangular",
                "600x450 rectangular",
                "300 diameter round",
                "450 diameter round"
            };
            int sizeIndex = GetUserIndex(sizes, "size");
            // Area per slab
            double area = 0;
            switch (sizeIndex)
            {
                case 1:
                    area = 600*600;
                    break;
                case 2:
                    area = 450*450;
                    break;
                case 3:
                    area = 600*700;
                    break;
                case 4:
                    area = 600*450;
                    break;
                case 5:
                    area = (Math.Pow(300*0.5, 2))*Math.PI;
                    break;
                case 6:
                    area = (Math.Pow(450*0.5, 2))*Math.PI;
                    break;
                default:
                    area = 0;
                    break;
            }
            double volume = area * depth;
            //Console.WriteLine($"{area} {volume}");
            //volume = 100000;
            // 100,000 mm^3 = $0.05
            double baseCost = volume/100000 *0.05;
            // Console.WriteLine($"${Math.Round(baseCost, 2)}");
            bool customColour = (colourIndex == 4) ? true : false;
            int setUpPrice = (customColour) ? 5 : 0;
            double cost_colour_multiplier = 1;
            switch (colourIndex)
            {
                case 1:
                    cost_colour_multiplier = 1;
                    break;
                case 2:
                    cost_colour_multiplier = 1.1;
                    break;
                case 3:
                    cost_colour_multiplier = 1.1;
                    break;
                case 4:
                    cost_colour_multiplier = 1.15;
                    break;
                default:
                    cost_colour_multiplier = 1;
                    break;
            }
            double slabCost = baseCost * cost_colour_multiplier;
            double twentySlabCost = 20 * slabCost;
            Console.WriteLine($"Colour: {colours[colourIndex-1]}\nDepth: {depth}mm\nShape: {sizes[sizeIndex-1]}");
            Console.WriteLine($"Cost per 20 slabs: ${Math.Round(twentySlabCost, 2)}");
            if (customColour)
            {
                Console.WriteLine($"Plus a ${setUpPrice} set up cost (for {colours[colourIndex-1]} colour).");
            }
            int numberSlabs = GetUserInt("slab", 20, 100);
            double numberSlabsDivideTwenty = Convert.ToDouble(numberSlabs)/20;
            double actualNumberSlabs = Math.Ceiling(numberSlabsDivideTwenty)*20;
            double totalSlabCost = actualNumberSlabs * slabCost;
            double totalCost = totalSlabCost + setUpPrice;
            Console.WriteLine($"{actualNumberSlabs} slabs will be ordered at a total cost of ${Math.Round(totalCost, 2)}.");
        }
    }
}
