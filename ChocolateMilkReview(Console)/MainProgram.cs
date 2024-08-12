using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ChocolateMilkReview_Console_
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {

            string filePath = "MilkReviews.json";
            MilkReviewProgram reviewProgram = LoadProgram(filePath);


            int selection = 1;
            while (selection > 0 && selection < 4)
            { 
                selection = menu();
               
                switch (selection)
                {
                    case 1:
                        ChocolateMilk milk = CreateMilk();
                        reviewProgram.InsertMilk(milk);
                        break;
                    case 2:
                        reviewProgram.PrintReview(getName());
                        break;
                    case 3:
                        reviewProgram.PrintAllReviews();
                        break;
 
                }
            }


            reviewProgram.PrintAllReviews();

            Console.ReadKey();

            SaveProgram(reviewProgram, filePath);  

        }
        
        static public int menu()
        {
            bool invalid = true;
            int selection = 0;

            Console.WriteLine("MILK REVIEW APP");
            Console.WriteLine("------------");
            Console.WriteLine("1. Add Review");
            Console.WriteLine("2. Search Review");
            Console.WriteLine("3. All Reviews");
            Console.WriteLine("4. Exit");

            while (invalid)
            {
          
                string input = Console.ReadLine();

                if (int.TryParse(input, out selection))
                {
                    invalid = false;
                }
                else
                {
                    Console.Write("Error! Invalid input.");
                }

            }
           
            return selection;

        }
        static public MilkReviewProgram LoadProgram(string filePath)
        {
          
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<MilkReviewProgram>(jsonString);

            }
            
                Console.WriteLine("Program not found.");
                MilkReviewProgram reviewProgram = new MilkReviewProgram();

            return reviewProgram;

        }
        static public void SaveProgram(MilkReviewProgram program, string filePath)
        {
            
            string json = JsonSerializer.Serialize(program, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);

        }  
        static public ChocolateMilk CreateMilk()
        {
          

            Console.Write("Brand: " );
            string brand = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("%: ");
            string perct = Console.ReadLine();

            Console.Write("State: ");
            string st = Console.ReadLine();

            Console.Write("Rating: ");
            string rate = Console.ReadLine();

            Console.Write("Desc: ");
            string desc = Console.ReadLine();


            ChocolateMilk milk = new ChocolateMilk(brand, name, perct, st, rate, desc);


            return milk;
        }
        static public String getName()
        {
            Console.WriteLine("Name: ");
            return Console.ReadLine();

        }

    }
}
