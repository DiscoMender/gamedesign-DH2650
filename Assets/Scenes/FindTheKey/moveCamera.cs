using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{

    public Transform toFollow;
    public float Speed = 3f;
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(toFollow.position.x, toFollow.position.y,-10f);
        transform.position = newPos;
    }
}
