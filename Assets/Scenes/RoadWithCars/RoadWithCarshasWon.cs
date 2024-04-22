using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadWithCarsHasWon : MonoBehaviour
{
    [SerializeField] private Timer timer;
    void Update()
    {
        if (timer.remainingSeconds == 0f)
        {
            PlayerStats.WinMinigame("RoadWithCars");
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "car(Clone)")
        {
            PlayerStats.LoseMinigame("RoadWithCars");
        } 
    }
}
