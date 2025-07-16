using System.Globalization;
using Xunit;

namespace Starter.Tests;

public class ParsingTests
{
    [Fact]
    public void IntTryParse_ValidNumber_ReturnsTrue()
    {
        string input = "123";
        bool success = int.TryParse(input, out int result);

        Assert.True(success);
        Assert.Equal(123, result);
    }

    [Fact]
    public void IntTryParse_InvalidNumber_ReturnsFalse()
    {
        string input = "abc";
        bool success = int.TryParse(input, out int result);

        Assert.False(success);
    }

    // Variante 1: Test, dass mit InvariantCulture und striktem NumberStyles Komma nicht akzeptiert wird
    [Fact]
    public void DecimalTryParse_WithComma_ShouldFailInInvariantCulture()
    {
        string input = "19,99";
        bool success = decimal.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal value);

        Assert.False(success);
    }

    [Fact]
    public void DecimalTryParse_WithGermanCulture_ShouldSucceed()
    {
        string input = "19,99";
        var culture = new CultureInfo("de-DE");

        bool success = decimal.TryParse(input, NumberStyles.Number, culture, out decimal value);

        Assert.True(success);
        Assert.Equal(19.99m, value);
    }
}