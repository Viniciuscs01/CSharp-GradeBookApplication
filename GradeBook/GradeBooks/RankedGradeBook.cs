using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
  class RankedGradeBook : BaseGradeBook
  {
    public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
    {
      Type = GradeBookType.Ranked;
    }

    public override char GetLetterGrade(double averageGrade)
    {
      if (Students.Count < 5)
        throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

      var limit = (int)(Students.Count * 0.2);
      var orderedGrades = Students.OrderByDescending(s => s.AverageGrade).ToArray();

      if (orderedGrades[limit - 1].AverageGrade <= averageGrade)
        return 'A';
      else if (orderedGrades[limit * 2 - 1].AverageGrade <= averageGrade)
        return 'B';
      else if (orderedGrades[limit * 3 - 1].AverageGrade <= averageGrade)
        return 'C';
      else if (orderedGrades[limit * 4 - 1].AverageGrade <= averageGrade)
        return 'D';

      return 'F';
    }

    public override void CalculateStatistics()
    {
      if (Students.Count >= 5)
        base.CalculateStatistics();

      Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
    }

    public override void CalculateStudentStatistics(string name)
    {
      if (Students.Count >= 5)
        base.CalculateStudentStatistics(name);

      Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
    }

  }
}
