namespace STW.StubApi.Presentation.Services.FieldConfig.Helpers;

using Models;

public static class FieldConfigHelper
{
    public static FieldConfigDto GetFieldConfigDto(string certType, string commodityCode)
    {
        var data = LoadFieldConfigDataFromFile(commodityCode == "03061699" ? "fieldConfigData.json" : "defaultFieldConfigData.json");

        return new FieldConfigDto
        {
            CertificateType = certType,
            CommodityCode = commodityCode,
            Data = data,
            Id = 1
        };
    }

    private static string LoadFieldConfigDataFromFile(string filename)
    {
        string jsonFileContent;

        try
        {
            jsonFileContent = File.ReadAllText(Path.Combine("Services/FieldConfig/Helpers/", filename));
        }
        catch (Exception exception)
        {
            jsonFileContent = string.Empty;
        }

        return jsonFileContent;
    }
}
