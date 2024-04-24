using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirx= Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * 7f, rb.velocity.y);
        if (Input.GetKeyDown("w")){
            rb.velocity = new Vector2(rb.velocity.x, 3.5f);

        }
    }
}
