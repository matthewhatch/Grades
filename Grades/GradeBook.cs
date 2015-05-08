using System;
using System.Collections.Generic;
using System.IO;


namespace Grades
{
    public class GradeBook
    {

        public GradeBook(string name = "No Name")
        {
            _name = name;
            _grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            if (AddingGrade != null) 
            {
                AddGradeEventArgs args = new AddGradeEventArgs();
                args.Grade = grade;
                AddingGrade(this,args);
            }

            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
            }
        }

        public void WriteGrade(TextWriter textWriter)
        {
            textWriter.WriteLine("Writing grades");
            foreach (float grade in _grades)
            {
                textWriter.WriteLine(grade);
            }
        }

        public GradeStatistics ComputeStatistics()
        {
            if(Calculating != null)Calculating(this);
            GradeStatistics stats = new GradeStatistics();
            float sum = 0f;
            
            foreach (float grade in _grades) 
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / _grades.Count;
            return stats;
        }

        public string Name
        {
            get 
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Name cannot be null or empty");    
                }

                if (_name != value) 
                {
                    var oldValue = _name;
                    _name = value;
                    if (NameChanged != null) 
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;
                        NameChanged(this, args);
                    }
                }
            }
        }

        public event NameChangedDelegate NameChanged;
        public event CalculatingDelegate Calculating;
        public event AddGradeDelegate AddingGrade;
        private string _name;
        private List<float> _grades;


        
    }
}
