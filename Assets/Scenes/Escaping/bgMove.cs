using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMove : MonoBehaviour
{
    public float bgspeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the background to the left at a constant speed
        transform.position += Vector3.left * bgspeed * Time.deltaTime;
    }
}
