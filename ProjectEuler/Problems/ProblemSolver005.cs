using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems {
    class ProblemSolver005 : ProblemSolverBase {
        protected override string GetSolution() {
            var solution = Helper.GetInfiniteRange()
                .Where(a => IsCorrect(a))
                .First();

            return solution.ToString();
        }

        private static bool IsCorrect(long number) {
            if (number % (long)2 == 0 &&
                    number % (long)3 == 0 &&
                    number % (long)4 == 0 &&
                    number % (long)5 == 0 &&
                    number % (long)6 == 0 &&
                    number % (long)7 == 0 &&
                    number % (long)8 == 0 &&
                    number % (long)9 == 0 &&
                    number % (long)10 == 0 &&
                    number % (long)11 == 0 &&
                    number % (long)12 == 0 &&
                    number % (long)13 == 0 &&
                    number % (long)14 == 0 &&
                    number % (long)15 == 0 &&
                    number % (long)16 == 0 &&
                    number % (long)17 == 0 &&
                    number % (long)18 == 0 &&
                    number % (long)19 == 0 &&
                    number % (long)20 == 0)
                return true;
            return false;
        }

        protected override string GetProblemDescription() {
            return @"2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?";
        }

        public override int ProblemNumber {
            get { return 5; }
        }
    }
}
