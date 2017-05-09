using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver024 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            var permutations = new List<string>();
            GeneratePermutations(permutations, new List<int>(), 10);
            return permutations.Skip(999999).First();
        }

        private static void GeneratePermutations(List<string> target, List<int> currentPermutation, int requiredDepth)
        {
            if (currentPermutation.Count == requiredDepth)
            {
                target.Add(string.Join("", currentPermutation));
            }
            else
            {
                for (int i = 0; i < requiredDepth; i++)
                {
                    if (!currentPermutation.Contains(i))
                    {
                        currentPermutation.Add(i);
                        GeneratePermutations(target, currentPermutation, requiredDepth);
                        currentPermutation.Remove(i);
                    }
                }
            }
        }

        protected override string GetProblemDescription()
        {
            return @"A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

012   021   102   120   201   210

What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
";
        }

        public override int ProblemNumber => 24;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}
