## Overview

This project delivers a robust framework for analyzing EuroMillions lottery draw data, creating optimized betting grids, and computing winning probabilities through advanced Monte Carlo simulations and Bayesian probability calculations.
The solution also generates detailed Excel reports to summarize and visualize the analysis.

## Key Components

### 1. **Data Loading**
   - **EuroMillionsDataLoader**: Handles the loading of historical EuroMillions draw data stored in JSON format.
   
### 2. **Data Analysis**
   - **EuroMillionsAnalyzer**: Analyzes frequency distributions of numbers and stars in the draw data, providing insights into patterns and trends.
   - **Descriptive Statistics**: Calculates statistical measures such as mean, variance, standard deviation, and median for draw numbers.

### 3. **Grid Generation**
   - **GridGenerator**: Generates custom betting grids using frequency data to bias the grid creation process, producing grids more likely to match the draw results based on historical data.
   
### 4. **Probability Calculation**
   - **Monte Carlo Simulations**: Simulates millions of possible draw outcomes to estimate the probability of winning with a given grid.
   - **Bayesian Probability**: Combines historical data with new evidence to provide refined probability estimates.

### 5. **Reporting**
   - **ExcelReportGenerator**: Produces a detailed, professional-grade Excel report containing optimized grids, calculated probabilities, and descriptive statistics. The report is designed for easy interpretation and visualization.

## Features

- **Automated Data Loading**: Load draw data in bulk from JSON files with a few lines of code.
- **Comprehensive Statistical Analysis**: Analyze number and star frequency distributions and generate descriptive statistics.
- **Custom Grid Generation**: Create optimized grids based on historical frequency analysis or generate random grids.
- **Probabilistic Analysis**: Utilize both Monte Carlo and Bayesian methods to estimate the likelihood of winning with generated grids.
- **Excel Reporting**: Automatically generate a well-structured report in Excel, including detailed analyses, grid results, and probabilities.

## Installation

### Prerequisites

- .NET SDK
- Newtonsoft.Json (`Install-Package Newtonsoft.Json`)
- EPPlus for Excel report generation (`Install-Package EPPlus`)

### Setup Instructions

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/MounsC/Dreamillions.git
   cd dreamillions
   ```

2. **Install Required Packages:**

   Run the following commands to add the necessary dependencies to your project:

   ```bash
   dotnet add package Newtonsoft.Json
   dotnet add package EPPlus
   ```

3. **Run the Application:**

   Execute the following command to start the program:

   ```bash
   dotnet run
   ```

## Usage Instructions

1. **Data Preparation**: Place your EuroMillions draw data as `.json` files in the `json` directory.
2. **Configure Parameters**: Modify the number of simulations and grids to generate by adjusting values in `Program.cs`.
3. **Execution**: Run the project to generate grids and calculate probabilities.
4. **Results**: Upon successful execution, a detailed Excel report will be generated, summarizing optimized grids and probabilistic analysis.

## Example

By running this project, you'll obtain:
- Optimized betting grids based on historical data trends.
- Probability estimates derived from Monte Carlo simulations and Bayesian methods.
- A professionally formatted Excel report summarizing the analysis and results.

## Contributing

Contributions to improve the features or extend the capabilities of this project are welcome. Please open a pull request or issue for discussion.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## ToDo

Win Euromillions :kappa:
