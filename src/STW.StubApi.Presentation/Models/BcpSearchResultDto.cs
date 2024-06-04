namespace STW.StubApi.Presentation.Models;

public class BcpSearchResultDto
{
    public int Page { get; init; }

    public int Elements { get; init; }

    public int TotalPages { get; init; }

    public SearchParametersDto SearchParameters { get; init; }

    public List<BcpDto> Bcps { get; init; }

    public class SearchParametersDto
    {
        public string? Name { get; init; }

        public string? Code { get; init; }

        public string? Type { get; init; }

        public bool? IsUkOnly { get; init; }
    }

    public class BcpDto
    {
        public long Id { get; init; }

        public string Name { get; init; }

        public string Code { get; init; }

        public bool Suspended { get; init; }
    }
}
