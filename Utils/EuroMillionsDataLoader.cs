using Newtonsoft.Json;

public class EuroMillionsDataLoader
{
    public List<EuroMillionsDraw> LoadData(string folderPath)
    {
        var allDraws = new List<EuroMillionsDraw>();
        var jsonFiles = Directory.GetFiles(folderPath, "*.json");

        foreach (var file in jsonFiles)
        {
            var jsonData = File.ReadAllText(file);
            var draws = JsonConvert.DeserializeObject<List<EuroMillionsDraw>>(jsonData);
            allDraws.AddRange(draws);
        }

        return allDraws;
    }
}