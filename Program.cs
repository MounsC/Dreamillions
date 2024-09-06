using OfficeOpenXml;

class Program
{
    static async Task Main(string[] args)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        string folderPath = "json";

        int numberOfSimulations = 1000000; // Nombre de simulations pour Monte Carlo
        int numberOfGrids = 5; // Nombre de grilles générées

        var dataLoader = new EuroMillionsDataLoader();
        var draws = dataLoader.LoadData(folderPath);
        var analyzer = new EuroMillionsAnalyzer(draws);
        var probabilityCalculator = new ProbabilityCalculator();
        var gridGenerator = new GridGenerator(analyzer);
        var optimizedNumbersList = new List<List<int>>();
        var optimizedStarsList = new List<List<int>>();
        var monteCarloProbabilities = new List<double>();
        var bayesianProbabilities = new List<double>();

        for (int i = 0; i < numberOfGrids; i++)
        {
            var biasedNumbers = gridGenerator.GenerateBiasedNumberGrid();
            var biasedStars = gridGenerator.GenerateBiasedStarGrid();

            double monteCarloProb = await probabilityCalculator.MonteCarloSimulation(numberOfSimulations, biasedNumbers, biasedStars, 2, 1);
            double bayesianProb = await probabilityCalculator.CalculateBayesianProbabilityAsync(
                draws.SelectMany(d => d.Numbers).ToList(),
                biasedNumbers,
                biasedStars,
                0.01
            );

            Console.WriteLine($"Grille {i + 1} - Numéros Biaisés : {string.Join(", ", biasedNumbers)}");
            Console.WriteLine($"Grille {i + 1} - Étoiles Biaisées : {string.Join(", ", biasedStars)}");
            Console.WriteLine($"Probabilité Monte Carlo : {monteCarloProb}");
            Console.WriteLine($"Probabilité Bayésienne : {bayesianProb}");

            optimizedNumbersList.Add(biasedNumbers);
            optimizedStarsList.Add(biasedStars);
            monteCarloProbabilities.Add(monteCarloProb);
            bayesianProbabilities.Add(bayesianProb);
        }

        Console.WriteLine($"Nombre de grilles générées : {optimizedNumbersList.Count}");
        Console.WriteLine($"Nombre de probabilités Monte Carlo calculées : {monteCarloProbabilities.Count}");
        Console.WriteLine($"Nombre de probabilités bayésiennes calculées : {bayesianProbabilities.Count}");

        var excelReportGenerator = new ExcelReportGenerator();
        excelReportGenerator.GenerateReport("Dreamillions_Report.xlsx", optimizedNumbersList, optimizedStarsList, new Dictionary<string, double>(), monteCarloProbabilities, bayesianProbabilities);

        Console.WriteLine("Rapport Excel généré avec succès !");
    }
}