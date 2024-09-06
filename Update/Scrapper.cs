/*using HtmlAgilityPack;
using Newtonsoft.Json;

class Scrapper
{
    private static readonly List<string> urls = new List<string>
    {
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2007/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2006/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2005/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2004/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2008/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2009/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2010/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2011/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2012/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2013/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2014/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2015/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2016/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2017/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2018/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2019/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2020/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2021/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2022/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2023/",
        "https://www.tirage-euromillions.net/euromillions/annees/annee-2024/"
    };

    static async Task Main(string[] args)
    {
        foreach (var url in urls)
        {
            await ScrapeDataFromUrl(url);
        }
    }

    static async Task ScrapeDataFromUrl(string url)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetStringAsync(url);

        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(response);

        var table = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'blue_table')]");
        var rows = table.SelectNodes(".//tr");

        var tirages = new List<Tirage>();

        foreach (var row in rows)
        {
            var cells = row.SelectNodes(".//td");

            if (cells != null && cells.Count >= 8)
            {
                var tirage = new Tirage
                {
                    Date = cells[0].InnerText.Trim(),
                    Numbers = new List<int>
                    {
                        int.Parse(cells[1].InnerText.Trim()),
                        int.Parse(cells[2].InnerText.Trim()),
                        int.Parse(cells[3].InnerText.Trim()),
                        int.Parse(cells[4].InnerText.Trim()),
                        int.Parse(cells[5].InnerText.Trim())
                    },
                    Stars = new List<int>
                    {
                        int.Parse(cells[6].InnerText.Trim()),
                        int.Parse(cells[7].InnerText.Trim())
                    }
                };

                tirages.Add(tirage);
            }
        }

        var year = ExtractYearFromUrl(url);
        SaveDataToJson(tirages, year);
    }

    static string ExtractYearFromUrl(string url)
    {
        var parts = url.Trim('/').Split('/');
        return parts[^1].Replace("annee-", "");
    }

    static void SaveDataToJson(List<Tirage> tirages, string year)
    {
        var directoryPath = "json";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        var json = JsonConvert.SerializeObject(tirages, Formatting.Indented);
        File.WriteAllText(Path.Combine(directoryPath, $"{year}.json"), json);
    }

    public class Tirage
    {
        public string Date { get; set; }
        public List<int> Numbers { get; set; }
        public List<int> Stars { get; set; }
    }
}*/