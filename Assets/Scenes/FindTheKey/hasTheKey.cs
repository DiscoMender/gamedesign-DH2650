using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasTheKey : MonoBehaviour
{
    public Grid door;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "key")
        {
            Destroy(collisionInfo.collider);
            Destroy(door);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
