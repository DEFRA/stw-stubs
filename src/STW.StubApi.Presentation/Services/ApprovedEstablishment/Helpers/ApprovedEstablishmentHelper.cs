namespace STW.StubApi.Presentation.Services.ApprovedEstablishment.Helpers;

using Models;
using Presentation.Models;

public static class ApprovedEstablishmentHelper
{
    public static PageImpl<ApprovedEstablishment> Search(SearchQuery searchQuery)
    {
        var query = Fixtures.ApprovedEstablishments.AsQueryable();

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
