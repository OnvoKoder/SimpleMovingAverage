using System;
using System.Collections.Generic;

namespace SimpleMovingAverage.Class
{
    internal class MovingAvg
    {
        internal void Search(in string[] data, in int step,out List<double> avg)
        {
            avg = new List<double>();
            double solution = 0;
            for(int i = 0; i <= data.Length; i++)
            {
                if (i > (step - 1))
                {
                    for(int j = ((i-1)-(step-1)); j < i; j++)
                    {
                        solution+=Convert.ToDouble(data[j]);
                    }
                    avg.Add(Math.Round((solution/step),2));
                    solution = 0;
                }
            }
        }
    }
}
