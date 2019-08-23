using Canvas.Commands;
using Canvas.Common;
using Canvas.Components;
using Canvas.Exceptions;
using Canvas.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanvasTests.CommonTests
{
    /// <summary>
    /// Summary description for InputParserTests
    /// </summary>
    [TestClass]
    public class InputParserTests
    {
        private readonly IParser _parser;

        public InputParserTests()
        {
            IPrinter printer = new Printer();
            ICanvas canvas = new MyCanvas(printer);
            _parser = new InputParser(canvas);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnCanvasCommand()
        {
            var command = _parser.ParseCommand("c 20 4");
            command.Should().BeOfType<CanvasCommand>();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnLineCommand()
        {
            var command = _parser.ParseCommand("l 1 2 1 3");
            command.Should().BeOfType<LineCommand>();
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnRectangleCommand()
        {
            var command = _parser.ParseCommand("r 14 1 18 3");
            command.Should().BeOfType<RectangleCommand>();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnFillColorCommand()
        {
            var command = _parser.ParseCommand("b 2 2 o");
            command.Should().BeOfType<FillColorCommand>();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldThrowErrorCommandExceptionWithIncorrectCommand()
        {
            Action act = () => { _parser.ParseCommand("asdasdlkasjl");};

            act.Should().Throw<ErrorCommandException>();
        }
    }
}
