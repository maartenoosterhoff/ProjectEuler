using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver019 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            var startDate = new DateTime(1901, 1, 1);
            var endDate = new DateTime(2000, 12, 31);
            var count = Enumerable.Range(0, int.MaxValue)
                .Select(x => startDate.AddDays(x))
                .TakeWhile(x => x <= endDate)
                .Where(x => x.Day == 1)
                .Where(x => x.DayOfWeek == DayOfWeek.Sunday)
                .Count();
            return count.ToString();
        }

        protected override string GetProblemDescription()
        {
            return @"You are given the following information, but you may prefer to do some research for yourself.

* 1 Jan 1900 was a Monday.
* Thirty days has September, April, June and November.
  All the rest have thirty-one,
  Saving February alone,
  Which has twenty-eight, rain or shine.
  And on leap years, twenty-nine.
* A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
";
        }

        public override int ProblemNumber => 19;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}
