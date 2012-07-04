using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems {
    class ProblemSolver030 : ProblemSolverBase {
        protected override string GetSolution() {
            int number = 2;
            int sum = 0;
            while (true) {
                var calculcatedNumber = number.ToString().ToArray().Select(c => int.Parse(c.ToString())).Select(n => n * n * n * n * n).Sum();
                if (number == calculcatedNumber) {
                    sum += number;
                    Console.WriteLine(number);
                }

                number++;
                if (number >= 1000000)
                    break;
            }
            return sum.ToString();
        }

        protected override string GetProblemDescription() {
            return @"Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

1634 = 1^4 + 6^4 + 3^4 + 4^4
8208 = 8^4 + 2^4 + 0^4 + 8^4
9474 = 9^4 + 4^4 + 7^4 + 4^4
As 1 = 1^4 is not a sum it is not included.

The sum of these numbers is 1634 + 8208 + 9474 = 19316.

Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.";
        }

        public override int ProblemNumber {
            get { return 30; }
        }
    }
}
