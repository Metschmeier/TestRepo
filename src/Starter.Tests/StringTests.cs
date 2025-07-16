using Xunit;

namespace Starter.Tests;

public class StringTests
{
    [Fact]
    public void Substring_ReturnsExpectedPart()
    {
        // Arrange
        string input = "Hallo .NET";

        // Act
        string result = input.Substring(6, 4);

        // Assert
        Assert.Equal(".NET", result);
    }

    [Fact]
    public void Contains_WordInText_ReturnsTrue()
    {
        string input = "Willkommen in der .NET Welt";

        Assert.Contains(".NET", input);
    }

    [Fact]
    public void ToUpper_ConvertsAllToUppercase()
    {
        string input = "abc";

        Assert.Equal("ABC", input.ToUpper());
    }
}