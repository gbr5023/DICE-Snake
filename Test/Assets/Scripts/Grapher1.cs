using UnityEngine;

public class Grapher1 : MonoBehaviour 
{
	private int resolution = 2914;
	private ParticleSystem.Particle[] points;

	void Start()
	{
		CreatePoints ();
	}

	private void CreatePoints () 
	{
		points = new ParticleSystem.Particle[resolution];
		float increment = 1f / (resolution - 1);
		for (int i = 0; i < resolution; i++) {
			float x = i * increment;
			points[i].position = new Vector3(x, 0f, 0f);
			points[i].startColor = new Color(x, 0f, 0f);
			points[i].startSize = 0.1f;
		}
	}

	void Update () 
	{
		for (int i = 0; i < resolution; i++) {
			Vector3 p = points[i].position;
			p.y = p.x;
			points[i].position = p;
			Color c = points[i].startColor;
			c.g = p.y;
			points[i].startColor = c;
		}
		GetComponent<ParticleSystem>().SetParticles(points, points.Length);
	}
}