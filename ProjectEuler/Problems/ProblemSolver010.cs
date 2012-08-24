using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems {
    class ProblemSolver010 : ProblemSolverBase {
        protected override string GetSolution() {
            return Helper.GetPrimesWithErastosthenesUpTill(2000000) // Take primes up till 1000000, this is a guess
                .Skip(1) // Skip prime 1 which should not be included according to the question
                .Sum()
                .ToString();
        }

        protected override string GetProblemDescription() {
            return @"The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million.";
        }

        public override int ProblemNumber {
            get { return 10; }
        }

        public override SolvedState SolvedState {
            get {
                return SolvedState.Solved;
            }
        }
    }
}
