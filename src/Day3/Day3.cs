using System.Text;

using static Utils.Utils;

// Get input data
var reports = GetInputs (3);
//var reports = GetBasicInputs(2);


void Main ()
{
	string file = @"D:\code\AdventOfCode\2024\Inputs\Day3Basic.txt";
	var corruptedCode = File.ReadAllLines (file);
	List<string> results = new List<string> ();

	foreach (var line in corruptedCode) {
		Console.WriteLine (line);
		results.Add (ParseInput (line.AsSpan ()));
	}
}

string ParseInput (ReadOnlySpan<char> corruptedCode)
{
	bool consume = false;
	StringBuilder program = new StringBuilder ();

	string buffer = string.Empty;
	List<int> indexes = new List<int> ();

	for (int i = 0; i < corruptedCode.Length - 1; i++) {
		if (i + 3 < corruptedCode.Length - 1) {
			var slice = corruptedCode.Slice (i, 4);
			if (IsMulCommandStart (slice)) {
				Console.WriteLine ($"Found MUL command: {slice}");
				i += 4;
			}
			//Console.WriteLine(slice.ToString());
		}
	}

	return string.Empty;
}

bool IsMulCommandStart (ReadOnlySpan<char> block)
{
	if (block.SequenceEqual ("mul(".AsSpan ())) {
		return true;
	}

	return false;
}

