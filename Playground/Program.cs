using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace Playground
{
    public class MarkSheet
    {
        public int Id { get; set; }

        public string Subject
        {
            get;
            set;
      
        }

        public decimal Score
        {
            get;
            set;
        }

    }


    public interface IDataReader
    {
        List<string> Read();
    }

    public class FileReader : IDataReader
    {
        private StreamReader reader;
        List<string>  rows;
        string fileLocation;
    
        public FileReader(string filePath)
        {
            fileLocation = filePath;
            rows = new List<string>();
        }

        public List<string> Read()
        {
            using(reader = new StreamReader(fileLocation))
            {
                while (!reader.EndOfStream)
                {
                    rows.Add(reader.ReadLine());
                }
            }

            return rows;
        }
    }

    public class Mapper
    {
        static string[] fieldMap;
        static System.Text.RegularExpressions.Regex matchExp = 
            new System.Text.RegularExpressions.Regex(@"(\d+)\s*(\w+){1}\s*(\d+)");
        static Regex specialMatchEx = new Regex(@"((\d+)\s{1}(\w+\s{1}\w*)\s{1}(\d+))");
        private IDataReader reader;
        public Mapper(IDataReader dataReader)
        {
            reader = dataReader;
        }
        static Mapper()
        {
            fieldMap = new string[] {"Id","Subject", "Score"};
        }

        private static MarkSheet Map(string input)
        {
            MarkSheet mark = null;
            mark = new MarkSheet();

            string[] tokens = input.Split(new char[] { ' ' });
            int id;
            decimal score;
            int.TryParse(tokens[0], out id);
            mark.Id = id;

            decimal.TryParse(tokens.Last(), out score);
            mark.Score = score;

            if (tokens.Length == 4)
                mark.Subject = tokens[1] + " " + tokens[2];
            else
                mark.Subject = tokens[1];

            return mark;
        }

        public List<MarkSheet> ReadMarkSheet()
        {
            List<MarkSheet> marks = new List<MarkSheet>();
            List<string> rows = reader.Read();
            foreach (string row in rows)
            {
                marks.Add(Map(row));
            }

            return marks;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            FileReader fileReader = new FileReader(Environment.CurrentDirectory + "/StudentData.txt");
            Mapper mapper = new Mapper(fileReader);
            List<MarkSheet> marks = mapper.ReadMarkSheet();

            var avg = marks.GroupBy(s => s.Subject, sc => sc.Score).Select(g => new
            {
                Subject = g.Key,
                Average = g.Average()
        });


                      

            Console.WriteLine("Average for DataSource = " + marks.Where(s => s.Subject == "Data Source").Average(a => a.Score));
            Console.Read();
        }
    }
}
