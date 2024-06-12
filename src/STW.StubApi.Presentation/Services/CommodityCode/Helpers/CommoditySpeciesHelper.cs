namespace STW.StubApi.Presentation.Services.CommodityCode.Helpers;

using Models;
using Presentation.Models;

public static class CommoditySpeciesHelper
{
    private static readonly List<ChedppSpecies> ChedppSpecies = new List<ChedppSpecies>
    {
        new ChedppSpecies
        {
            CommodityCode = "0808108090",
            SpeciesName = "apple tree (ornamental)",
            SpeciesId = 1430559,
            CommodityDescription = "Other",
            EppoCode = "MABSZ"
        },
        new ChedppSpecies
        {
            CommodityCode = "0808108090",
            SpeciesName = "Malus angustifolia",
            SpeciesId = 1319830,
            CommodityDescription = "Other",
            EppoCode = "MABAN"
        },
        new ChedppSpecies
        {
            CommodityCode = "06011010",
            SpeciesName = "Albuca bracteata",
            SpeciesId = 1325967,
            CommodityDescription = "Hyacinths",
            EppoCode = "ABWBR"
        },
        new ChedppSpecies
        {
            CommodityCode = "06011010",
            SpeciesName = "Albuca canadensis",
            SpeciesId = 1425416,
            CommodityDescription = "Hyacinths",
            EppoCode = "ABWAL"
        }
    };

    public static PageImpl<ChedppSpecies> Search(string commodityCode, string? eppoCode, string? speciesName)
    {
        var query = ChedppSpecies
            .Where(x => x.CommodityCode == commodityCode)
            .AsQueryable();

        if (eppoCode is not null)
        {
            query = query.Where(x => x.EppoCode.Equals(eppoCode, StringComparison.OrdinalIgnoreCase));
        }

        if (speciesName is not null)
        {
            query = query.Where(x => x.SpeciesName.Equals(speciesName, StringComparison.OrdinalIgnoreCase));
        }

        return new PageImpl<ChedppSpecies>
        {
            Content = query.ToList()
        };
    }
}
