using System;

public class TestSort
{
	// ************************************ DECLARE VARIABLES ************************************ //
	TestImport ti; // TestImport object for accessing TestImport's public methods
	string[][] variables; // local copy of the jagged array "variables"

	int row; // 2914 rows of data in csv

	int colBGE; // index of BGE column
	int colDAM; // index of DAM column
	int colPTEMP; // index of PTEMP column
	int colABATE; // index of ABATE column

	int colR; // index of color R column
	int colG; // index of color G column
	int colB; // index of color B column
	int colA; // index of color A column

	float[] floatBGE; // balanced growth equivalent (% reduction from no damages)
	float[] floatDAM; // x-axis- total damage (% consumption stream)
	float[] floatPTEMP; // y-axis- reliability of tempurature stabilization (%)
	float[] floatABATE; // z-axis- total abatement cost (% consumption stream)

	byte[] byteR; // red value of point color
	byte[] byteG; // green value of point color
	byte[] byteB; // blue value of point color
	byte[] byteA; // opacity of point color (between 0=fully transparent and 1=fully opaque)

	// ************************************ CONSTRUCTOR (INITIALIZE VARIABLES) ************************************ //

	public TestSort()
	{
		row = 2914; // 2914 rows of data in csv

		colBGE = 0; // index of BGE column
		colDAM = 1; // index of DAM column
		colPTEMP = 2; // index of PTEMP column
		colABATE = 3; // index of ABATE column

		colR = 4; // index of color R column
		colG = 5; // index of color G column
		colB = 6; // index of color B column
		colA = 7; // index of color A column

		ti = new TestImport();
		variables = ImportVariables();
		//PrintJagged(variables); // UNCOMMENT THIS TO PRINT VARIABLES JAGGED ARRAY

		floatBGE = new float[variables.Length];
		floatBGE = SetBGE(variables);
		//PrintFloat(floatBGE); UNCOMMENT THIS TO PRINT floatBGE ARRAY

		floatDAM = new float[variables.Length];
		floatDAM = SetDAM(variables);
		//PrintFloat(floatDAM); UNCOMMENT THIS TO PRINT floatDAM ARRAY

		floatPTEMP = new float[variables.Length];
		floatPTEMP = SetPTEMP(variables);
		//PrintFloat(floatPTEMP); UNCOMMENT THIS TO PRINT floatPTEMP ARRAY

		floatABATE = new float[variables.Length];
		floatABATE = SetABATE(variables);
		//PrintFloat(floatABATE); UNCOMMENT THIS TO PRINT floatABATE ARRAY

	// ************************************ COLOR ARRAYS ************************************ //

		byteR = new byte[variables.Length];
		byteR = SetColorR(variables);
		//PrintByte(byteR); UNCOMMENT THIS TO PRINT byteR ARRAY

		byteG = new byte[variables.Length];
		byteG = SetColorG(variables);
		//PrintByte(byteG); UNCOMMENT THIS TO PRINT byteG ARRAY

		byteB = new byte[variables.Length];
		byteB = SetColorB(variables);
		//PrintByte(byteB); UNCOMMENT THIS TO PRINT byteB ARRAY

		byteA = new byte[variables.Length];
		byteA = SetColorA(variables);
		//PrintByte(byteA); UNCOMMENT THIS TO PRINT byteA ARRAY
	}

    /*
     * obtain variables array from TestImport.cs file and sort into each corresponding attributes' array
     * (floatBGE - float array of BGE numbers, byteR - byte array of the R component of the point's color,
     * etc.)
     */
	public string[][] ImportVariables() 
	{
		variables = ti.GetVariables();

		return variables;
	}
		
	// ************************************ SET VARIABLES' ARRAYS ************************************ //

	public float[] SetBGE(string[][] variables)
	{
		for (int i = 0; i < row; i++) // outer loop loops through variables' rows
		{
			string[] innerArray = variables[i];

			for (int j = colBGE; j <= colBGE; j++) // inner loop loops through variables' columns
			{
				string tempStr = innerArray[j];
				float tempFloat = Convert.ToSingle(tempStr); // converts string to float to store in array
                floatBGE[i] = tempFloat;
			}
		}

		return floatBGE;
	}

	public float[] GetBGE() // return floatBGE array from TestSort.cs file
	{
		return floatBGE; // as of now, this array with byteA array is not needed
    }

	public float[] SetDAM(string[][] variables)
	{
		for (int i = 0; i < row; i++) // outer loop loops through variables' rows
		{
			string[] innerArray = variables[i];

			for (int j = colDAM; j <= colDAM; j++) // inner loop loops through variables' columns
			{
				string tempStr = innerArray[j];
				float tempFloat = Convert.ToSingle(tempStr); // converts string to float to store in array
				floatDAM[i] = tempFloat;
			}
		}

		return floatDAM;
	}

