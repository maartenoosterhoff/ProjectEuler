using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver017 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            var allNumbersUpToIncl1000InText = Enumerable.Range(1, 1000)
                .Select(x => GetTextualNumber(x))
                .ToArray();

            var combined = string.Join("", allNumbersUpToIncl1000InText);
            var letterCount = combined.Replace(" ", string.Empty).Count();
            return letterCount.ToString();
        }

        private readonly static Dictionary<int, string> _numbers = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
            { 30, "thirty" },
            { 40, "forty" },
            { 50, "fifty" },
            { 60, "sixty" },
            { 70, "seventy" },
            { 80, "eighty" },
            { 90, "ninety" },
        };

        private static string GetTextualNumber(int i)
        {
            if (_numbers.ContainsKey(i))
                return _numbers[i];

            var textual = string.Empty;
            if (i % 1000 == 0)
            {
                textual = $"{GetTextualNumber(i / 1000)} thousand";
            }
            else if (i % 100 == 0)
            {
                textual = $"{GetTextualNumber(i / 100)} hundred";
            }
            else if (i < 100)
            {
                textual = $"{GetTextualNumber(i - i % 10)} {GetTextualNumber(i % 10)}";
            }
            else
            {
                textual = $"{GetTextualNumber(i - i % 100)} and {GetTextualNumber(i % 100)}";
            }

            _numbers[i] = textual;

            return textual;
        }

        protected override string GetProblemDescription()
        {
            return @"If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?


NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of 'and' when writing out numbers is in compliance with British usage.";
        }

        public override int ProblemNumber => 17;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}
