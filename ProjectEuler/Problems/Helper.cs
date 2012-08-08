using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems {
    static class Helper {
        #region Fibonacci

        public static IEnumerable<int> GetFibonacci(int termMax = 0, int valueMax = 0) {
            int p1 = 1;
            int p2 = 2;
            int termCounter = 2;
            int currentValue = 2;

            yield return p1;
            yield return p2;

            while (true) {
                termCounter++;
                int p3 = p1 + p2;
                currentValue = p3;
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

        class BitList {
            public static byte[] _smallPowerOf2 = { 1, 2, 4, 8, 16, 32, 64, 128 };

            private byte[] _bitList = null;
            private long _max = 0;
            public BitList(long max, byte defaultValue) {
                _max = max;
                long bitListLength = GetByteNumber(max) + 1;
                _bitList = new byte[bitListLength];
                for (long i = 0; i < bitListLength; i++) {
                    _bitList[i] = defaultValue;
                }
            }
            public bool GetBit(long position) {
                byte bitValue = _smallPowerOf2[GetBitNumber(position)];
                return (_bitList[GetByteNumber(position)] & bitValue) == bitValue;
            }
            public void SetBit(long position, bool value) {
                byte bitValue = _smallPowerOf2[GetBitNumber(position)];
                long byteValue = GetByteNumber(position);
                if (value) {
                    if ((_bitList[byteValue] & bitValue) != bitValue) {
                        _bitList[byteValue] += bitValue;
                    }
                } else {
                    if ((_bitList[byteValue] & bitValue) == bitValue) {
                        _bitList[byteValue] -= bitValue;
                    }
                }
            }
            private long GetByteNumber(long position) {
                return (long)(position / 8);
            }
            private long GetBitNumber(long position) {
                long remainder;
                System.Math.DivRem(position, 8, out remainder);
                return remainder;
            }
        }

        #endregion
        #region Primes

        public static IEnumerable<long> GetPrimesWithErastosthenesUpTill(long max) {
            long topNumber = max;
            BitList numbers = new BitList(topNumber, 255);

            for (int i = 2; i < topNumber; i++)
                if (numbers.GetBit(i)) {
                    for (int j = i * 2; j < topNumber; j += i)
                        numbers.SetBit(j, false);
                }

            for (int i = 1; i < topNumber; i++)
                if (numbers.GetBit(i)) {
                    yield return i;
                }
        }

        #endregion
        #region Infinite range

        public static IEnumerable<int> GetInfiniteRange(int start = 1) {
            while (true) {
                yield return start;
                start++;
            }
        }

        #endregion
        #region HCF - Highest common factor / GCD

        public static int GCD(int a, int b) {
            while (a != 0 && b != 0) {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            if (a == 0)
                return b;
            else
                return a;
        }

        #endregion
    }
}