	public float[] GetDAM() // return floatDAM array from TestSort.cs file
    {
		return floatDAM;
	}

	public float[] SetPTEMP(string[][] variables)
	{
		for (int i = 0; i < row; i++) // outer loop loops through variables' rows
		{
			string[] innerArray = variables[i];

			for (int j = colPTEMP; j <= colPTEMP; j++) // inner loop loops through variables' columns
			{
				string tempStr = innerArray[j];
				float tempFloat = Convert.ToSingle(tempStr); // converts string to float to store in array
                floatPTEMP[i] = tempFloat;
			}
		}

		return floatPTEMP;
	}

	public float[] GetPTEMP() // return floatPTEMP array from TestSort.cs file
    {
		return floatPTEMP;
	}

	public float[] SetABATE(string[][] variables)
	{
		for (int i = 0; i < row; i++) // outer loop loops through variables' rows
		{
			string[] innerArray = variables[i];

			for (int j = colABATE; j <= colABATE; j++) // inner loop loops through variables' columns
			{
				string tempStr = innerArray[j];
				float tempFloat = Convert.ToSingle(tempStr); // converts string to float to store in array
                floatABATE[i] = tempFloat;
			}
		}

		return floatABATE;
	}

	public float[] GetABATE() // return floatABATE array from TestSort.cs file
    {
		return floatABATE;
	}
		
	// ************************************ COLORS ARRAYS ************************************ //

	public byte[] SetColorR(string[][] variables)
	{
		for (int i = 0; i < row; i++) // outer loop loops through variables' rows
		{
			string[] innerArray = variables[i];

			for (int j = colR; j <= colR; j++) // inner loop loops through variables' columns
			{
				string tempStr = innerArray[j];
				byte tempByte = Convert.ToByte(tempStr);  // converts string to byte to store in array
                byteR[i] = tempByte;
			}
		}

		return byteR;
	}

	public byte[] GetColorR() // return byteR array from TestSort.cs file
    {
		return byteR;
	}

	public byte[] SetColorG(string[][] variables)
	{
		for (int i = 0; i < row; i++) // outer loop loops through variables' rows
		{
			string[] innerArray = variables[i];

			for (int j = colG; j <= colG; j++) // inner loop loops through variables' columns
			{
				string tempStr = innerArray[j];
				byte tempByte = Convert.ToByte(tempStr); // converts string to byte to store in array
                byteG[i] = tempByte;
			}
		}

		return byteG;
	}

	public byte[] GetColorG() // return byteG array from TestSort.cs file
    {
		return byteG;
	}

	public byte[] SetColorB(string[][] variables)
	{
		for (int i = 0; i < row; i++) // outer loop loops through variables' rows
		{
			string[] innerArray = variables[i];

			for (int j = colB; j <= colB; j++) // inner loop loops through variables' columns
			{
				string tempStr = innerArray[j];
				byte tempByte = Convert.ToByte(tempStr); // converts string to byte to store in array
                byteB[i] = tempByte;
			}
		}

		return byteB;
	}

	public byte[] GetColorB() // return byteB array from TestSort.cs file
    {
		return byteB;
	}

	public byte[] SetColorA(string[][] variables)
	{
		for (int i = 0; i < row; i++) // outer loop loops through variables' rows
		{
			string[] innerArray = variables[i];

			for (int j = colA; j <= colA; j++) // inner loop loops through variables' columns
			{
				string tempStr = innerArray[j];
				byte tempByte = Convert.ToByte(tempStr); // converts string to byte to store in array
                byteA[i] = tempByte;
			}
		}

		return byteA;
	}

	public byte[] GetColorA() // return byteA array from TestSort.cs file
    {
		return byteA; // as of now, this array with floatBGE array is not needed
	}


	// ************************************ UNCOMMENT THE PRINT METHODS TO TEST ARRAY METHOD CALLING ************************************ //


	/*
	public void PrintJagged(string[][] variables)
	{
		for (int i = 0; i < variables.Length; i++)
		{
			string[] innerArray = variables[i];

			for (int a = 0; a < innerArray.Length; a++)
			{
				Console.Write(innerArray[a] + " ");
			}

			Console.WriteLine();
		} Console.WriteLine("*******************************************");
	}

	public void PrintFloat(float[] floatArray)
	{
		for (int i = 0; i < floatArray.Length; i++)
		{
			Console.Write(floatArray[i] + " ");
			Console.WriteLine();
		}
		Console.WriteLine("*******************************************");
	}

	public void PrintByte(byte[] byteArray)
	{
		for (int i = 0; i < byteArray.Length; i++)
		{
			Console.Write(byteArray[i] + " ");
			Console.WriteLine();
		}
		Console.WriteLine("*******************************************");
	}
	*/
} // ******************************************************* END OF CLASS!!! ******************************************************* //