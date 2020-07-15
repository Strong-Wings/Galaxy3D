using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBuffGenerator : MonoBehaviour
{
	public GameObject buff;
	float x,y,timer;
	float timerespawn=5f;
	public float data;


	void Start () 
	{
		timer = timerespawn * 3;
	}
		
	void Update () 
	{
		timer = timer-Time.deltaTime;
		if (timer < 0)
		{
			x = Random.Range (-2f, 2f);
			y = Random.Range (0f, 2f); 	
			Instantiate(buff, new Vector3(x, y, 24f), transform.rotation);
			timer = Random.Range(timerespawn - 1f, timerespawn + 1f);
		}
	}
}