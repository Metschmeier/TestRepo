using Xunit;

namespace Starter.Tests;

public class NullableTests
{
    [Fact]
    public void NullableInt_HasValue_ReturnsTrue()
    {
        int? number = 5;
        Assert.True(number.HasValue);
        Assert.Equal(5, number.Value);
    }

    [Fact]
    public void NullableInt_IsNull_ReturnsFalse()
    {
        int? number = null;
        Assert.False(number.HasValue);
    }

    [Fact]
    public void GetValueOrDefault_ReturnsZero()
    {
        int? number = null;
        Assert.Equal(0, number.GetValueOrDefault());
    }

    [Fact]
    public void NullCoalescingOperator_ReturnsFallbackValue_WhenNull()
    {
        int? number = null;

        // Wenn number null ist, wird 10 als Fallback zurückgegeben
        int result = number ?? 10;

        Assert.Equal(10, result);
    }

    [Fact]
    public void NullCoalescingOperator_ReturnsValue_WhenNotNull()
    {
        int? number = 5;

        int result = number ?? 10;

        Assert.Equal(5, result);
    }
}