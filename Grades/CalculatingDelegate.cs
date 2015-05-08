using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grades
{
    public delegate void CalculatingDelegate (object sender);
    public delegate void AddGradeDelegate(object sender, AddGradeEventArgs args);
}
