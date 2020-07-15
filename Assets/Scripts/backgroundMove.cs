using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMove : MonoBehaviour
{
    float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.localScale += new Vector3(speed, speed, 0f);
        transform.Rotate(new Vector3(0f, 0f, speed * 30f));
    }
}
