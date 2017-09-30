namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NearestTime : ISolution
    {
        private int[] digits = new int[4];

        private TimeSpan inputTime;

        public NearestTime(string time)
        {
            digits[0] = Int32.Parse(time[0].ToString());
            digits[1] = Int32.Parse(time[1].ToString());
            digits[2] = Int32.Parse(time[3].ToString());
            digits[3] = Int32.Parse(time[4].ToString());

            this.inputTime = TimeSpan.Parse(time);
        }
        public void Run()
        {
            double minDiff = Int32.MaxValue;
            TimeSpan minTime = this.inputTime;
            int count = 0;

            HashSet<int> nos = new HashSet<int>(digits);

            TimeSpan oneMin = new TimeSpan(0, 1, 0);
            TimeSpan endTime = new TimeSpan(23, 59, 0);

            for (TimeSpan ts = new TimeSpan(0, 0, 0); ts < endTime; ts = ts.Add(oneMin))
            {
                if (ts != this.inputTime)
                {
                    string currTime = ts.ToString(@"hh\:mm");
                    int d1 = Int32.Parse(currTime[0].ToString());
                    int d2 = Int32.Parse(currTime[1].ToString());
                    int d3 = Int32.Parse(currTime[3].ToString());
                    int d4 = Int32.Parse(currTime[4].ToString());

                    if (nos.Contains(d1) && nos.Contains(d2) && nos.Contains(d3) && nos.Contains(d4))
                    {
                        count++;

                        var diff = Math.Abs((ts - this.inputTime).TotalMinutes);

                        if (ts < this.inputTime)
                        {
                            diff = (24 * 60) - diff;
                        }

                        if (diff < minDiff)
                        {
                            minDiff = diff;
                            minTime = ts;
                        }
                    }
                }
            }
            Console.WriteLine("Next nearest time of {0} is {1} while is {2} seconds",
            this.inputTime.ToString(),
            minTime.ToString(),
            minDiff);

        }
    }
}