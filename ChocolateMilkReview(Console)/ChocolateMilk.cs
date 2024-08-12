using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateMilkReview_Console_
{
    internal class ChocolateMilk : IComparable<ChocolateMilk>
    {

        private string _BrandName;
        private string _MilkName;
        private string _Percent;
        private string _State;
        private string _Rating;
        private string _Description;
        private string _milkKey;
        public ChocolateMilk(string brandName, string milkName, 
            string percent, string state, string rating, string description)
        {
            _BrandName = brandName;
            _MilkName = milkName;
            _Percent = percent;
            _State = state;
            _Rating = rating;
            _Description = description;

            _milkKey = _BrandName + _MilkName + _Percent;
        }

        public ChocolateMilk()
        {
            _BrandName = " ";
            _MilkName = " ";
            _Percent = " ";
            _State = " ";
            _Rating = " ";
            _Description = " ";

        }
        public string BrandName { get => _BrandName; set => _BrandName = value; }
        public string MilkName { get => _MilkName; set => _MilkName = value; }
        public string Percent { get => _Percent; set => _Percent = value; }
        public string State { get => _State; set => _State = value; }
        public string Rating { get => _Rating; set => _Rating = value; }
        public string Description { get => _Description; set => _Description = value; }
        public string MilkKey { get => _milkKey; set => _milkKey = value; }

        public int CompareTo(ChocolateMilk other)
        {
            if (other == null) return 1;

            int brandCompare = _BrandName.CompareTo(other._BrandName);
            if (brandCompare == 0)
            {
                int nameCompare = _MilkName.CompareTo(other._MilkName);
                 if (nameCompare == 0)
                {
                    int percentCompare = _Percent.CompareTo(other._Percent);

                    if (percentCompare == 0)
                    {
                        return _Rating.CompareTo(other._Rating);
                    }

                    return percentCompare;
                }

                return nameCompare;
            }
            
            return brandCompare;
        }
    }
}
