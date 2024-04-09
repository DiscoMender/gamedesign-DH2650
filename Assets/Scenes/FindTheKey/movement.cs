using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 8f;

    public Rigidbody2D Rb;
    public SpriteRenderer SR;

    public bool LookingLeft = false;

    public Transform Light;

    public Transform Cam;
  
    Vector2 move;

	// Update is called once per frame
	void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");


        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            LookingLeft = false;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            LookingLeft = true;
        }
    }

	void FixedUpdate()
	{
        Rb.MovePosition(Rb.position + move * moveSpeed * Time.fixedDeltaTime);
        Light.position = Rb.position;
        Cam.position = Rb.position;
        SR.flipX = LookingLeft;
	}
}
