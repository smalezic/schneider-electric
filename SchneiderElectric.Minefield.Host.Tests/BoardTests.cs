using Moq;
using Xunit;
using SchneiderElectric.Minefield.Host.Presentation;
using SchneiderElectric.Minefield.Host.Field;
using SchneiderElectric.Minefield.Host.Entities;
using System.Reflection;

namespace SchneiderElectric.Minefield.Host.Tests;

public class BoardTests
{
    [Fact]
    public void CreateBoard_Success()
    {
        // Arrange
        var renderer = new Mock<IBoardRenderer>();

        // Act
        var board = Board.Create(renderer.Object, 8);

        // Assert
        Assert.NotNull(board);
    }

    [Fact]
    public void CreateBoard_IBoardRendererIsNull_Fail()
    {
        // Arrange

        // Act
        var func = () => Board.Create(null!, 8);

        // Assert
        Assert.Throws<ArgumentNullException>(func);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(3)]
    [InlineData(10)]
    public void CreateBoard_TooSmallOrTooBig_Fail(int size)
    {
        // Arrange
        var renderer = new Mock<IBoardRenderer>();

        // Act
        var func = () => Board.Create(renderer.Object, size);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(func);
    }

    [Fact]
    public void DisplayBoard_Success()
    {
        // Arrange
        var renderer = new Mock<IBoardRenderer>(MockBehavior.Strict);
        renderer.Setup(it => it.DisplayBoard(It.IsAny<Player>(), 8));
        var board = Board.Create(renderer.Object, 8);

        // Act
        board.Display();

        // Assert
        Mock.Verify();
    }

    [Fact]
    public void PutMinesInLandfield_CreatesUniqueMines()
    {
        // Arrange
        var renderer = new Mock<IBoardRenderer>();
        var board = Board.Create(renderer.Object, 8);

        // Act
        var fieldInfo = board
            .GetType()
            .GetField("<Mines>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
        var mines = (List<Mine>)fieldInfo!.GetValue(board)!;

        // Assert
        Assert.Equal(10, mines.Count);
        Assert.Equal(10, mines.Distinct().Count());
    }

    [Fact]
    public void DetectCollision_WhenPlayerOnMine_ReturnsTrue()
    {
        // Arrange
        var renderer = new Mock<IBoardRenderer>();
        var board = Board.Create(renderer.Object, 8);

        var mineField = board.GetType().GetField("<Mines>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
        var mines = (List<Mine>)mineField!.GetValue(board)!;
        mines.Clear();
        mines.Add(new Mine(0, 0)); // Place a mine at the player's position

        var detectCollisionMethod = board.GetType().GetMethod("DetectCollision", BindingFlags.NonPublic | BindingFlags.Instance);

        // Act
        var result = (bool)detectCollisionMethod!.Invoke(board, null)!;

        // Assert
        Assert.True(result);
    }
}