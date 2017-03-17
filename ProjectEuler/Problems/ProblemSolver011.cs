using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver011 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            LoadData();
            var solution = "Coordinaties: " + string.Join(", ", _maxCoor.Select(c => $"({c.X}, {c.Y})").ToArray()) + Environment.NewLine;
            solution += $"Product of values: {_max}";
            return solution;
        }

        int[,] _data;
        private int _max;
        private readonly List<Coordinate> _maxCoor = new List<Coordinate>();

        private void LoadData()
        {
            var data = new string[20];
            data[0] = "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08";
            data[1] = "49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00";
            data[2] = "81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65";
            data[3] = "52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91";
            data[4] = "22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80";
            data[5] = "24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50";
            data[6] = "32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70";
            data[7] = "67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21";
            data[8] = "24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72";
            data[9] = "21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95";
            data[10] = "78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92";
            data[11] = "16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57";
            data[12] = "86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58";
            data[13] = "19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40";
            data[14] = "04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66";
            data[15] = "88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69";
            data[16] = "04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36";
            data[17] = "20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16";
            data[18] = "20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54";
            data[19] = "01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";
            _data = new int[20, 20];
            for (var i = 0; i < 20; i++)
            {
                var sd = data[i].Split(' ');
                if (sd.Length == 20)
                {
                    for (var j = 0; j < 20; j++)
                    {
                        _data[i, j] = int.Parse(sd[j]);
                    }
                }
                else
                {
                    throw new Exception();
                }
            }

            var coordinates = new Stack<Coordinate>();
            const int length = 20;
            for (var x = 0; x < length; x++)
            {
                for (var y = 0; y < length; y++)
                {
                    var firstCoordinate = new Coordinate(x, y);
                    coordinates.Push(firstCoordinate);
                    Fill(firstCoordinate, coordinates, 1, 0);
                    Fill(firstCoordinate, coordinates, 0, 1);
                    Fill(firstCoordinate, coordinates, 1, 1);
                    Fill(firstCoordinate, coordinates, -1, 1);
                    coordinates.Pop();
                }
            }
            Console.WriteLine(_max);
            Console.WriteLine(string.Join(", ", _maxCoor.Select(c => $"({c.X}, {c.Y})").ToArray()));
            Console.WriteLine(string.Join(" + ", _maxCoor.Select(c => _data[c.X, c.Y].ToString()).ToArray()));
        }

        private void Fill(Coordinate lastCoordinate, Stack<Coordinate> coordinates, int deltaRight, int deltaDown)
        {
            if (coordinates.Count == 4)
            {
                CheckMax(coordinates);
            }
            else
            {
                var x = lastCoordinate.X;
                var y = lastCoordinate.Y;
                var newC = new Coordinate(x + deltaRight, y + deltaDown);
                if (newC.IsValid)
                {// && !coordinates.Contains(newC)) {
                    coordinates.Push(newC);
                    Fill(newC, coordinates, deltaRight, deltaDown);
                    coordinates.Pop();
                }
            }
        }



        private void CheckMax(Stack<Coordinate> coordinates)
        {
            var max = 1;
            var values = coordinates.Select(c => _data[c.X, c.Y]);
            values.ToList().ForEach(i => max *= i);
            if (max > _max)
            {
                _max = max;
                _maxCoor.Clear();
                _maxCoor.AddRange(coordinates.Reverse());
            }
        }

        private class Coordinate : IComparable
        {
            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; }
            public int Y { get; }


            public int CompareTo(object obj)
            {
                if (!(obj is Coordinate))
                    return -1;
                var c = (Coordinate)obj;
                var compareTo = X.CompareTo(c.X);
                if (compareTo == 0)
                    compareTo = Y.CompareTo(c.Y);
                return compareTo;
            }
            public override int GetHashCode()
            {
                return X.GetHashCode() * Y.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return CompareTo(obj) == 0;
            }

            public bool IsValid => X >= 0 && Y >= 0 && X <= 19 && Y <= 19;
        }

        protected override string GetProblemDescription()
        {
            return @"In the 20x20 grid below, four numbers along a diagonal line have been marked in red.

08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48
The product of these numbers is 26 x 63 x 78 x 14 = 1788696.

What is the greatest product of four adjacent numbers in any direction (up, down, left, right, or diagonally) in the 20x20 grid?";
        }

        public override int ProblemNumber => 11;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}
