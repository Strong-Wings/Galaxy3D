using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class spaceshipController : MonoBehaviour
{
    public int index;
    public GameObject laser;
    public GameObject[] spaceships;
    public GameObject explosion;
    public bool exploded = false;
    public int score = 0;
    public float timer = 5.0f;
    public GUIStyle header, headerRight;
    public GUIStyle mystyle;
    public int lives = 1;
    // Start is called before the first frame update
    void Start()
    {
        StreamReader indexdata = new StreamReader (Application.persistentDataPath + "/index.gd");
        index = int.Parse(indexdata.ReadLine());
		indexdata.Close();
        Instantiate(spaceships[index], new Vector3(0f, 0.3f, -8f), spaceships[index].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (exploded) {
            timer -= Time.deltaTime; 
        }
        if (timer < 0) {
            StreamReader balancedata = new StreamReader (Application.persistentDataPath + "/balance.gd");
            int balance = int.Parse(balancedata.ReadLine());
            balancedata.Close();
            StreamWriter balancedataW = new StreamWriter (Application.persistentDataPath + "/balance.gd");
            balancedataW.Write(score + balance);
            balancedataW.Close();
            
            StreamReader recorddata = new StreamReader (Application.persistentDataPath + "/record.gd");
            int record = int.Parse(recorddata.ReadLine());
            recorddata.Close();
            StreamWriter recorddataW = new StreamWriter (Application.persistentDataPath + "/record.gd");
            if (score > record) {
                recorddataW.Write(score);
            } else {
                recorddataW.Write(record);
            }

            recorddataW.Close();
            
            SceneManager.LoadScene("Menu");
        }
    }

    void OnGUI(){
        GUI.Box (new Rect (Screen.width*0f, Screen.height*0f, Screen.width*0.7f, Screen.height*0.1f), "Score: " + score, header);
        if (exploded) {
            GUI.Box (new Rect (Screen.width*0.15f, Screen.height*0.3f, Screen.width*0.7f, Screen.height*0.1f), "GAME OVER", mystyle);
        }
        else
           GUI.Box (new Rect (Screen.width*0f, Screen.height*0f, Screen.width, Screen.height*0.1f), "LIVES: " + lives, headerRight);
    }

}
