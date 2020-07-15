using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGenerator : MonoBehaviour {
	public GameObject coin;
	float x,y,timer;
	float timerespawn=4.5f;
	public float data;


	void Start () 
	{
		timer = timerespawn * 2;
	}
		
	void Update () 
	{	
		timer = timer-Time.deltaTime;
		if (timer < 0)
		{
			x = Random.Range (-2f, 2f);
			y = Random.Range (0f, 2f);
            coin.transform.localScale = new Vector3(50f, 50f, 50f);
			Instantiate(coin, new Vector3(x, y, 24f), transform.rotation);
			timer = Random.Range(timerespawn - 1f, timerespawn + 1f);
		}
	}
}