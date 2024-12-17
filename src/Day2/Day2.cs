using static Utils.Utils;

// Get input data
var reports = GetInputs (2);
//var reports = GetBasicInputs(2);

int safeCount = 0;
int safeCountPart2 = 0;

foreach (var report in reports) {
	var parts = report.Split (' ');
	List<int> levels = [.. parts.Select (int.Parse)];
	bool ascending = levels[0] < levels[1];

	if (IsReportSafe (levels)) {
		safeCount++;
	} else {
		if (IsReportSafeWithDampener (levels))
			safeCountPart2++;
	}
}

Console.WriteLine ($"Part 1: {safeCount}"); // 472
Console.WriteLine ($"Part 2: {safeCount + safeCountPart2}"); // 520

bool IsReportSafe (List<int> levels)
{
	bool ascending = levels[0] < levels[1];

	for (int i = 0; i < levels.Count - 1; i++) {
		if (!TestLevelRules (levels[i], levels[i + 1], ascending))
			return false;
	}

	return true;
}

bool IsReportSafeWithDampener (List<int> levels)
{
	for (int i = 0; i < levels.Count; i++) {
		var newList = levels.Where ((_, index) => i != index).ToList ();
		if (IsReportSafe (newList))
			return true;
	}

	return false;
}

bool TestLevelRules (int i, int j, bool ascending)
{
	var diff = Math.Abs (i - j);
	if (diff is < 1 or > 3) {
		return false;
	}

	if (ascending) {
		return i < j;
	} else {
		return i > j;
	}
}
