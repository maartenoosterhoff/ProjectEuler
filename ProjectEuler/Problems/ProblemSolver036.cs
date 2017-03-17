using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver036 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            var numbers = Helper.GetInfiniteRange()
                .TakeWhile(x => x < 1000000)
                .Where(x => IsPalindrome(x.ToString()))
                .Where(x => IsPalindrome(Convert.ToString(x, 2)))
                .ToArray();

            var sum = numbers.Sum();

            return sum.ToString();
        }

        private static bool IsPalindrome(string value)
        {
            var reverse = new string(value.Reverse().ToArray());
            return string.Compare(value, reverse, StringComparison.OrdinalIgnoreCase) == 0;
        }

        protected override string GetProblemDescription()
        {
            return @"The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.

Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

(Please note that the palindromic number, in either base, may not include leading zeros.)";
        }

        public override int ProblemNumber => 36;
    }
}
