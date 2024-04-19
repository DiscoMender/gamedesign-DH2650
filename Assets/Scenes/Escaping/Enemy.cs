using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public float enspeed = 5f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Die()
    {
        // play die anime
        animator.SetBool("IsDead", true);

        // disable enemy
        GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        
    }

    void Update()
    {
        // Move the background to the left at a constant speed
        transform.position += Vector3.left * enspeed * Time.deltaTime;
    }
}
