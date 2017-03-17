using System;
using System.Diagnostics;

namespace ProjectEuler.Problems
{
    internal abstract class ProblemSolverBase
    {
        public string Solve()
        {
            var stopwatch = Stopwatch.StartNew();
            var solution = GetSolution();
            stopwatch.Stop();

            return string.Format(
                "PROBLEM:{0}{0}{1}{0}{0}SOLUTION:{0}{0}{2}{0}{0}TIME:{0}{0}{3}{0}{0}SOLVED STATE:{0}{0}{4}{0}{0}",
                Environment.NewLine,
                GetProblemDescription(),
                solution,
                stopwatch.Elapsed,
                SolvedState
            );
        }

        protected abstract string GetProblemDescription();
        protected abstract string GetSolution();
        public virtual SolvedState SolvedState => SolvedState.Unsolved;
        public abstract int ProblemNumber { get; }
        public string ProblemTitle => SolvedState == SolvedState.Unsolved ? $"Problem {ProblemNumber} (unsolved)" : $"Problem {ProblemNumber}";
    }

    internal enum SolvedState
    {
        Solved,
        Unsolved
    }
}
