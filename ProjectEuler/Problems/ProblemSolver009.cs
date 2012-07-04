using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems {
    class ProblemSolver009 : ProblemSolverBase {
        protected override string GetSolution() {
            for (int a = 1; a < 1000; a++) {
                for (int b = a + 1; b <= 1000; b++) {
                    double c2 = Math.Sqrt(a * a + b * b);
                    int c = (int)c2;
                    if (c == c2 && a < c && b < c && a + b + c == 1000) {
                        return (a * b * c).ToString();
                    }
                }
            }
            return "No solution found.";
        }

        protected override string GetProblemDescription() {
            return @"A Pythagorean triplet is a set of three natural numbers, a  b  c, for which,

a2 + b2 = c2
For example, 32 + 42 = 9 + 16 = 25 = 52.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.";
        }

        public override int ProblemNumber {
            get { return 9; }
        }
    }
}
