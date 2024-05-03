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
    public float goldSpeed;
    // Update is called once per frame
    void Update()
    {
        if(timer!=0){
            timer-=Time.deltaTime;
            if(timer<=0){
                timer=0;
            }
        }
        
        if (Input.GetMouseButton(0)){if(timer<=0){
            Vector2 mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - (Vector2)Gun.position;
        shoot(direction);
        timer=interval;  }}
    }
    private void shoot(Vector2 direction)
    {
        GameObject goldGo=Instantiate(bulletPrefab, Gun.position, Gun.rotation);
        goldGo.GetComponent<Rigidbody2D>().velocity = direction.normalized*goldSpeed;
    }
}

