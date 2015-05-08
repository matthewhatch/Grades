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

            GradeBook book = new GradeBook();
            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged2;
            book.Calculating += OnCalculate;
            book.AddingGrade += OnAddGrade;

            book.Name = "Matt's Grade Book";
            book.AddGrade(88f);
            book.AddGrade(87f);
            book.AddGrade(90f);

            book.WriteGrade(Console.Out);

            GradeStatistics stats = book.ComputeStatistics();

            book.Name = "Whatever";
            book.Name = "";
            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine("Your letter grade is {0}", stats.LetterGrade);
            Console.WriteLine("Your grades are {0}", stats.Description);
        }

        private static void OnAddGrade(object sender, AddGradeEventArgs args)
        {
            Console.WriteLine("Adding new Grade {0}",args.Grade);
        }

        private static void OnCalculate(object sender)
        {
            Console.WriteLine("Calculating Gradees");
        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);
        }

        private static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("GradeBookName: {0}", args.NewValue);
        }

        
    }
}
