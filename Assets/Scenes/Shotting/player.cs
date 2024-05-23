using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 3;
    public Timer timer;
    public void Start(){
        timer=GameObject.Find("Timer").GetComponent<Timer>();
    }
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Update(){
        if(timer.remainingSeconds<=0){
            PlayerStats.LoseMinigame("Shotting");
        }
    }
    // Update is called once per frame
    void Die()
    {
        PlayerStats.LoseMinigame("Shotting");
        //Destroy(gameObject);
    }
    
}
