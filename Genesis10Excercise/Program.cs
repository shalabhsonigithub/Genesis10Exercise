using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Genesis10Exercise
{
    /*
     * Result 1 for PART ONE: Weather Data
     * In the attached weather.dat file, you’ll find daily weather data for Morristown, NJ for June 2002. 
     * Save this text file, then write a program to output the day number (found in column one) 
     * with the smallest temperature spread (the maximum temperature is the second column, the minimum temperature is the third column).

     * Result 2 for PART TWO: Soccer League Table 
     * The attached file football.dat contains the results from the English Premier League for 2001/2. 
     * The columns labeled ‘F’ and ‘A’ contain the total number of goals scored for and against each team in that season 
     * (so Arsenal scored 79 goals against opponents, and had 36 goals scored against them). 
     * Write a program to print the name of the team with the smallest difference in ‘for’ and ‘against’ goals.
    */

    class Program
    {
        static void Main(string[] args)
        {
            string WeatherData = File.ReadAllText("..\\..\\..\\Data\\weather.dat");
            DatFileReader datFileReader = new DatFileReader();
            List<Row> rows = datFileReader.WeatherData(WeatherData);
            Row smallestTempSpreadDay = rows.OrderBy(x => x.Differance).FirstOrDefault();
            if (smallestTempSpreadDay != null)
            {
                Console.WriteLine($"Day: {smallestTempSpreadDay.Name}" +
                                  $" MinTemp: {smallestTempSpreadDay.Col2}" +
                                  $" MaxTemp: {smallestTempSpreadDay.Col1}" +
                                  $" Difference: {smallestTempSpreadDay.Differance}");
            }
            else
            {
                Console.WriteLine("Weather.dat file is empty");
            }

            WeatherData = File.ReadAllText("..\\..\\..\\Data\\football.dat");
            datFileReader = new DatFileReader();
            rows = datFileReader.SoccerScores(WeatherData);
            Row teamWithSmallScoreDifference = rows.OrderBy(x => x.Differance).FirstOrDefault();
            if (teamWithSmallScoreDifference != null)
            {
                Console.WriteLine($"Team: {teamWithSmallScoreDifference.Name}" +
                                  $" Against: {teamWithSmallScoreDifference.Col1}" +
                                  $" For: {teamWithSmallScoreDifference.Col2}" +
                                  $" Difference: {teamWithSmallScoreDifference.Differance}");
            }
            else
            {
                Console.WriteLine("Football.dat file is empty");
            }
        }
    }
}
