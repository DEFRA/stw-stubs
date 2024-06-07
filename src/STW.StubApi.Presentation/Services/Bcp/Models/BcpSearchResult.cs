namespace STW.StubApi.Presentation.Services.Bcp.Models;

public class BcpSearchResult
{
    public int Page { get; init; }

    public int Elements { get; init; }

    public int TotalPages { get; init; }

    public SearchParameters SearchParameters { get; init; }

    public IList<Bcp> Bcps { get; init; }
}
