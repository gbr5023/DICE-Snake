using System.Linq;
using System.IO;

public class TestImport
{
	string[][] variables;

	public TestImport()
	{
		variables = GetVariables();
	}

	// initialize and accessor for variables jagged array
	public string[][] GetVariables()
	{
        /*
         * path (variable below) can remain empty as long as the file ("ALLscaledwithRGB.csv") is located within the 
         * unity project's uppermost folder (in this case, the file is located in "Test" and not in 
         * any subfolder
         */
		string path = ""; // empty path, but variable needed for Path.Combine(path, file) method
		string file = "ALLscaledwithRGB.csv"; // file name

        /*
         * assign contents of the .csv file to be stored into the jagged array, "variables"
         * separations from variable to variable (in the csv) aka cells, rows, columns, etc, is
         * handled by the line.Split('y') method
         * each line, separated by a comma, is then read into the array
         */
		variables = File.ReadAllLines(Path.Combine(path, file))
			.Select(line => line.Split(',')).ToArray();

		return variables; // return jagged array for use in the TestSort.cs file
	}
}