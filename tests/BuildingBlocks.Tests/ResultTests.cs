using BuildingBlocks.Abstractions;
using Xunit;

namespace BuildingBlocks.Tests;

public class ResultTests
{
    [Fact]
    public void Success_HasExpectedState()
    {
        var result = Result.Success();

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(Error.None, result.Error);
    }

    [Fact]
    public void Failure_HasExpectedError()
    {
        var error = new Error("test.failure", "Expected failure", 400);

        var result = Result.Failure(error);

        Assert.True(result.IsFailure);
        Assert.Equal(error, result.Error);
    }
}
