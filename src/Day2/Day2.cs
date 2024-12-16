using static Utils.Utils;

// Get input data
var inputs = GetInputs(2);
//var inputs = GetBasicInputs(2);

// Part 1
int safeCount = 0;
foreach (var input in inputs)
{
    var parts = input.Split(' ');
    List<int> ints = [.. parts.Select(int.Parse)];

    if (IsSafe(ints))
        safeCount++;
}

bool IsSafe(List<int> ints)
{
    var result = CheckNumberSpacing(ints);
    if (!result)
        return false;

    bool isAscending = true;
    for (int i = 0; i < ints.Count - 1; i++)
    {
        if (ints[i] > ints[i + 1])
        {
            isAscending = false;
        }
    }

    bool isDescending = true;
    for (int i = 0; i < ints.Count - 1; i++)
    {
        if (ints[i] < ints[i + 1])
            isDescending = false;
    }

    if (!isAscending && !isDescending)
        return false;

    return true;
}

Console.WriteLine($"Part 1: {safeCount}"); // 472

static bool CheckNumberSpacing(List<int> ints)
{
    for (int i = 0; i < ints.Count - 1; i++)
    {
        var diff = Math.Abs(ints[i] - ints[i + 1]);
        if (diff < 1 || diff > 3)
            return false;
    }

    return true;
}