using System;
using Canvas.Common;
using Canvas.Components;
using Canvas.Exceptions;
using Canvas.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanvasTests.ComponentTests
{
    /// <summary>
    /// Summary description for MyCanvasTests
    /// </summary>
    [TestClass]
    public class MyCanvasTests
    {
        private IParser _parser;
        private readonly IPrinter _printer ;
        public MyCanvasTests()
        {
            _printer = new Printer();

        }

        [TestMethod, TestCategory("Intergration")]
        public void CanvasShouldBeCreatedWithCanvasCommand()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);
            
            //Act
            var command = _parser.ParseCommand("c 20 4");
            command.Execute();
            var board = canvas.GetBoard();

            //Assert
            board.GetLength(0).Should().Be(20);
            board.GetLength(1).Should().Be(4);
        }

        [TestMethod, TestCategory("Intergration")]
        public void CanvasShouldDrawLineWithLineCommand()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            //Act
            var canvascommand = _parser.ParseCommand("c 20 4");
            canvascommand.Execute();

            var linecommand = _parser.ParseCommand("l 12 1 14 1");
            linecommand.Execute();

            var board = canvas.GetBoard();
            for (var i = 11; i < 14; i++)
            {
                board[i, 0].Should().Be('x');
            }
        }

        [TestMethod, TestCategory("Intergration")]
        public void ShouldThrowOutOfRangeExceptionOnDrawLine()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            //Act
            var canvascommand = _parser.ParseCommand("c 20 4");
            canvascommand.Execute();

            var linecommand = _parser.ParseCommand("l 25 1 14 1");

            Action act = () => linecommand.Execute();
            act.Should().Throw<OutOfRangeException>();
        }

        [TestMethod, TestCategory("Intergration")]
        public void ShouldThrowErrorCommandExceptionWhenEncouterNotSupportedLine()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            //Act
            var canvascommand = _parser.ParseCommand("c 20 4");
            canvascommand.Execute();

            var linecommand = _parser.ParseCommand("l 14 1 18 3");

            Action act = () => linecommand.Execute();
            act.Should().Throw<ErrorCommandException>();
        }

        [TestMethod, TestCategory("Intergration")]
        public void ShouldThrowErrorCommandExceptionOnDrawLineWhenCanvasIsNotReady()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            var linecommand = _parser.ParseCommand("l 12 1 14 1");
            Action act = () => linecommand.Execute();

            act.Should().Throw<ErrorCommandException>();
        }

        [TestMethod, TestCategory("Intergration")]
        public void CanvasShouldDrawRectangle()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            //Act
            var canvascommand = _parser.ParseCommand("c 20 4");
            canvascommand.Execute();

            var rectangleCommand = _parser.ParseCommand("r 14 1 18 3");
            rectangleCommand.Execute();

            var board = canvas.GetBoard();
            for (var i = 13 ; i < 18; i++)
            {
                board[i, 0].Should().Be('x');
                board[i, 2].Should().Be('x');
            }

            for (var i = 0; i < 2; i++)
            {
                board[13, i].Should().Be('x');
                board[17, i].Should().Be('x');
            }
        }

        [TestMethod, TestCategory("Intergration")]
        public void ShouldThrowOutOfRangeExceptionOnDrawRectangle()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            //Act
            var canvascommand = _parser.ParseCommand("c 20 4");
            canvascommand.Execute();

            var rectangleCommand = _parser.ParseCommand("r 21 1 18 3");
            Action act = () => rectangleCommand.Execute();

            act.Should().Throw<OutOfRangeException>();
        }

        [TestMethod, TestCategory("Intergration")]
        public void ShouldThrowErrorCommandExceptionOnWhenEncouterNotSupportedRectangle()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            //Act
            var canvascommand = _parser.ParseCommand("c 20 4");
            canvascommand.Execute();

            var rectangleCommand = _parser.ParseCommand("r 19 1 18 3");
            Action act = () => rectangleCommand.Execute();

            act.Should().Throw<ErrorCommandException>();
        }

        [TestMethod, TestCategory("Intergration")]
        public void ShouldThrowErrorCommandExceptionOnDrawRectangleWhenCanvasIsNotReady()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            var command = _parser.ParseCommand("r 14 1 18 3");
            Action act = () => command.Execute();

            act.Should().Throw<ErrorCommandException>();
        }

        [TestMethod, TestCategory("Intergration")]
        public void ShouldFillBoardWithDesiredColor()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            //Act
            var canvascommand = _parser.ParseCommand("c 20 4");
            canvascommand.Execute();

            var fillcolorCommand = _parser.ParseCommand("b 2 2 c");
            fillcolorCommand.Execute();

            var board = canvas.GetBoard();

            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j].Should().Be('c');
                }
            }
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldFillBoradColorWithConnectArea()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            //Act
            var canvascommand = _parser.ParseCommand("c 20 4");
            canvascommand.Execute();

            var linecommand = _parser.ParseCommand("l 3 1 3 4");
            linecommand.Execute();

            var fillcolorCommand = _parser.ParseCommand("b 3 3 c");
            fillcolorCommand.Execute();

            var board = canvas.GetBoard();

            for (var i = 3; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j].Should().Be('c');
                }
            }
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldThrowErrorCommandExceptionOnFillColorWhenCanvasIsNotReady()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            var fillcolorCommand = _parser.ParseCommand("b 2 2 c");
            Action act = () => fillcolorCommand.Execute();

            act.Should().Throw<ErrorCommandException>();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldThrowErrorCommandExceptionOnFillColorWhenFillPointIsOutOfRange()
        {
            ICanvas canvas = new MyCanvas(_printer);
            _parser = new InputParser(canvas);

            //Act
            var canvascommand = _parser.ParseCommand("c 20 4");
            canvascommand.Execute();

            var fillcolorCommand = _parser.ParseCommand("b 21 2 c");
            Action act = () => fillcolorCommand.Execute();

            act.Should().Throw<OutOfRangeException>();
        }

    }
}
