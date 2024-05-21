namespace STW.StubApi.Presentation.UnitTests.Middleware;

using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Persistence;
using Persistence.Entities;
using Presentation.Middleware;

[TestClass]
public class HttpTransactionPersistenceMiddlewareTests
{
    private Mock<ApplicationDbContext> _dbContextMock;
    private Mock<DbSet<HttpTransaction>> _httpTransactionDbSetMock;

    [TestInitialize]
    public void TestInitialize()
    {
        _httpTransactionDbSetMock = new Mock<DbSet<HttpTransaction>>();
        _dbContextMock = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
        _dbContextMock.Setup(x => x.HttpTransactions).Returns(_httpTransactionDbSetMock.Object);
    }

    [TestMethod]
    public async Task Invoke_PersistsCorrectRequestAndResponseData_WhenCalled()
    {
        // Arrange
        var correlationId = Guid.NewGuid();
        const string requestBody = "{ \"key\": \"value\" }";
        const string responseBody = "CHEDPP.GB.2024.100000";
        const string requestPath = "/request-path";
        var requestBodyStream = new MemoryStream(Encoding.UTF8.GetBytes(requestBody));

        var httpContext = new DefaultHttpContext
        {
            Request =
            {
                Body = requestBodyStream,
                ContentLength = requestBodyStream.Length,
                Method = HttpMethods.Post,
                Path = requestPath,
                Headers = { { "X-STW-CorrelationId", correlationId.ToString() } }
            }
        };

        var systemUnderTest = new HttpTransactionPersistenceMiddleware(
            async context =>
            {
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(responseBody));
                context.Response.StatusCode = StatusCodes.Status201Created;
            });

        // Act
        await systemUnderTest.Invoke(httpContext, _dbContextMock.Object);

        // Assert
        _httpTransactionDbSetMock.Verify(
            x => x.AddAsync(
                It.Is<HttpTransaction>(
                    a => a.CorrelationId == correlationId
                         && a.RequestBody == requestBody
                         && a.RequestMethod == HttpMethods.Post
                         && a.RequestPath == requestPath
                         && a.ResponseBody == responseBody
                         && a.ResponseStatusCode == StatusCodes.Status201Created),
                CancellationToken.None),
            Times.Once);

        _dbContextMock.Verify(x => x.SaveChangesAsync(CancellationToken.None), Times.Once);
    }
}
