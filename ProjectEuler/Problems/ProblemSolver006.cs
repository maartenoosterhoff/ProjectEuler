using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems {
    class ProblemSolver006 : ProblemSolverBase {
        protected override string GetSolution() {
            var sumOfSquares = GetSquareSequence().Take(100).Sum();
            var squareOfSums = Math.Pow(Enumerable.Range(1, 100).Sum(), 2);

            return Math.Abs((sumOfSquares - squareOfSums)).ToString();
        }

        private static IEnumerable<int> GetSquareSequence() {
            int position = 1;
            while (true) {
                yield return position * position;
                position++;
            }
        }

        protected override string GetProblemDescription() {
            return @"The sum of the squares of the first ten natural numbers is,

1^2 + 2^2 + ... + 10^2 = 385
The square of the sum of the first ten natural numbers is,

(1 + 2 + ... + 10)^2 = 55^2 = 3025
Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640.

Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.";
        }

        public override int ProblemNumber {
            get { return 6; }
        }

        public override SolvedState SolvedState {
            get {
                return SolvedState.Solved;
            }
        }
    }
}
