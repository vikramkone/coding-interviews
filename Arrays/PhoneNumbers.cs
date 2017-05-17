namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PhoneNumbers : ISolution
    {
        private int phoneNo;

        public PhoneNumbers(int number)
        {
            this.phoneNo = number;
        }

        public void Run()
        {
            Dictionary<char, string> map = new Dictionary<char, string>
            {
                { '0', ""},
                { '1' , ""},
                { '2' , "ABC"},
                { '3' , "DEF"},
                { '4' , "GHI"},
                { '5' , "JKL"},
                { '6' , "MNO"},
                { '7' , "PQRS"},
                { '8' , "TUV"},
                { '9' , "WXYZ"},
            };

            List<string> result =  this.GeneratePhoneNumbers(map);
            result.ForEach(x => Console.WriteLine(x));
        }

        private List<string> GeneratePhoneNumbers(Dictionary<char, string> map)
        {
            var digits = this.phoneNo.ToString();
            List<string> result = new List<string>();

            foreach (char digit in digits)
            {
                var alphabets = map[digit];

                if (result.Count == 0)
                {
                    result.AddRange(alphabets.Select(x => x.ToString()));
                }
                else
                {
                    List<string> tmp = new List<string>();

                    foreach (string s in result)
                    {
                        foreach (char c in alphabets)
                        {
                            tmp.Add(s + c);
                        }
                    }

                    result = tmp;
                }
            }

            return result;
        }
    }
}