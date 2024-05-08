namespace STW.StubApi.Presentation.UnitTests.TestHelpers;

public static class StreamExtensions
{
    public static async Task<string> ReadAsStringAsync(this Stream stream)
    {
        using var reader = new StreamReader(stream);

        return await reader.ReadToEndAsync();
    }
}