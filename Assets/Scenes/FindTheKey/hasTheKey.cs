using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasTheKey : MonoBehaviour
{
    public Grid door;
    public bool hasthekey = false;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "key")
        {
            hasthekey = true;
            Destroy(collisionInfo.collider);
            door.gameObject.SetActive(false);
        }
    }
}
