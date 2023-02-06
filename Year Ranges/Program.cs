var years = new List<int>() { 1981, 1990, 1982, 2004, 2005, 2010, 2002 };
years.Sort();

int previousYear = 0;
var ranges = new List<string>();
bool isFirst = true;
bool isConsecutiveYear = false;
int? consecutiveYearStart = null;
int lastYear = years.Last();

foreach (var year in years)
{
    int currentYear = year;

    if (isFirst)
    {
        previousYear = currentYear;
        isFirst = false;
        continue;
    }

    if (isConsecutiveYear == false)
    {
        if (currentYear == previousYear + 1)
        {
            consecutiveYearStart = previousYear;

            if (currentYear == lastYear)
            {
                ranges.Add($"{consecutiveYearStart}-{currentYear}");
            }

            isConsecutiveYear = true;
        }
        else
        {
            ranges.Add($"{previousYear}");
        }
    }
    else
    {
        if (currentYear == previousYear + 1)
        {
            previousYear = currentYear;
        }
        else
        {
            if (consecutiveYearStart.HasValue)
            {
                ranges.Add($"{consecutiveYearStart.Value}-{previousYear}");
                isConsecutiveYear = false;
                consecutiveYearStart = null;
            }

            if (currentYear == lastYear)
            {
                ranges.Add($"{currentYear}");
            }
        }
    }

    previousYear = currentYear;
}

Console.WriteLine(string.Join(", ", ranges));
Console.ReadLine();
