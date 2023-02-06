// See https://aka.ms/new-console-template for more information

var years = new List<int>() { 1981, 1990, 2004, 2005 };

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
    #region Old Logic
    //if ((current == previous + 1) && isInRange == false)
    //{
    //    rangeStart = previous;
    //    isInRange = true;
    //}
    //else if ((current == previous + 1))
    //{
    //    previous = current;
    //}
    //else if (isInRange == true && lastYear == current)
    //{
    //    ranges.Add($"{rangeStart}-{current}");
    //}
    //else if (isInRange == true)
    //{
    //    isInRange = false;
    //    ranges.Add($"{rangeStart}-{previous}");
    //}
    //else
    //{
    //    ranges.Add($"{previous}");
    //}
    #endregion

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
            if (currentYear == lastYear)
            {
                if (consecutiveYearStart.HasValue)
                {
                    ranges.Add($"{consecutiveYearStart.Value}-{previousYear}");
                    isConsecutiveYear = false;
                    consecutiveYearStart = null;
                }

                ranges.Add($"{currentYear}");
            }
            //else
            //{
            //    ranges.Add($"{consecutiveYearStart.Value}-{previousYear}");
            //    isConsecutiveYear = false;
            //    consecutiveYearStart = null;
            //}
        }
    }

    previousYear = currentYear;
}

//if (isInRange == true)
//{
//    isInRange = false;
//    ranges.Add($"{rangeStart}-{previous}");
//}
//else
//{
//    ranges.Add($"{current}");
//}

Console.WriteLine(string.Join(", ", ranges));
Console.ReadLine();
