using System;
using System.Collections.Generic;

public class RandomNumberGenerator
{
    private List<double> numbers;
    private double? varianceCache;
    private double? stdDeviationCache;
    private double? medianCache;

    public RandomNumberGenerator(int length)
    {
        numbers = new List<double>();
        varianceCache = null;
        stdDeviationCache = null;
        medianCache = null;

        Random rand = new Random();
        for (int i = 0; i < length; i++)
        {
            double num = rand.NextDouble();
            numbers.Add(num);
        }
    }

    public double Variance
    {
        get
        {
            if (!varianceCache.HasValue)
            {
                double mean = Mean;
                double variance = 0;
                foreach (double num in numbers)
                {
                    variance += Math.Pow(num - mean, 2);
                }
                variance /= numbers.Count;
                varianceCache = variance;
            }
            return varianceCache.Value;
        }
    }

    public double StandardDeviation
    {
        get
        {
            if (!stdDeviationCache.HasValue)
            {
                double stdDeviation = Math.Sqrt(Variance);
                stdDeviationCache = stdDeviation;
            }
            return stdDeviationCache.Value;
        }
    }

    public double Median
    {
        get
        {
            if (!medianCache.HasValue)
            {
                numbers.Sort();
                int count = numbers.Count;
                if (count % 2 == 0)
                {
                    double median1 = numbers[count / 2 - 1];
                    double median2 = numbers[count / 2];
                    medianCache = (median1 + median2) / 2;
                }
                else
                {
                    medianCache = numbers[count / 2];
                }
            }
            return medianCache.Value;
        }
    }

    public List<double> Numbers
    {
        get { return numbers; }
    }

    public double Mean
    {
        get { return numbers.Average(); }
    }
}


// отправка

RandomNumberGenerator rng = new RandomNumberGenerator(1000);
double variance = rng.Variance;
double stdDeviation = rng.StandardDeviation;
double median = rng.Median;
List<double> numbers = rng.Numbers;
double mean = rng.Mean;
