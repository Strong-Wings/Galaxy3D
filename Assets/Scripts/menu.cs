using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour {
	int index;
	int balance;
	int record;
	public GUIStyle mystyle;
	public GUIStyle header, headerRight;
	public GameObject[] spaceships;
	GameObject ss;
	void Start () 
	{
		if (!System.IO.File.Exists(Application.persistentDataPath + "/index.gd")) {
			StreamWriter balancedata = new StreamWriter (Application.persistentDataPath + "/balance.gd");
            balancedata.Write("0");
            balancedata.Close();
			StreamWriter indexdata = new StreamWriter (Application.persistentDataPath + "/index.gd");
            indexdata.Write("0");
            indexdata.Close();
			StreamWriter shipsdata = new StreamWriter (Application.persistentDataPath + "/ships.gd");
            shipsdata.Write("0");
            shipsdata.Close();
			StreamWriter recorddata = new StreamWriter (Application.persistentDataPath + "/record.gd");
            recorddata.Write("0");
            recorddata.Close();
		}
		
		StreamReader indexdataNew = new StreamReader (Application.persistentDataPath + "/index.gd");
        index = int.Parse(indexdataNew.ReadLine());
		indexdataNew.Close();
		StreamReader balancedataNew = new StreamReader (Application.persistentDataPath + "/balance.gd");
        balance = int.Parse(balancedataNew.ReadLine());
		balancedataNew.Close();
		StreamReader recorddataNew = new StreamReader (Application.persistentDataPath + "/record.gd");
        record = int.Parse(recorddataNew.ReadLine());
		recorddataNew.Close();

		ss = spaceships[index];
		ss.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		ss.transform.position = new Vector3(0f, 0.3f, -7.5f);
		ss.transform.rotation = new Quaternion(0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		StreamReader indexdata = new StreamReader (Application.persistentDataPath + "/index.gd");
        index = int.Parse(indexdata.ReadLine());
		indexdata.Close();
		StreamReader balancedata = new StreamReader (Application.persistentDataPath + "/balance.gd");
        balance = int.Parse(balancedata.ReadLine());
		balancedata.Close();
		StreamReader recorddataNew = new StreamReader (Application.persistentDataPath + "/record.gd");
        record = int.Parse(recorddataNew.ReadLine());
		recorddataNew.Close();

		ss.transform.Rotate(new Vector3(0f, 1f, 0f));
		if (Input.GetMouseButtonDown(0)) 
		{
            float x = Input.mousePosition.x / Screen.width;
            float y = Input.mousePosition.y / Screen.height;
			if (x > 0.33 && x < 0.67 && y > 0.1 && y < 0.38) {
				SceneManager.LoadScene("chooseShip");
			}
        }
	}
	void OnGUI(){
        GUI.Box (new Rect (Screen.width*0f, Screen.height*0f, Screen.width*0.7f, Screen.height*0.1f), "Balance: " + balance, header);
        GUI.Box (new Rect (Screen.width*0f, Screen.height*0f, Screen.width, Screen.height*0.1f), "Record: " + record, headerRight);
		if (GUI.Button (new Rect (Screen.width*0.15f, Screen.height*0.25f, Screen.width*0.7f, Screen.height*0.1f), "START",mystyle)) 
		{
			SceneManager.LoadScene("Main");
		}
		if (GUI.Button (new Rect (Screen.width*0.15f, Screen.height*0.4f, Screen.width*0.7f, Screen.height*0.1f), "EXIT",mystyle)) 
		{
			Application.Quit();
		}
		// if (GUI.Button (new Rect (Screen.width*0.7f, Screen.height*0f, Screen.width*0.4f, Screen.height*0.2f), "CLEAR",mystyle)) 
		// {
		// 	StreamWriter balancedata = new StreamWriter (Application.persistentDataPath + "/balance.gd");
        //     balancedata.Write("0");
        //     balancedata.Close();
		// 	StreamWriter indexdata = new StreamWriter (Application.persistentDataPath + "/index.gd");
        //     indexdata.Write("0");
        //     indexdata.Close();
		// 	StreamWriter shipsdata = new StreamWriter (Application.persistentDataPath + "/ships.gd");
        //     shipsdata.Write("0");
        //     shipsdata.Close();
		// }
	}
}
