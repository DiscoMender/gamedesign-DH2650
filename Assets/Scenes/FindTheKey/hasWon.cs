using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasWon : MonoBehaviour
{
    public bool haswon = false;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "doorSquarePosition")
        {
            bool key = GetComponent<hasTheKey>().hasthekey;
            if (key)
            {
                haswon = true;
                Debug.Log("It's a Win!");

            }
        }
    }
}
