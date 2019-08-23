using Canvas.Interfaces;
using Canvas.Exceptions;
using System;
using System.Collections.Generic;

namespace Canvas.Components
{
    public class MyCanvas : ICanvas
    {
        private readonly IPrinter _printer;
        private const char DefaultCharacter = 'x';
        private char[,] _board;

        public MyCanvas(IPrinter printer)
        {
            _printer = printer;
        }

        public void Create(int width, int height)
        {
            _board = new char[width, height];
            InitilizeBoard(width, height);
            Print();
        }

        public void DrawLine(Point pointA, Point pointB)
        {
            if (!IsCanvasReady()) throw new ErrorCommandException("The canvas is not ready! Please create canvas first!");
            if (!IsPointValid(pointA) || !IsPointValid(pointB)) throw new OutOfRangeException("Invalid point coordinate!");
            if (pointA.X != pointB.X && pointA.Y != pointB.Y) throw new ErrorCommandException("Not supported line!");

            if (pointA.X == pointB.X)
            {
                var top = Math.Min(pointA.Y - 1, pointB.Y - 1);
                var bottom = Math.Max(pointA.Y - 1, pointB.Y - 1);

                for (var y = top; y <= bottom; y++)
                {
                    _board[pointA.X-1, y] = DefaultCharacter;
                }
            }
            else
            {
                var left = Math.Min(pointA.X - 1, pointB.X - 1);
                var right = Math.Max(pointA.X - 1, pointB.X - 1);

                for (var x = left; x <= right; x++)
                {
                    _board[x, pointA.Y-1] = DefaultCharacter;
                }
            }

            Print();
        }

        public void DrawRectangle(Point pointA, Point pointB)
        {
            if (!IsCanvasReady()) throw new ErrorCommandException("The canvas is not ready! Please create canvas first");
            if (!IsPointValid(pointA) || !IsPointValid(pointB)) throw new OutOfRangeException("Invalid point coordinate!");

            if (pointA.X >= pointB.X || pointA.Y >= pointB.Y) throw new ErrorCommandException("First point should be upper left corner!");

            for (var x = pointA.X - 1; x <= pointB.X - 1; x++)
            {
                _board[x, pointA.Y - 1] = DefaultCharacter;
                _board[x, pointB.Y - 1] = DefaultCharacter;
            }

            for (var y = pointA.Y - 1; y <= pointB.Y - 1; y++)
            {
                _board[pointA.X - 1, y] = DefaultCharacter;
                _board[pointB.X - 1, y] = DefaultCharacter;
            }

            Print();
        }

        public void FillColor(Point inputpoint, char character)
        {
            var point = new Point{X = inputpoint.X -1, Y = inputpoint.Y -1 };
            if (!IsCanvasReady()) throw new ErrorCommandException("The canvas is not ready! Please create canvas first");
            if (!IsFillColorPointValid(point)) throw new OutOfRangeException("Invalid point coordinate!");

            //BFS
            var queue = new Queue<Point>();
            queue.Enqueue(point);

            while (queue.Count != 0)
            {
                var center = queue.Dequeue();
                _board[center.X, center.Y] = character;

                //move left
                if (center.X - 1 >= 0 && _board[center.X - 1, center.Y] != character && _board[center.X - 1, center.Y] != DefaultCharacter)
                {
                    queue.Enqueue(new Point { X = center.X - 1, Y = center.Y });
                    _board[center.X - 1, center.Y] = character;
                }

                //move right
                if (center.X + 1 < GetWidth() && _board[center.X + 1, center.Y] != character && _board[center.X + 1, center.Y] != DefaultCharacter)
                {
                    queue.Enqueue(new Point { X = center.X + 1, Y = center.Y });
                    _board[center.X + 1, center.Y] = character;
                }

                //move up
                if (center.Y - 1 >= 0 && _board[center.X, center.Y - 1] != character && _board[center.X, center.Y - 1] != DefaultCharacter)
                {
                    queue.Enqueue(new Point { X = center.X, Y = center.Y - 1 });
                    _board[center.X, center.Y - 1] = character;
                }

                //move down
                if (center.Y + 1 < GetHeight() && _board[center.X, center.Y + 1] != character && _board[center.X, center.Y + 1] != DefaultCharacter)
                {
                    queue.Enqueue(new Point { X = center.X, Y = center.Y + 1 });
                    _board[center.X, center.Y + 1] = character;
                }
            }

            Print();
        }

        public char[,] GetBoard()
        {
            return _board;
        }

        private void Print()
        {
            var width = _board.GetLength(0);
            var height = _board.GetLength(1);

            for (var i = 0; i < width + 2; i++)
            {
                _printer.Print('-');
            }
            _printer.ChangeLine();

            for (var y = 0; y < height; y++)
            {
                _printer.Print('|');
                for (var x = 0; x < width; x++)
                {
                    _printer.Print(_board[x, y]);
                }
                _printer.Print('|');
                _printer.ChangeLine();
            }

            for (var i = 0; i < width + 2; i++)
            {
                _printer.Print('-');
            }
            _printer.ChangeLine();
        }

        private void InitilizeBoard(int width, int height)
        {
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    _board[i, j] = ' ';
                }
            }
        }

        private bool IsCanvasReady()
        {
            return _board != null;
        }

        private bool IsPointValid(Point point)
        {
            return point.X >= 1 && point.X <= GetWidth() && point.Y >= 1 && point.Y <= GetHeight();
        }

        private bool IsFillColorPointValid(Point point)
        {
            return point.X >= 0 && point.X < GetWidth() && point.Y >= 0 && point.Y < GetHeight();
        }

        private int GetWidth()
        {
            return _board.GetLength(0);
        }

        private int GetHeight()
        {
            return _board.GetLength(1);
        }
    }
}
