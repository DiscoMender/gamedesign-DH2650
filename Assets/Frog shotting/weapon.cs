using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Gun;
    public GameObject bulletPrefab;
    public float interval;
    private float timer;
    // Update is called once per frame
    void Update()
    {
         if(timer!=0){
            timer-=Time.deltaTime;
            if(timer<=0){
                timer=0;
            }
        }
        
        if (Input.GetButtonDown("Fire1")){if(timer<=0){
        shoot();
        timer=interval;  }}
    }
    private void shoot()
    {
        Instantiate(bulletPrefab, Gun.position, Gun.rotation);
    }
}

