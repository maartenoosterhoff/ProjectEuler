using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProjectEuler.Problems {
    abstract class ProblemSolverBase {
        public string Solve() {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var solution = GetSolution();
            stopwatch.Stop();
            return string.Format(
                "PROBLEM:{0}{0}{1}{0}{0}SOLUTION:{0}{0}{2}{0}{0}TIME:{0}{0}{3}{0}{0}SOLVED STATE:{0}{0}{4}{0}{0}",
                Environment.NewLine,
                GetProblemDescription(),
                GetSolution(),
                stopwatch.Elapsed.ToString(),
                SolvedState
            );
        }

        protected abstract string GetProblemDescription();
        protected abstract string GetSolution();
        public virtual SolvedState SolvedState { get { return SolvedState.Unsolved; } }
        public abstract int ProblemNumber { get; }
        public string ProblemTitle {
            get {
                if (SolvedState == SolvedState.Unsolved) {
                    return string.Format("Problem {0} (unsolved)", ProblemNumber);
                }
                return string.Format("Problem {0}", ProblemNumber);
            }
        }
    }

    enum SolvedState {
        Solved,
        Unsolved
    }
}
