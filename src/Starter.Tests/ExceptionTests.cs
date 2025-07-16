using System;
using Xunit;

namespace Starter.Tests;

public class ExceptionTests
{
    [Fact]
    public void DivisionDurchNull_WirftException()
    {
        int x = 10;
        int y = 0;

        Assert.Throws<DivideByZeroException>(() =>
        {
            int result = x / y;
        });
    }

    [Fact]
    public void ArgumentException_WirdGeworfen()
    {
        void CheckName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name darf nicht leer sein");
        }

        Assert.Throws<ArgumentException>(() => CheckName(""));
    }

    [Fact]
    public void ArgumentNullException_WirdGeworfen()
    {
        void CheckParameter(string? param) // nullable Parameter
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param), "Parameter darf nicht null sein");
        }

        Assert.Throws<ArgumentNullException>(() => CheckParameter(null));
    }
}