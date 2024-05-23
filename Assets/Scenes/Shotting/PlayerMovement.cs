using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
     private Rigidbody2D rb;
     private Animator anim;
     private SpriteRenderer sprite;
     private Vector2 mouseWorldPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //dirx= Input.GetAxisRaw("Horizontal");
        //diry = Input.GetAxisRaw("Vertical");
        //rb.velocity = new Vector2(dirx * 7f, diry * 7f);
        if (Input.GetMouseButton(0)) // 0代表鼠标左键
        {

            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerPosition = transform.position;
            Vector2 dir = mouseWorldPosition - playerPosition;
            transform.rotation = Quaternion.FromToRotation(Vector2.right,dir);
            rb.velocity = new Vector2(dir.x, dir.y).normalized * 5f; 
            SetBoolRunning(dir);
        }else {rb.velocity = new Vector2(0,0);anim.SetBool("Running", false);}
       
        //if (Input.GetKeyDown("w")){rb.velocity = new Vector2(rb.velocity.x, 3.5f);}
    }
    private void SetBoolRunning(Vector2 dir)
    {
        if (dir.x != 0||dir.y != 0){anim.SetBool("Running", true);}
        else {anim.SetBool("Running", false);}
    }
}
