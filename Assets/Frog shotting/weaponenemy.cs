using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponenemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Gun;
    public GameObject bulletPrefab;
    public float interval;
    private float timer;
    // Update is called once per frame
    void Start()
    {
        Flip();
    }
    void Update()
    {   
        if(timer!=0){
            timer-=Time.deltaTime;
            if(timer<=0){
                timer=0;
            }
        }
        if (true){
            if(timer<=0){
            shoot();  
            timer=interval;  
            }
        }
    }
    void shoot()
    {
        
        if (timer==0){
        Instantiate(bulletPrefab, Gun.position, Gun.rotation);}



    }
    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}

