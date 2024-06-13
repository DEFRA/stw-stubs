namespace STW.StubApi.Presentation.Services.Bcp.Models;

public class SearchParameters
{
    public string? Name { get; init; }

    public string? Code { get; init; }

    public string? Type { get; init; }

    public bool? IsUkOnly { get; init; }
}
