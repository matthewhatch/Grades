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

        [TestMethod]
        public void GetLetterGradeA()
        { 
            GradeBook book = new GradeBook("GradeBook");
            book.AddGrade(90f);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.LetterGrade, 'A');
        }

        [TestMethod]
        public void GetLetterGradeB()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(80f);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.LetterGrade,'B');
        }

        [TestMethod]
        public void GetLetterGradeC()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(70f);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.LetterGrade, 'C');
        }

        [TestMethod]
        public void GetLetterGradeD()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(60f);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.LetterGrade, 'D');
        }

        [TestMethod]
        public void GetLetterGradeF()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(59f);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.LetterGrade, 'F');
        }

        [TestMethod]
        public void GetDescriptionA()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(90f);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.Description, "Excellent!");
        }

        [TestMethod]
        public void GetDescriptionB()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(80f);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.Description, "Above Average");
        }

        [TestMethod]
        public void GetDescriptionC()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(70f);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.Description, "Average");
        }

        [TestMethod]
        public void GetDescriptionD()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(60f);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.Description, "Below Average");
        }

        [TestMethod]
        public void GetDescriptionF()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(0f);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.Description, "Fail");
        }
    }
}
