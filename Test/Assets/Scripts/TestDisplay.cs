using UnityEngine;

public class TestDisplay : MonoBehaviour 
{
	private TestSort ts;
	private int resolution = 2914;
	private ParticleSystem.Particle[] points;

	//float[] floatBGE; // balanced growth equivalent (% reduction from no damages) = not needed now
	float[] floatDAM; // x-axis- total damage (% consumption stream)
	float[] floatPTEMP; // y-axis- reliability of tempurature stabilization (%)
	float[] floatABATE; // z-axis- total abatement cost (% consumption stream)

	byte[] byteR; // red value of point color
	byte[] byteG; // green value of point color
	byte[] byteB; // blue value of point color
	// byte[] byteA; // opacity of point color (between 0=fully transparent and 1=fully opaque) = not needed now

	// Use this for initialization *******************************************************************************************
	void Start () 
	{
		ts = new TestSort();
		ts.ImportVariables ();

		// ******************************* arrays of each variable *******************************

		//floatBGE = ts.GetBGE(); = currently don't need the floatBGE array

		// dam, ptemp, abate arrays used for graph
		floatDAM = ts.GetDAM();
		floatPTEMP = ts.GetPTEMP();
		floatABATE = ts.GetABATE();

		// ****************************** arrays of the RGBA values ******************************
		byteR = ts.GetColorR();
		byteG = ts.GetColorG();
		byteB = ts.GetColorB();
		//byteA = ts.GetColorA();

		CreatePoints (); // calls the CreatePoints() methods in this c# file
	}

    // creates points in the Particle System game object
    // sets the position and size of each point (or index) in an array 
    // according to values in the combined bytes' array (r, g, and b), color of point is determined
	private void CreatePoints () 
	{
		points = new ParticleSystem.Particle[resolution];

		for (int i = 0; i < resolution; i++) 
		{
			points[i].position = new Vector3
				(
					(floatDAM[i]  * 8f), 
					(floatPTEMP[i] * 4f), 
					(floatABATE[i] * 8f)
				);
			points[i].startColor = new Color32
				(
					byteR[i], 
					byteG[i], 
					byteB[i], 
					255 // full opacity
				);
			points[i].startSize = 0.35f;
		}
	}

	void Update () 
	{
        // set the points to their respective positions
		GetComponent<ParticleSystem>().SetParticles(points, points.Length);
	}
} 