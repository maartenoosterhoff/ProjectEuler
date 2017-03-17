﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver012 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            var solution = TriangleNumberSequence()
                .FirstOrDefault(t => FactorsOf(t) >= 500);

            return solution.ToString();
        }

        private static IEnumerable<int> TriangleNumberSequence()
        {
            var current = 1;
            var number = 1;
            while (true)
            {
                yield return current;
                number++;
                current += number;
            }
        }

        private static int FactorsOf(int value)
        {
            var factors = new List<int>();

            var edge = (int)Math.Sqrt(value);
            for (var i = 1; i <= edge; i++)
            {
                if (value % i == 0)
                {
                    factors.Add(i);
                    factors.Add(value / i);
                }
            }
            return factors.Distinct().Count();
        }

        protected override string GetProblemDescription()
        {
            return @"The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:

1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

Let us list the factors of the first seven triangle numbers:

 1: 1
 3: 1,3
 6: 1,2,3,6
10: 1,2,5,10
15: 1,3,5,15
21: 1,3,7,21
28: 1,2,4,7,14,28
We can see that 28 is the first triangle number to have over five divisors.

What is the value of the first triangle number to have over five hundred divisors?";
        }

        public override int ProblemNumber => 12;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}
