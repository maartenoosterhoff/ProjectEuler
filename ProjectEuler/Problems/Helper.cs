using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    internal static class Helper
    {
        #region Fibonacci

        public static IEnumerable<int> GetFibonacci(int termMax = 0, int valueMax = 0)
        {
            var p1 = 1;
            var p2 = 2;
            var termCounter = 2;

            yield return p1;
            yield return p2;

            while (true)
            {
                termCounter++;
                var p3 = p1 + p2;
                var currentValue = p3;
                if ((termCounter > termMax && termMax > 0) ||
                    (currentValue > valueMax && valueMax > 0))
                    break;
                yield return p3;
                p1 = p2;
                p2 = p3;
            }
        }

        #endregion
        #region BitList

        private class BitList
        {
            private static readonly byte[] SmallPowerOf2 = { 1, 2, 4, 8, 16, 32, 64, 128 };

            private readonly byte[] _bitList;

            public BitList(long max, byte defaultValue)
            {
                var bitListLength = GetByteNumber(max) + 1;
                _bitList = new byte[bitListLength];
                for (long i = 0; i < bitListLength; i++)
                {
                    _bitList[i] = defaultValue;
                }
            }
            public bool GetBit(long position)
            {
                var bitValue = SmallPowerOf2[GetBitNumber(position)];
                return (_bitList[GetByteNumber(position)] & bitValue) == bitValue;
            }
            public void SetBit(long position, bool value)
            {
                var bitValue = SmallPowerOf2[GetBitNumber(position)];
                var byteValue = GetByteNumber(position);
                if (value)
                {
                    if ((_bitList[byteValue] & bitValue) != bitValue)
                    {
                        _bitList[byteValue] += bitValue;
                    }
                }
                else
                {
                    if ((_bitList[byteValue] & bitValue) == bitValue)
                    {
                        _bitList[byteValue] -= bitValue;
                    }
                }
            }
            private static long GetByteNumber(long position)
            {
                return position / 8;
            }
            private static long GetBitNumber(long position)
            {
                long remainder;
                System.Math.DivRem(position, 8, out remainder);
                return remainder;
            }
        }

        #endregion
        #region Primes

        public static IEnumerable<long> GetPrimesWithErastosthenesUpTill(long max)
        {
            var topNumber = max;
            var numbers = new BitList(topNumber, 255);

            for (var i = 2; i < topNumber; i++)
                if (numbers.GetBit(i))
                {
                    for (var j = i * 2; j < topNumber; j += i)
                        numbers.SetBit(j, false);
                }

            for (var i = 1; i < topNumber; i++)
                if (numbers.GetBit(i))
                {
                    yield return i;
                }
        }

        #endregion
        #region Infinite range

        public static IEnumerable<int> GetInfiniteRange(int start = 1)
        {
            while (true)
            {
                yield return start;
                start++;
            }
        }

        #endregion
        #region HCF - Highest common factor / GCD

        public static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        #endregion
    }
}
