using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;
public class chooseSpaceship : MonoBehaviour
{
    public GUIStyle arrowstyle;
    public GUIStyle midstyle;
    public GUIStyle midstyleBIG;
	public GUIStyle header;
    public GameObject[] spaceships;
    int index = 0;
    bool moveRight = false;
    bool moveLeft = false;
    float distance = 2.5f;
    float moved = 0f;
    int balance;
    string[] ships;
    // Start is called before the first frame update
    void Start()
    {
        StreamReader indexdata = new StreamReader (Application.persistentDataPath + "/index.gd");
        index = int.Parse(indexdata.ReadLine());
		indexdata.Close();
        float delta = - index * distance;
        foreach (GameObject ship in spaceships) {
            ship.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            ship.transform.position = new Vector3(0f + delta, 1f, -7.5f);
            ship.transform.rotation = new Quaternion(0, 0, 0, 0);
            delta += distance;
        }

        StreamReader shipsdata = new StreamReader (Application.persistentDataPath + "/ships.gd");
        ships = shipsdata.ReadLine().Split(' ');
		shipsdata.Close();
        StreamReader balancedata = new StreamReader (Application.persistentDataPath + "/balance.gd");
        balance = int.Parse(balancedata.ReadLine());
		balancedata.Close();
    }

    // Update is called once per frame
    void Update()
    {
        StreamReader shipsdata = new StreamReader (Application.persistentDataPath + "/ships.gd");
        ships = shipsdata.ReadLine().Split(' ');
		shipsdata.Close();
        StreamReader balancedata = new StreamReader (Application.persistentDataPath + "/balance.gd");
        balance = int.Parse(balancedata.ReadLine());
		balancedata.Close();

        foreach (GameObject ship in spaceships) {
            ship.transform.Rotate(new Vector3(0f, 1f, 0f));
        }
        if (Input.GetMouseButtonDown(0))
		{
            float x = Input.mousePosition.x / Screen.width;
            float y = Input.mousePosition.y / Screen.height;
			if (x > 0.33 && x < 0.67 && y > 0.4 && y < 0.6 && ships.Contains(index.ToString())) {
                StreamWriter indexdata = new StreamWriter (Application.persistentDataPath + "/index.gd");
                indexdata.Write(index);
                indexdata.Close();
				SceneManager.LoadScene("Menu");
			}
        }

        if (moveLeft) {
            if (moved < distance) {
                foreach (GameObject ship in spaceships) {
                    ship.transform.position += new Vector3(distance / 50, 0f, 0f);
                }
                moved += distance / 50;
            }
            else
                moveLeft = false;
        }
        if (moveRight) {
            if (moved < distance) {
                foreach (GameObject ship in spaceships) {
                    ship.transform.position -= new Vector3(distance / 50, 0f, 0f);
                }
                moved += distance / 50;
            }
            else
                moveRight = false;
        }
    }
    
    void OnGUI() {
        GUI.Box (new Rect (Screen.width*0f, Screen.height*0f, Screen.width*0.7f, Screen.height*0.1f), "Balance: " + balance, header);
        Rect left = new Rect (Screen.width*0.05f, Screen.height*0.75f, Screen.width*0.2f, Screen.height*0.2f);
        Rect right = new Rect (Screen.width*0.9f, Screen.height*0.75f, Screen.width*0.2f, Screen.height*0.2f);
		
        if (index == 1) {
            GUI.Box (new Rect (Screen.width*0f, Screen.height*0.2f, Screen.width, Screen.height*0.2f), "Double Coins", midstyle);
        }
        else if (index == 2) {
            GUI.Box (new Rect (Screen.width*0f, Screen.height*0.2f, Screen.width, Screen.height*0.2f), "Extra Life", midstyle);
        }
        else if (index == 3) {
            GUI.Box (new Rect (Screen.width*0f, Screen.height*0.2f, Screen.width, Screen.height*0.2f), "Always shoots", midstyle);
        }

        if (index == 0) {
            left.position = new Vector2(-100f, -100f);
        } else if (index == spaceships.Length - 1) {
            right.position = new Vector2(-100f, -100f);
        }
        
        if (!ships.Contains(index.ToString())) {
            GUI.Box (new Rect (Screen.width*0, Screen.height*0.4f, Screen.width, Screen.height*0.2f), "LOCKED", midstyle);
            if (GUI.Button(new Rect (Screen.width*0.4f, Screen.height*0.75f, Screen.width*0.4f, Screen.height*0.2f), "BUY: " + index * 50, midstyleBIG) && balance >= index * 50) 
            {
                StreamWriter shipsdata = new StreamWriter (Application.persistentDataPath + "/ships.gd");
                shipsdata.Write(string.Join(" ", ships) + " " + index);
                Debug.Log(string.Join("", ships) + " " + index);
                shipsdata.Close();
                StreamWriter balancedata = new StreamWriter (Application.persistentDataPath + "/balance.gd");
                balancedata.Write(balance - index * 50);
                balancedata.Close();
            }
        }

        if (!moveLeft && !moveRight) {
            if (GUI.Button(left, "←", arrowstyle)) 
            {
                index--;
                moved = 0f;
                moveLeft = true;
            }
            else if (GUI.Button (right, "→", arrowstyle)) 
            {
                index++;
                moved = 0f;
                moveRight = true;
            }
        }
	}
}
