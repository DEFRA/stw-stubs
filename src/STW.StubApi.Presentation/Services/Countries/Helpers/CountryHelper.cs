namespace STW.StubApi.Presentation.Services.Countries.Helpers;

using System.Collections.Generic;
using System.Linq;
using Models;

public static class CountryHelper
{
    private static readonly List<Country> CountriesAndRegions = new List<Country>
    {
        new Country
        {
            Name = "Afghanistan",
            Code = "AF",
            Eu = false,
            IsLowRiskArticle72 = false,
            Risk = 0,
            IpaffsChargeGroup = false,
            PodGroup = false,
        },
        new Country
        {
            Name = "United Kingdom of Great Britain and Northern Ireland",
            Code = "GB",
            Eu = false,
            IsLowRiskArticle72 = false,
            Risk = 1,
            IpaffsChargeGroup = false,
            PodGroup = false,
        },
        new Country
        {
            Name = "Wales",
            Code = "GB-WLS",
            IsLowRiskArticle72 = false,
            IpaffsChargeGroup = false,
            PodGroup = false,
        }
    };

    public static Country? GetCountryOrRegion(string isoCode) => CountriesAndRegions.FirstOrDefault(x => x.Code == isoCode);
}
