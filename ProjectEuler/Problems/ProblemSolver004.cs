using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems {
    class ProblemSolver004 : ProblemSolverBase {
        protected override string GetSolution() {
            var solution = (from x in Enumerable.Range(100, 999 - 100)
                            from y in Enumerable.Range(x + 1, 999 - x)
                            let product = x * y
                            where product > 9
                            where IsPalindroom(product)
                            select new { x = x, y = y, product = product }).OrderByDescending(x => x.product).FirstOrDefault();

            if (solution == null)
                return "No solution found.";
            return string.Format("{0} x {1} = {2}", solution.x, solution.y, solution.product);
        }

        private static bool IsPalindroom(int value) {
            var stringValue = value.ToString();
            return stringValue == new string(stringValue.Reverse().ToArray());
        }

        protected override string GetProblemDescription() {
            return @"A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 x 99.

Find the largest palindrome made from the product of two 3-digit numbers.";
        }

        public override int ProblemNumber {
            get { return 4; }
        }

        public override SolvedState SolvedState {
            get {
                return SolvedState.Solved;
            }
        }
    }
}
