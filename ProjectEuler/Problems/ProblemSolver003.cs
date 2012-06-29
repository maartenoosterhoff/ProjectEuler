using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems {
    class ProblemSolver003 : ProblemSolverBase {
        protected override string GetSolution() {
            long number = 600851475143;
            long squareRoot = ((long)Math.Sqrt((double)number)) + 1000;

            var primes = Helper.GetPrimesWithErastosthenesUpTill(squareRoot);
            var solution = primes
                .Where(x => number % x == 0)
                .Max();

            return solution.ToString();
        }

        protected override string GetProblemDescription() {
            return @"The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?";
        }

        public override int ProblemNumber {
            get { return 3; }
        }
    }
}
