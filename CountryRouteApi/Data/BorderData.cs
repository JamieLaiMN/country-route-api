public class BorderData
{
    Dictionary<string, string[]> borders = new Dictionary<string, string[]>();

    public BorderData()
    {
        borders["CAN"] = new string[] { "USA" };
        borders["USA"] = new string[] { "CAN", "MEX" };
        borders["MEX"] = new string[] { "USA", "BLZ", "GTM" };
        borders["BLZ"] = new string[] { "MEX", "GTM" };
        borders["GTM"] = new string[] { "MEX", "BLZ", "SLV", "HND" };
        borders["SLV"] = new string[] { "GTM", "HND" };
        borders["HND"] = new string[] { "GTM", "SLV", "NIC" };
        borders["NIC"] = new string[] { "HND", "CRI" };
        borders["CRI"] = new string[] { "NIC", "PAN" };
        borders["PAN"] = new string[] { "CRI" };
    }

    public string[] GetBorders(string country)
    {
        return borders[country];
    }

    public bool ContainsCountry(string country)
    {
        return borders.ContainsKey(country);
    }
}