using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadWithBoxesHasWon : MonoBehaviour
{
    [SerializeField] private Timer timer;
    void Update()
    {
        if (timer.remainingSeconds == 0f)
        {
            PlayerStats.WinMinigame("RoadWithBoxes");
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "box(Clone)")
        {
            PlayerStats.LoseMinigame("RoadWithBoxes");
        } 
    }
}
