public class EuroMillionsAnalyzer
{
    private List<EuroMillionsDraw> _draws;

    public EuroMillionsAnalyzer(List<EuroMillionsDraw> draws)
    {
        _draws = draws;
    }

    public Dictionary<int, int> CalculateNumberFrequencies()
    {
        return CalculateFrequencies(_draws.SelectMany(d => d.Numbers).ToList());
    }

    public Dictionary<int, int> CalculateStarFrequencies()
    {
        return CalculateFrequencies(_draws.SelectMany(d => d.Stars).ToList());
    }

    private Dictionary<int, int> CalculateFrequencies(List<int> numbers)
    {
        return numbers.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());
    }

    public Dictionary<string, double> CalculateDescriptiveStatistics(List<int> numbers)
    {
        var mean = numbers.Average();
        var variance = numbers.Select(n => Math.Pow(n - mean, 2)).Average();
        var stdDev = Math.Sqrt(variance);
        var median = CalculateMedian(numbers);

        return new Dictionary<string, double>
        {
            { "Mean", mean },
            { "Variance", variance },
            { "Standard Deviation", stdDev },
            { "Median", median }
        };
    }

    private double CalculateMedian(List<int> numbers)
    {
        numbers.Sort();
        int count = numbers.Count;
        if (count % 2 == 0)
        {
            return (numbers[count / 2 - 1] + numbers[count / 2]) / 2.0;
        }
        else
        {
            return numbers[count / 2];
        }
    }
}