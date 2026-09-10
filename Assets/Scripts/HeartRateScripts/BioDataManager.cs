using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BioDataManager : MonoBehaviour
{
    private double stressLevel;

    private List<double> heartRates = new List<double>();

    // Api Methode to Set current HeartRate and Update Stress Level
    public void setHeartRate(double heartRate)
    {
        this.heartRates.Add(heartRate);

        this.stressLevel = CalculateRmssd(this.heartRates
            .Where(bpm => bpm > 0)
            .Select(bpm => 60000.0 / bpm)
            .ToList());

    }

    // Api Methode to get current HeartRate
    public double getHeartRate()
    {
        if (heartRates.Count == 0) return 0;
        return (int)this.heartRates.ElementAt(heartRates.Count - 1);
    }

    // Api Methode to get RMSSD Value
    public double getStressLevel()
    {
        return this.stressLevel;
    }

    // Formula to Calulate RMSSD value Based on rrIntervals (This Funktion comes from Gemini)
    private static double CalculateRmssd(List<double> rrIntervals)
    {
        if (rrIntervals == null || rrIntervals.Count < 2)
        {
            return 0;
        }

        double sumOfSquaredDifferences = 0;
        int differenceCount = rrIntervals.Count - 1;

        for (int i = 0; i < differenceCount; i++)
        {
            // Find the consecutive difference
            double diff = rrIntervals[i + 1] - rrIntervals[i];

            // Square the difference and add to sum
            sumOfSquaredDifferences += Math.Pow(diff, 2);
        }

        // Calculate the Mean of the squared differences
        double meanSquaredDifference = sumOfSquaredDifferences / differenceCount;

        // Take the Square Root
        return Math.Sqrt(meanSquaredDifference);
    }
}
