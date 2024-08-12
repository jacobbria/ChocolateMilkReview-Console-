using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateMilkReview_Console_
{
    internal class MilkReviewProgram
    {
        private SortedDictionary<String, ChocolateMilk> _MilkDictionary;

        public MilkReviewProgram()
        {
            _MilkDictionary = new SortedDictionary<string, ChocolateMilk>();
        }
        public MilkReviewProgram(SortedDictionary<string, ChocolateMilk> milkDictionary)
        {
            _MilkDictionary = milkDictionary;
        }
        public SortedDictionary<string, ChocolateMilk> MilkDictionary 
        {
            get { return _MilkDictionary; }
            set { _MilkDictionary = value; }
        }
        public bool InsertMilk(ChocolateMilk milk)
        {
            if (_MilkDictionary != null)
            {
                
                if (!_MilkDictionary.ContainsKey(milk.MilkKey))
                {              
                    _MilkDictionary.Add(milk.MilkKey, milk);

                    Console.WriteLine("Success!");

                    return true;
                }
                else
                {
                    Console.WriteLine("ERROR! Already Reviewed");
                }
            }

            Console.WriteLine("Failure.");
            return false;
        }
        public bool RemoveMilk(string milkName) 
        { 
        
            if (_MilkDictionary.ContainsKey(milkName))
            {
                _MilkDictionary.Remove(milkName);
                Console.WriteLine("Removed!");
                return true;

            }

            Console.WriteLine("Not removed.");
            return false;
        }      
        public void PrintAllReviews()
        {
            Console.WriteLine("MILK REVIEWS");

            foreach ( var milk in _MilkDictionary)
            {
                Console.WriteLine($@" {milk.Value.BrandName.ToUpper()} {milk.Value.MilkName.ToUpper()} ({milk.Value.Percent.ToUpper()})");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($@"RATING: {milk.Value.Rating}");
                Console.WriteLine($@"{milk.Value.Description} - found in {milk.Value.State} ");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("----------------------------------------------");

            }
        }
        public ChocolateMilk findMilk(string milkName)
        {
            if (_MilkDictionary.ContainsKey(milkName))
            {

                Console.WriteLine($"Milk {milkName} found.");
                return _MilkDictionary[milkName];

            }

            Console.WriteLine("Milk not found.");
            return null;
        }       
        public bool WriteToText()
        {
            return true;
        }       
        public void PrintReview(string name)
        {
            try
            {
                ChocolateMilk milk = findMilk(name);

                Console.WriteLine($@" {milk.BrandName.ToUpper()} {milk.MilkName.ToUpper()} ({milk.Percent.ToUpper()})");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($@"RATING: {milk.Rating}");
                Console.WriteLine($@"{milk.Description} - found in {milk.State} ");
                Console.WriteLine("----------------------------------------------");
            }
            catch (Exception e) 
            { 
                Console.WriteLine(e.ToString()); 
            }

        }
        public void ClearProgram()
        {
            MilkDictionary.Clear();

        }
    }
}
