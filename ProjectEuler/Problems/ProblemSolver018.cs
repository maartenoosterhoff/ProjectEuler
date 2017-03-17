using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver018 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            var source = new[]
            {
                //"3",
                //"7 4",
                //"2 4 6",
                //"8 5 9 3"
"75",
"95 64",
"17 47 82",
"18 35 87 10",
"20 04 82 47 65",
"19 01 23 75 03 34",
"88 02 77 73 07 63 67",
"99 65 04 28 06 16 70 92",
"41 41 26 56 83 40 80 70 33",
"41 48 72 33 47 32 37 16 94 29",
"53 71 44 65 25 43 91 52 97 51 14",
"70 11 33 28 77 73 17 78 39 68 17 57",
"91 71 52 38 17 14 91 43 58 50 27 29 48",
"63 66 04 68 89 53 67 30 73 16 69 87 40 31",
"04 62 98 27 23 09 70 98 73 93 38 53 60 04 23"
            };
            var data = source
                .Select(x => x.Split(new[] { " " }, StringSplitOptions.None).Select(int.Parse).ToArray())
                .ToList();

            while (data.Count > 1)
            {
                var idx = data.Count - 2;
                var idx2max = data[idx].Length;
                for (var idx2 = 0; idx2 < idx2max; idx2++)
                {
                    var r2v1 = data[idx + 1][idx2];
                    var r2v2 = data[idx + 1][idx2 + 1];
                    if (r2v1 > r2v2)
                    {
                        data[idx][idx2] += r2v1;
                    }
                    else
                    {
                        data[idx][idx2] += r2v2;
                    }
                }
                data.RemoveAt(idx + 1);
            }



            return data[0][0].ToString();
        }

        protected override string GetProblemDescription()
        {
            return @"By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.
   3
  7 4
 2 4 6
8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom of the triangle below:

              75
             95 64
            17 47 82
           18 35 87 10
          20 04 82 47 65
         19 01 23 75 03 34
        88 02 77 73 07 63 67
       99 65 04 28 06 16 70 92
      41 41 26 56 83 40 80 70 33
     41 48 72 33 47 32 37 16 94 29
    53 71 44 65 25 43 91 52 97 51 14
   70 11 33 28 77 73 17 78 39 68 17 57
  91 71 52 38 17 14 91 43 58 50 27 29 48
 63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23
";
        }

        public override int ProblemNumber => 18;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}
