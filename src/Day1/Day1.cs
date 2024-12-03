using static Utils.Utils;

// Get input data
var inputs = GetInputs(1);
//var inputs = GetBasicInputs(1);

// Part 1
List<int> left = [];
List<int> right = [];

foreach (var input in inputs)
{
    var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    left.Add(int.Parse(parts[0]));
    right.Add(int.Parse(parts[1]));
}

left.Sort();
right.Sort();

int sum = 0;
for (int i = 0; i < left.Count; i++)
{
    sum += Math.Abs(left[i] - right[i]);
}

Console.WriteLine($"Part 1: {sum}"); // 3569916

// Part 2
int part2Sum = 0;
foreach (var l in left)
{
    part2Sum += l * right.FindAll(r => r == l).Count;
}

Console.WriteLine($"Part 2: {part2Sum}"); // 26407426