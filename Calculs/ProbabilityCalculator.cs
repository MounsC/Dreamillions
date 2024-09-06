using System.Security.Cryptography;

public class ProbabilityCalculator
{
    private int totalNumbers = 50;
    private int totalStars = 12;
    private int drawnNumbers = 5;
    private int drawnStars = 2;
    private RandomNumberGenerator _randGen;

    public ProbabilityCalculator()
    {
        _randGen = RandomNumberGenerator.Create();
    }
    private List<int> GenerateRandomUniqueDraw(int maxNumber, int count)
    {
        var draw = new List<int>();
        byte[] buffer = new byte[4];

        while (draw.Count < count)
        {
            _randGen.GetBytes(buffer);
            int value = Math.Abs(BitConverter.ToInt32(buffer, 0)) % maxNumber + 1;
            if (!draw.Contains(value))
            {
                draw.Add(value);
            }
        }

        return draw;
    }

    private long CalculateCombination(int n, int k)
    {
        if (k < 0 || k > n) return 0;
        if (k == 0 || k == n) return 1;

        long result = 1;
        for (int i = 1; i <= k; i++)
        {
            result *= n - (k - i);
            result /= i;
        }
        return result;
    }

    public async Task<double> MonteCarloSimulation(int simulations, List<int> targetNumbers, List<int> targetStars, int minNumbersMatch, int minStarsMatch)
    {
        int successfulDraws = 0;

        for (int i = 0; i < simulations; i++)
        {
            var simulatedNumbers = GenerateRandomUniqueDraw(totalNumbers, drawnNumbers);
            var simulatedStars = GenerateRandomUniqueDraw(totalStars, drawnStars);

            int numbersMatchCount = targetNumbers.Intersect(simulatedNumbers).Count();
            int starsMatchCount = targetStars.Intersect(simulatedStars).Count();

            if (numbersMatchCount >= minNumbersMatch && starsMatchCount >= minStarsMatch)
            {
                successfulDraws++;
            }
        }

        double probability = (double)successfulDraws / simulations;
        return probability > 0 ? probability : 1e-9;  // 10 puissance -9, valeur arbitraire
                                                      // Je pourrais améliorer ça en faisant Vmin = 1/Nb total de simu ? Un truc type 1x10p-6
                                                      // Ou me baser sur l'échantillonnage ?
    }

    public async Task<double> CalculateBayesianProbabilityAsync(
        List<int> currentDrawNumbers,
        List<int> targetNumbers,
        List<int> targetStars,
        double prior)
    {
        double likelihood = await MonteCarloSimulation(100000, targetNumbers, targetStars, 2, 1);
        double evidence = 1.0 / (CalculateCombination(totalNumbers, drawnNumbers) * CalculateCombination(totalStars, drawnStars));
        double bayesianProbability = (likelihood * prior) / evidence;

        if (double.IsNaN(bayesianProbability) || bayesianProbability < 0)
        {
            return 0;  // Error = 0
        }

        return bayesianProbability;
    }
}
