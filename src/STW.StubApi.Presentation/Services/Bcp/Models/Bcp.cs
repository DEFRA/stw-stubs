namespace STW.StubApi.Presentation.Services.Bcp.Models;

public class Bcp
{
    public long Id { get; init; }

    public string Name { get; init; }

    public string Code { get; init; }

    public bool Suspended { get; init; }

    public IList<string> Types { get; set; } = new List<string>();
}
