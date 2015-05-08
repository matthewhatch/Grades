using System;
using System.Collections.Generic;


namespace Grades
{
    public class GradeBook
    {

        public GradeBook(string name = "No Name")
        {
            _name = name;
            grades = new List<float>();
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
                grades.Add(grade);
            }
        }

        public GradeStatistics ComputeStatistics()
        {
            if(Calculating != null)Calculating(this);
            GradeStatistics stats = new GradeStatistics();
            float sum = 0f;
            
            foreach (float grade in grades) 
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;
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
        private List<float> grades;

    }
}
