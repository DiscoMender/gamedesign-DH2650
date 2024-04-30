using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicialConditions : MonoBehaviour
{
    [SerializeField] private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer.isCountDown = false;
    }

  
}
