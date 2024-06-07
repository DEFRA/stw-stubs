namespace STW.StubApi.Presentation.Services.Countries.Models;

using System;

public class Country
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public int Risk { get; set; }

    public DateOnly LastUpdated { get; set; }

    public bool Eu { get; set; }

    public bool IpaffsChargeGroup { get; set; }

    public bool PodGroup { get; set; }

    public bool IsLowRiskArticle72 { get; set; }
}
