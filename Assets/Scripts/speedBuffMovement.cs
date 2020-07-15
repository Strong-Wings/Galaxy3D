using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBuffMovement : MonoBehaviour
{
    float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(90f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, 0f, speed);
    }
}