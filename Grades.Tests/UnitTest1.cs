using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void CalculatesHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(90f);
            book.AddGrade(50f);

            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(90f, stats.HighestGrade);
        }

        [TestMethod]
        public void CreatesGradeBookWithName() 
        {
            GradeBook book = new GradeBook("TestBook");
            Assert.AreEqual(book.Name, "TestBook");
        }

        [TestMethod]
        public void CreateGradeBookWithDefaultName()
        {
            GradeBook book = new GradeBook();
            Assert.AreEqual(book.Name, "No Name");
        }
    }
}
