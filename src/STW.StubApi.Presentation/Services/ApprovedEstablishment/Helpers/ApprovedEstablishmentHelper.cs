namespace STW.StubApi.Presentation.Services.ApprovedEstablishment.Helpers;

using Models;
using Presentation.Models;

public static class ApprovedEstablishmentHelper
{
    private static readonly List<ApprovedEstablishment> ApprovedEstablishments = new List<ApprovedEstablishment>
    {
        new ApprovedEstablishment
        {
            Id = "34f8ac69-1dd7-4e82-bacc-50d1560e3bce",
            ApprovalNumber = "2318367",
            Country = "United States of America",
            CountryCode = "US",
            ActivitiesLegend = "Processing Plant",
            Section = "Section 12",
            CompanyName = "Ole Biloxi Fish and Oyster Co.",
            City = "Unnao",
            Region = "Uttar Pradesh"
        }
    };

    public static PageImpl<ApprovedEstablishment> Search(SearchQuery searchQuery)
    {
        var query = ApprovedEstablishments.AsQueryable();

        if (searchQuery.ApprovalNumber is not null)
        {
            query = query.Where(x => x.ApprovalNumber == searchQuery.ApprovalNumber);
        }

        if (searchQuery.CountryCode is not null)
        {
            query = query.Where(x => x.CountryCode == searchQuery.CountryCode);
        }

        if (searchQuery.Section is not null)
        {
            query = query.Where(x => x.Section == searchQuery.Section);
        }

        if (searchQuery.ActivitiesLegend is not null)
        {
            query = query.Where(x => x.ActivitiesLegend == searchQuery.ActivitiesLegend);
        }

        return new PageImpl<ApprovedEstablishment>
        {
            Content = query.ToList()
        };
    }
}
