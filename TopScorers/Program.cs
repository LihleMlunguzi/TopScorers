using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopScorers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //create a  list that will be used to store the scorers name and surname
            List<(string, int)> scores = new List<(string, int)>();
            int i = 0;
            //use Stream reader to read the file
            using (var rd = new StreamReader(@"C:\TestData.csv"))
            {
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(',');
                    if(i!=0)
                    {
                        scores.Add((splits[0] + " " + splits[1],int.Parse(splits[2])));
                    }
                   
                    i++;
                }
            }
           //Find top Scorers
            List<(string, int)> topScorers = FindTopScorers(scores);

            if (topScorers.Count == 0)
            {
                Console.WriteLine("No top scorers found.");
                Console.ReadLine();
            }

            // Sort top scorers alphabetically
            topScorers.Sort((a, b) => string.Compare(a.Item1, b.Item1, StringComparison.Ordinal));

            // Output the results
            Console.WriteLine("Top Scorers:");
            foreach ((string name, int sc) in topScorers)
            {
                Console.WriteLine($"{name}: {sc}");
            }
            Console.ReadLine();
        }

        static List<(string, int)> FindTopScorers(List<(string, int)> scores)
        {
            if (scores.Count == 0)
                return new List<(string, int)>();

            int maxScore = scores.Max(s => s.Item2);
            return scores.Where(s => s.Item2 == maxScore).ToList();
        }
    }
}

