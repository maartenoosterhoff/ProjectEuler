using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems {
    class ProblemSolver071 : ProblemSolverBase {
        protected override string GetSolution() {
            const double v = 3f / 7f;
            int maxD = 1000000;
            List<Tuple<int, int>> rpf = new List<Tuple<int, int>>();
            for (int d = 2; d < maxD; d++) {
                for (int n = 1; n < d; n++) {
                    if (Helper.GCD(d, n) == 1) {
                        rpf.Add(new Tuple<int, int>(n, d));
                        if (rpf.Count > 1000000) {
                            // Shrink list
                            var data = rpf.Select(x => new { Value = (double)x.Item1 / (double)x.Item2, Data = x }).OrderBy(x => x.Value).ToList();
                            var dataBefore = data.Where(x => x.Value <= v).ToList();
                            if (dataBefore.Count > 5) {
                                dataBefore = dataBefore.Skip(dataBefore.Count - 5).Take(5).ToList();
                            }
                            var dataAfter = data.Where(x => x.Value >= v).ToList();
                            if (dataAfter.Count > 5) {
                                dataAfter = dataAfter.Take(5).ToList();
                            }
                            data = dataBefore.Concat(dataAfter).Distinct().ToList();
                            System.Diagnostics.Debug.Print("Shrunk! D = " + d.ToString());
                            rpf = data.Select(x => x.Data).ToList();
                        }
                    }
                }
            }

            var sorted = rpf.Select(x => new { Value = (double)x.Item1 / (double)x.Item2, Data = x }).OrderBy(x => x.Value).ToList();
            var solution = sorted.Where(x => x.Value < v).Last();

            return solution.ToString();
        }


        protected override string GetProblemDescription() {
            return @"Consider the fraction, n/d, where n and d are positive integers. If n < d and HCF(n,d)=1, it is called a reduced proper fraction.

If we list the set of reduced proper fractions for d <= 8 in ascending order of size, we get:

1/8, 1/7, 1/6, 1/5, 1/4, 2/7, 1/3, 3/8, 2/5, 3/7, 1/2, 4/7, 3/5, 5/8, 2/3, 5/7, 3/4, 4/5, 5/6, 6/7, 7/8

It can be seen that 2/5 is the fraction immediately to the left of 3/7.

By listing the set of reduced proper fractions for d  1,000,000 in ascending order of size, find the numerator of the fraction immediately to the left of 3/7.";
        }

        public override int ProblemNumber {
            get { return 71; }
        }
    }
}
