using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
  class StandardGradeBook : BaseGradeBook
  {
    public StandardGradeBook(string name, bool isWeigted) : base(name, isWeigted)
    {
      Type = GradeBookType.Standard;
    }
  }
}
