using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProjectEuler.Problems {
    class ProblemSolver014 : ProblemSolverBase {
        protected override string GetSolution() {
            long valueWithMax = -1;
            long max = -1;
            for (long v = 1; v < 1000000; v++) {
                var value = v;
                var counter = 1;
                while (value != 1) {
                    if (value % 2 == 0) {
                        value = value / 2;
                    } else {
                        value = 3 * value + 1;
                    }
                    counter++;
                }
                if (counter > max) {
                    valueWithMax = v;
                    max = counter;
                }
            }
            return valueWithMax.ToString();
        }

        protected override string GetProblemDescription() {
            return @"The following iterative sequence is defined for the set of positive integers:

n -> n/2 (n is even)
n -> 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.";
        }

        public override int ProblemNumber {
            get { return 14; }
        }

        public override SolvedState SolvedState {
            get {
                return SolvedState.Solved;
            }
        }
    }
}
