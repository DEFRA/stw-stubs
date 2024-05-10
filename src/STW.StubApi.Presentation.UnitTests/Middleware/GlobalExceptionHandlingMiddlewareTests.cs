namespace STW.StubApi.Presentation.UnitTests.Middleware;

using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentation.Middleware;

[TestClass]
public class GlobalExceptionHandlingMiddlewareTests
{
    private Mock<ILogger<GlobalExceptionHandlerMiddleware>> _loggerMock;
    private Mock<RequestDelegate> _nextMock;
    private GlobalExceptionHandlerMiddleware _systemUnderTest;

    [TestInitialize]
    public void TestInitialize()
    {
        _loggerMock = new Mock<ILogger<GlobalExceptionHandlerMiddleware>>();
        _nextMock = new Mock<RequestDelegate>();
        _systemUnderTest = new GlobalExceptionHandlerMiddleware(_nextMock.Object, _loggerMock.Object);
    }

    [TestMethod]
    public async Task Invoke_SetsResponseToInternalServerError_WhenExceptionIsThrown()
    {
        // Arrange
        var exception = new Exception();
        var httpContext = new DefaultHttpContext();

        _nextMock
            .Setup(x => x.Invoke(httpContext))
            .ThrowsAsync(exception);

        // Act
        await _systemUnderTest.Invoke(httpContext);

        // Assert
        httpContext.Response.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);

        _loggerMock.VerifyLog(x => x.LogCritical(exception, "Unhandled exception thrown"), Times.Once);
    }

    [TestMethod]
    public async Task Invoke_DoesNotSetResponseToInternalServerError_WhenNoExceptionIsThrown()
    {
        // Arrange
        var httpContext = new DefaultHttpContext();

        // Act
        await _systemUnderTest.Invoke(httpContext);

        // Assert
        httpContext.Response.StatusCode.Should().Be(StatusCodes.Status200OK);

        _loggerMock.VerifyLog(x => x.LogCritical(It.IsAny<Exception>(), "Unhandled exception thrown"), Times.Never);
    }
}
