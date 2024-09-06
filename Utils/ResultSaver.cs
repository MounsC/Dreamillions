using Newtonsoft.Json;

public class ResultSaver
{
    public void SaveResults<T>(T results, string filePath)
    {
        var jsonData = JsonConvert.SerializeObject(results, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
    }

    public void SaveGridResults(List<int> numberGrid, List<int> starGrid, double probability, string filePath)
    {
        var result = new
        {
            Numbers = numberGrid,
            Stars = starGrid,
            Probability = probability
        };

        SaveResults(result, filePath);
    }
}