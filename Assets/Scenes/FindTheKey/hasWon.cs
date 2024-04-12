using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasWon : MonoBehaviour
{
    public bool haswon = false;
    public bool key = false;

    [SerializeField]
    private Timer timer;

    void Update()
    {
        if(timer.remainingSeconds==0f)
        {
            PlayerStats.LoseMinigame("FindTheKey");
        }    
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "doorSquarePosition")
        {
            key = GetComponent<hasTheKey>().hasthekey;
            if (key)
            {
                haswon = true;
                PlayerStats.WinMinigame("FindTheKey");

            }
        }
    }
}
