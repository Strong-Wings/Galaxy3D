using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipActivity : MonoBehaviour
{
    GameObject explosion;
    AudioSource audioExplosure;
    AudioSource laserSound;
    GameObject laser;
    int score;        
    int index;    
    bool exploded;
    float startX, startY, spaceX, spaceY;
    float laserTimer = 0.5f, boostTimer = 0f, speedBoostTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {   
        transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);  
        if (name == "ExtraLife(Clone)")
            GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().lives = 2;
    }

    // Update is called once per frame
    void Update()
    {
        explosion = GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().explosion;
        score = GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().score;
        index = GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().index;
        exploded = GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().exploded;
        laser = GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().laser;
        audioExplosure = GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().GetComponent<AudioSource>();
        laserSound = GameObject.Find("LaserObject").GetComponent<AudioSource>();

        if (Input.GetMouseButtonDown(0)) {
            startX = (Input.mousePosition.x / Screen.width - 0.5f) * 2;
            startY = (Input.mousePosition.y / Screen.height - 0.5f) * 2;

            spaceX = transform.position.x;
            spaceY = transform.position.y;
        }

        if (Input.GetMouseButton(0))
		{
            float x = (Input.mousePosition.x / Screen.width - 0.5f) * 2 - startX;
            float y = (Input.mousePosition.y / Screen.height - 0.5f) * 2 - startY;
            transform.position = new Vector3(spaceX + x * 1.8f, spaceY + y, transform.position.z);

            if (transform.position.x > 1.8) {
                transform.position = new Vector3(1.8f, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -1.8) {
                transform.position = new Vector3(-1.8f, transform.position.y, transform.position.z);
            }
            if (transform.position.y < 0) {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
            else if (transform.position.y > 2) {
                transform.position = new Vector3(transform.position.x, 2, transform.position.z);
            }
        }

        if (laserTimer < 0f && !exploded) {
            Instantiate(laser, transform.position, laser.transform.rotation);
            laserTimer = 0.5f;
            laserSound.Play(0);
        }
        if (boostTimer > 0f || name == "Immortal(Clone)")
            laserTimer -= Time.deltaTime; 
        boostTimer -= Time.deltaTime;
  
        if (speedBoostTimer < 0f)
                GameObject.Find("Asteroid").GetComponent<asteroidMovement>().speed = 0.1f;
        speedBoostTimer -= Time.deltaTime;
    }
    
    void OnTriggerEnter(Collider col) {
        if (!exploded) {
            if (col.name == "Asteroid(Clone)") {
                if (GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().lives == 1) {
                    GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().exploded = true;
                    transform.localScale = new Vector3(0, 0, 0);
                    audioExplosure.Play(0);
                }
                Instantiate(explosion, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
                GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().lives--;
            }
            else if (col.name == "GoldCoin(Clone)") {
                Destroy(col.gameObject);
                GameObject.Find("coinGeneratorObject").GetComponent<AudioSource>().Play(0);
                int coinamount = 1;
                if (name == "DoubleCoins(Clone)") {
                    coinamount = 2;
                }
                GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().score += coinamount;
            }
            else if (col.name == "Buff(Clone)") {
                Destroy(col.gameObject);
                GameObject.Find("buffGeneratorObject").GetComponent<AudioSource>().Play(0);
                boostTimer = 10f;
            }
            else if (col.name == "SpeedBuff(Clone)") {
                Destroy(col.gameObject);
                GameObject.Find("buffGeneratorObject").GetComponent<AudioSource>().Play(0);
                GameObject.Find("Asteroid").GetComponent<asteroidMovement>().speed = 1f;
                speedBoostTimer = 10f;
            }
        }

        
    }
}
