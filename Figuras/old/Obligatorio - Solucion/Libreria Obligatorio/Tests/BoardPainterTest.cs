using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Drawing;
using System.Drawing;

namespace Drawing.Tests
{
    [TestFixture]
    public class BoardPainterTest
    {

        private BoardModel board;
        private BoardPainter painter;
        private MockShape shape;

        [SetUp]
        public void SetUp()
        {
            board = new BoardModel(100, 100);
            painter = new BoardPainter(board);
            shape = new MockShape();
        }

        [Test]
        public void TestPaintNoPoints()
        {
            shape.Points = new IPoint[] {};
            painter.Paint(shape, Color.Blue);
            CheckPainted(board);            
        }

        [Test]
        public void TestPaintOnePoint()
        {
            shape.Points = new IPoint[] { new MockPoint(5,5)};
            painter.Paint(shape, Color.Blue);            
            CheckPainted(board, new MockPoint(5,5));            
        }

        [Test]
        public void TestPaintOutOfBoard()
        {
            shape.Points = new IPoint[] { 
                new MockPoint(board.MaxX + 1, board.MaxY + 1) 
            };
            painter.Paint(shape, Color.Blue);
            CheckPainted(board);
        }

        [Test]
        public void TestPaintLine()
        {
            shape.Points = new IPoint[] { 
                new MockPoint(1, 1) ,
                new MockPoint(1, 4)
            };
            painter.Paint(shape, Color.Blue);
            CheckPainted(board, 
                new MockPoint(1,1), 
                new MockPoint(1,2), 
                new MockPoint(1,3),
                new MockPoint(1,4)
                );
        }

        [Test]
        public void TestPaintTwoLine()
        {
            shape.Points = new IPoint[] { 
                new MockPoint(1, 1),
                new MockPoint(1, 4),
                new MockPoint(3, 4)
            };
            painter.Paint(shape, Color.Blue);
            CheckPainted(board,
                new MockPoint(1, 1),
                new MockPoint(1, 2),
                new MockPoint(1, 3),
                new MockPoint(1, 4),
                new MockPoint(2, 4),
                new MockPoint(3, 4),
                new MockPoint(2, 2),
                new MockPoint(2, 3)
                );
        }

        private static void CheckPainted(IBoard aBoard, params IPoint[] mustBePainted)
        {
            for (int x = 0; x < aBoard.MaxX; x++)            
            {
                for (int y = 0; y < aBoard.MaxY; y++)
                {
                    if (IsInPoints(x, y, mustBePainted)) 
                    {
                        Assert.IsTrue(aBoard.IsPainted(x, y), "Point ({0},{1}) must not be painted!", x, y);
                    } 
                    else
                    {
                        Assert.IsFalse(aBoard.IsPainted(x, y), "Point ({0},{1}) must be painted!", x, y);
                    }
                    
                }
            }
        }
        
        private static Boolean IsInPoints(Int32 x, Int32 y, params IPoint[] points)
        {
            foreach (IPoint point in points)
            {
                if (point.X == x && point.Y == y)
                {
                    return true;
                }
            }
            return false;
        }
    }    
}
