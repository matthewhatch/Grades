using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grades
{
    public class CalculatingEventArgs : EventArgs
    {
        public float oldAverage;
    }

    public class AddGradeEventArgs : EventArgs
    {
        public float Grade;
    }
}
