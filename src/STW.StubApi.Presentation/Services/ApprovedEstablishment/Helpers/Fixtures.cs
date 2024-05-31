namespace STW.StubApi.Presentation.Services.ApprovedEstablishment.Helpers;

using Models;

public static class Fixtures
{
    public static readonly List<ApprovedEstablishment> ApprovedEstablishments = new List<ApprovedEstablishment>
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
}
