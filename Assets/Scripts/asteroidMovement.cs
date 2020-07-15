using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMovement : MonoBehaviour
{
    public GameObject explosion;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, 0f, speed);
    }

    void OnTriggerEnter(Collider col) {
        if (col.name == "Laser(Clone)") {
            Instantiate(explosion, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            Destroy(gameObject);
            GameObject.Find("asteroidGenerator").GetComponent<AudioSource>().Play(0);
            Destroy(col.gameObject);
            int coinamount = 1;
            if (name == "DoubleCoins(Clone)") {
                coinamount = 2;
            }
            GameObject.Find("SpaceshipOBJ").GetComponent<spaceshipController>().score += coinamount;
        }
    }
}
