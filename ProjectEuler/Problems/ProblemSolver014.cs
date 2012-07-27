using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems {
    class ProblemSolver014 : ProblemSolverBase {
        protected override string GetSolution() {
            var solution = Enumerable.Range(1, 1000000).Select(x => GetCollatz(x)).OrderByDescending(x => x).FirstOrDefault();

            return _collatz.FirstOrDefault(x => x == solution).ToString();
        }

        private int[] _collatz = new int[1000000];

        private int GetCollatz(int start) {
            if (start > _collatz.Length - 1) {
                // we have to increase the array
                int[] newCollatz = new int[_collatz.Length * 2];
                Array.Copy(_collatz, newCollatz, _collatz.Length);
                _collatz = newCollatz;
            }

            if (_collatz[start] == 0) {
                if (start == 1)
                    _collatz[start] = 1;
                else
                    if (start % 2 == 0)
                        _collatz[start] = GetCollatz(start / 2) + 1;
                    else
                        _collatz[start] = GetCollatz(3 * start + 1) + 1;
            }
            return _collatz[start];
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
    }
}
