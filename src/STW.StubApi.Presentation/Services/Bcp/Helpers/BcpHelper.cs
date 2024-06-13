namespace STW.StubApi.Presentation.Services.Bcp.Helpers;

using Models;

public static class BcpHelper
{
    private static readonly List<Bcp> Bcps =
    [
        new Bcp
        {
            Id = 1,
            Name = "Belfast Airport",
            Code = "GBBEL1",
            Suspended = false,
            Types = ["CHED-P"]
        },
        new Bcp
        {
            Id = 49,
            Name = "Manchester Airport",
            Code = "GBMNC1",
            Suspended = true,
            Types = ["CHED-P", "CHED-D"]
        },
        new Bcp
        {
            Id = 635,
            Name = "Aberdeen Harbour Board (plants)",
            Code = "GBAHB4PP",
            Suspended = false,
            Types = ["CHED-PP"]
        }
    ];

    public static BcpSearchResult Search(string? code, string? type)
    {
        var query = Bcps.AsQueryable();

        if (code is not null)
        {
            query = query.Where(x => x.Code == code);
        }

        if (type is not null)
        {
            query = query.Where(x => x.Types.Contains(type));
        }

        return new BcpSearchResult
        {
            Page = 1,
            Elements = 25,
            TotalPages = 1,
            SearchParameters = new SearchParameters
            {
                Code = code,
                Type = type
            },
            Bcps = query.ToList()
        };
    }
}
