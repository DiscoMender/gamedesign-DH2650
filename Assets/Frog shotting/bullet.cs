using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed=20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }
        player player = hitInfo.GetComponent<player>();
        if (player != null)
        {
            player.TakeDamage(1);
        }
        Destroy(gameObject);
    }
}
