namespace SchneiderElectric.Minefield.Host.Tests;

using AutoFixture;
using SchneiderElectric.Minefield.Host.Entities;
using Xunit;

public class PlayerTests
{
    private Fixture _fixture = new();

    [Fact]
    public void InitPlayer_Success()
    {
        // Arrange
        var positionX = _fixture.Create<int>();
        var positionY = _fixture.Create<int>();

        // Act
        var player = new Player(positionX, positionY);

        // Assert
        Assert.Equal(positionX, player.PositionX);
        Assert.Equal(positionY, player.PositionY);
        Assert.Equal(3, player.LifeCounter);
    }

    [Fact]
    public void Die_ReduceNumberOfLives_Success()
    {
        // Arrange
        var positionX = _fixture.Create<int>();
        var positionY = _fixture.Create<int>();

        var player = new Player(positionX, positionY);

        // Act
        player.Die();

        // Assert
        Assert.Equal(2, player.LifeCounter);
    }

    [Fact]
    public void Move_Right_WithinBounds_IncrementsPositionX()
    {
        // Arrange
        var player = new Player(0, 0);
        int limit = 8;

        // Act
        player.Move(Direction.Right, limit);

        // Assert
        Assert.Equal(1, player.PositionX);
        Assert.Equal(0, player.PositionY);
        Assert.Equal(1, player.MoveCounter);
    }

    [Fact]
    public void Move_Left_AtLeftEdge_DoesNotChangePosition()
    {
        // Arrange
        var player = new Player(0, 0);
        int limit = 8;

        // Act
        player.Move(Direction.Left, limit);

        // Assert
        Assert.Equal(0, player.PositionX);
        Assert.Equal(0, player.PositionY);
        Assert.Equal(0, player.MoveCounter);
    }

    [Fact]
    public void Move_Up_AtTopEdge_DoesNotChangePosition()
    {
        // Arrange
        var player = new Player(0, 0);
        int limit = 8;

        // Act
        player.Move(Direction.Up, limit);

        // Assert
        Assert.Equal(0, player.PositionX);
        Assert.Equal(0, player.PositionY);
        Assert.Equal(0, player.MoveCounter);
    }

    [Fact]
    public void Move_Down_WithinBounds_IncrementsPositionY()
    {
        // Arrange
        var player = new Player(0, 0);
        int limit = 8;

        // Act
        player.Move(Direction.Down, limit);

        // Assert
        Assert.Equal(0, player.PositionX);
        Assert.Equal(1, player.PositionY);
        Assert.Equal(1, player.MoveCounter);
    }

    [Fact]
    public void Move_Down_AtBottomEdge_DoesNotChangePosition()
    {
        // Arrange
        var player = new Player(0, 7);
        int limit = 8;

        // Act
        player.Move(Direction.Down, limit);

        // Assert
        Assert.Equal(0, player.PositionX);
        Assert.Equal(7, player.PositionY);
        Assert.Equal(0, player.MoveCounter);
    }

    [Fact]
    public void Move_Right_AtRightEdge_DoesNotChangePosition()
    {
        // Arrange
        var player = new Player(7, 0);
        int limit = 8;

        // Act
        player.Move(Direction.Right, limit);

        // Assert
        Assert.Equal(7, player.PositionX);
        Assert.Equal(0, player.PositionY);
        Assert.Equal(0, player.MoveCounter);
    }

    [Fact]
    public void Move_ValidAndInvalidSequences_TracksMoveCounterAccurately()
    {
        // Arrange
        var player = new Player(0, 0);
        int limit = 8;

        // Act
        player.Move(Direction.Up, limit);       // Invalid
        player.Move(Direction.Left, limit);     // Invalid
        player.Move(Direction.Right, limit);    // Valid
        player.Move(Direction.Down, limit);     // Valid

        // Assert
        Assert.Equal(1, player.PositionX);
        Assert.Equal(1, player.PositionY);
        Assert.Equal(2, player.MoveCounter); // Only valid moves are counted
    }
}