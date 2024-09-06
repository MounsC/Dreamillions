public class GridGenerator
{
    private EuroMillionsAnalyzer _analyzer;
    private Random _rand;
    private int totalNumbers = 50; // Nombre total de numéros disponibles
    private int drawnNumbers = 5;  // Nombre de numéros à tirer
    private int totalStars = 12;   // Nombre total d'étoiles disponibles
    private int drawnStars = 2;    // Nombre d'étoiles à tirer

    public GridGenerator(EuroMillionsAnalyzer analyzer)
    {
        _analyzer = analyzer;
        _rand = new Random(); // Initialisation de Random une seule fois
    }

    private List<int> GenerateBiasedDraw(Dictionary<int, int> frequencyData, int maxNumber, int count)
    {
        var weightedNumbers = frequencyData.SelectMany(kvp => Enumerable.Repeat(kvp.Key, kvp.Value)).Distinct().ToList();
        return weightedNumbers.OrderBy(x => _rand.Next()).Take(count).ToList();
    }

    public List<int> GenerateBiasedNumberGrid()
    {
        var frequencies = _analyzer.CalculateNumberFrequencies();
        return GenerateBiasedDraw(frequencies, totalNumbers, drawnNumbers);
    }

    public List<int> GenerateBiasedStarGrid()
    {
        var frequencies = _analyzer.CalculateStarFrequencies();
        return GenerateBiasedDraw(frequencies, totalStars, drawnStars);
    }

    private List<int> GenerateRandomUniqueDraw(int maxNumber, int count)
    {
        return Enumerable.Range(1, maxNumber)
                         .OrderBy(x => _rand.Next())
                         .Take(count)
                         .ToList();
    }
}