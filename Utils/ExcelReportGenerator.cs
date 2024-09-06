using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

public class ExcelReportGenerator
{
    public void GenerateReport(
        string filePath,
        List<List<int>> optimizedNumbersList,
        List<List<int>> optimizedStarsList,
        Dictionary<string, double> statistics,
        List<double> monteCarloProbabilities,
        List<double> bayesianProbabilities)
    {
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Dreamillions Report");

            worksheet.Cells["A1"].Value = "Dreamillions Analysis Report";
            worksheet.Cells["A1"].Style.Font.Size = 20;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A1:E1"].Merge = true;

            worksheet.Cells["A3"].Value = "Ce rapport contient une analyse complète des tirages de l'EuroMillions, " +
                                           "y compris des statistiques descriptives, des probabilités simulées " +
                                           "et des grilles optimisées pour les futurs tirages.";
            worksheet.Cells["A3:E3"].Merge = true;

            worksheet.Cells["A5"].Value = "Grilles Optimisées";
            worksheet.Cells["A5"].Style.Font.Bold = true;

            int startRow = 6;

            for (int i = 0; i < optimizedNumbersList.Count; i++)
            {
                worksheet.Cells[$"A{startRow}"].Value = $"Grille {i + 1} - Numéros Optimisés :";
                worksheet.Cells[$"B{startRow}"].Value = string.Join(", ", optimizedNumbersList[i]);
                Console.WriteLine($"Ecriture des numéros optimisés pour Grille {i + 1}");

                worksheet.Cells[$"A{startRow + 1}"].Value = $"Grille {i + 1} - Étoiles Optimisées :";
                worksheet.Cells[$"B{startRow + 1}"].Value = string.Join(", ", optimizedStarsList[i]);
                Console.WriteLine($"Ecriture des étoiles optimisées pour Grille {i + 1}");

                worksheet.Cells[$"A{startRow + 2}"].Value = $"Probabilité Simulée (Monte Carlo) :";
                worksheet.Cells[$"B{startRow + 2}"].Value = Math.Round(monteCarloProbabilities[i], 4);
                Console.WriteLine($"Ecriture de la probabilité Monte Carlo pour Grille {i + 1}");

                worksheet.Cells[$"A{startRow + 3}"].Value = $"Probabilité Bayésienne :";
                if (i < bayesianProbabilities.Count)
                {
                    worksheet.Cells[$"B{startRow + 3}"].Value = Math.Round(bayesianProbabilities[i], 2);
                    Console.WriteLine($"Ecriture de la probabilité Bayésienne pour Grille {i + 1}");
                }
                else
                {
                    worksheet.Cells[$"B{startRow + 3}"].Value = "N/A";
                    Console.WriteLine($"Probabilité Bayésienne manquante pour Grille {i + 1}");
                }

                startRow += 5;
            }

            worksheet.Cells[$"A{startRow}"].Value = "Statistiques Descriptives";
            worksheet.Cells[$"A{startRow}"].Style.Font.Bold = true;

            startRow++;
            foreach (var stat in statistics)
            {
                worksheet.Cells[$"A{startRow}"].Value = stat.Key;
                worksheet.Cells[$"B{startRow}"].Value = Math.Round(stat.Value, 2);
                startRow++;
            }

            startRow += 2;
            worksheet.Cells[$"A{startRow}"].Value = "Informations sur les probabilités";
            worksheet.Cells[$"A{startRow}"].Style.Font.Bold = true;
            worksheet.Cells[$"A{startRow + 1}"].Value = "La probabilité Monte Carlo est une estimation basée sur de nombreuses simulations.";
            worksheet.Cells[$"A{startRow + 2}"].Value = "Elle indique la fréquence à laquelle une grille particulière pourrait gagner.";
            worksheet.Cells[$"A{startRow + 3}"].Value = "La probabilité bayésienne combine des informations a priori avec les résultats de simulation.";
            worksheet.Cells[$"A{startRow + 4}"].Value = "Cela permet une estimation plus fine en intégrant des connaissances antérieures sur les tirages.";

            worksheet.Cells["A1:A9"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Cells["A5:A5"].Style.Font.Color.SetColor(Color.DarkBlue);
            worksheet.Cells[$"A{startRow - statistics.Count}:B{startRow - statistics.Count}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[$"A{startRow - statistics.Count}:B{startRow - statistics.Count}"].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            worksheet.Cells["A1:E1"].Style.Border.BorderAround(ExcelBorderStyle.Thick);

            worksheet.Cells["A1:E50"].AutoFitColumns();

            package.SaveAs(new FileInfo(filePath));
            Console.WriteLine("Le fichier Excel a été généré avec succès.");
        }
    }
}
