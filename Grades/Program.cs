using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            GradeBook book = new GradeBook("Matt's Book");
            book.AddGrade(88f);
            book.AddGrade(87f);
            book.AddGrade(50f);
            GradeStatistics stats = book.ComputeStatistics();

            book.NameChanged += OnNameChanged;

            book.Name = "Whatever";
            Console.WriteLine(book.Name);
            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine(stats.LowestGrade);
        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);
        }

        
    }
}
