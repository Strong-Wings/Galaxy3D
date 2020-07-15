using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class generator : MonoBehaviour {

	public GameObject asteroid;
	float x,y,timer;
	float timerespawn=0.05f;
	bool trigtime=false;
	public int score;
	public float data;


	void Start () 
	{
        score = 0;
		timer = timerespawn;
	}
		
	void Update () 
	{
		if (timer==timerespawn)
		{
			x = Random.Range (-5f, 5f);
			y = Random.Range (-1.5f, 3.5f);
			Instantiate(asteroid, new Vector3(x, y, 24f), transform.rotation);
			trigtime = true;
		}
		if (trigtime==true)
		{
			timer = timer-Time.deltaTime;
		}
		if (timer < 0)
		{
			timer = timerespawn;
			trigtime = false;
		}
	}
}