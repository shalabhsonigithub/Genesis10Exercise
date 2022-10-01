using System;
using System.Collections.Generic;
using System.Linq;

namespace Genesis10Exercise
{
    public class DatFileReader
    {
        public List<Row> WeatherData(string fileData)
        {
            return DatReader(
                fileData,
                2, //Provided weather dat file first 2 rows are header/blank 
                2, //temperature data starts from row 3 
                ColumnData.Range(2, 2), //temperature data starts from row 3 
                ColumnData.Range(6, 2), // MaxTemp in 2 digit (can be in 3 so start can be changed to 5)
                ColumnData.Range(12, 2)); // temp starts at character index 12 and is 2 digits
        }

        private List<Row> DatReader(string fileData, int skipStart, int skipEnd, ColumnData KeyColumn, ColumnData DataColumn1, ColumnData DataColumn2)
        {
            string[] split = fileData.Split("\n");
            var parsed = split
                .Skip(skipStart)
                .Take(split.Length - (skipStart + skipEnd))
                .Where(row => !row.Contains("-------------------------------------------------------")) //to skip dash-- line in football.dat
                .Select(x =>
                {
                    return new Row()
                    {
                        Name = x.Substring(KeyColumn.From, KeyColumn.Length).Trim(),
                        Col1 = int.Parse(x.Substring(DataColumn1.From, DataColumn1.Length)),
                        Col2 = int.Parse(x.Substring(DataColumn2.From, DataColumn2.Length))
                    };
                })
                .ToList();
            return parsed;
        }

        public List<Row> SoccerScores(string fileData)
        {
            return DatReader(fileData, 1, 1, ColumnData.Range(7, 15), ColumnData.Range(43, 2), ColumnData.Range(50, 2));
        }
    }
    public class ColumnData
    {
        public int From;
        public int Length;

        public static ColumnData Range(int from, int length)
        {
            return new ColumnData { From = from, Length = length };
        }
    }

    public class Row
    {
        public string Name;
        public int Col1;
        public int Col2;

        public int Differance
        {
            get
            {
                return Math.Abs(Col2 - Col1);
            }
        }
    }
}
