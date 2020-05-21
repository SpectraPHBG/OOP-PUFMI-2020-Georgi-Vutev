using System.Linq;
using System;
using System.Collections.Generic;

namespace Task1
{

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string[]> entries = new Dictionary<string, string[]>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end")
                {
                    break;
                }
                string[] inputData = input.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries).Select(str=>str.Trim()).ToArray();
                string subject = inputData[0];
                string name = inputData[1];
                string facNumber = inputData[2];
                string grade = inputData[3];
                try
                {
                    entries.Add(name, new string[] { subject, facNumber, grade});
                }
                catch (ArgumentException)
                {

                }
            }
            Console.WriteLine();
            foreach (KeyValuePair<string, string[]> entry in entries.OrderByDescending(p=>double.Parse(p.Value[2])))
            {
                Console.WriteLine($"{entry.Key} {entry.Value[0]} {entry.Value[2]}");
            }
        }
    }
}
