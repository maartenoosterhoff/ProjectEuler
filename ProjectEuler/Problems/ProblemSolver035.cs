using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems {
    class ProblemSolver035 : ProblemSolverBase {
        private static readonly object _lock = new object();
        protected override string GetSolution() {
            var primes = Helper.GetPrimesWithErastosthenesUpTill(1000000).Skip(1).ToList();
            var count = 0;
            Parallel.For(0, primes.Count, p => {
                var prime = primes[p];
                if (Rotate(prime).All(i => primes.Contains(i))) {
                    lock (_lock) {
                        count++;
                    }
                }
            });
            //foreach (var prime in primes) {
            //    if (Rotate(prime).All(i => primes.Contains(i))) {
            //        count++;
            //    }
            //}

            return count.ToString();
        }

        private static IEnumerable<long> Rotate(long value) {
            yield return value;

            var v = value.ToString();
            var l = v.Length - 1;
            for (int i = 0; i < l; i++) {
                v = v.Substring(1) + v.Substring(0, 1);
                yield return int.Parse(v);
            }
        }

        protected override string GetProblemDescription() {
            return @"The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.

There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.

How many circular primes are there below one million?";
        }

        public override int ProblemNumber {
            get { return 35; }
        }
    }
}
