using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D Rb;
    public SpriteRenderer SR;

    public bool LookingLeft = false;

    public Transform Light;

    public Transform Cam;
  
    Vector2 move;

    private Vector2 movementDirection;

	// Update is called once per frame
	void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 relativePos = touchPos- Rb.position;
            movementDirection = relativePos.normalized;

        }
        else
        {
            movementDirection = Vector2.zero;
        }

        if (movementDirection.x>0)
        {
            LookingLeft = false;
        }
        else if (movementDirection.x<0)
        {
            LookingLeft = true;
        }
    }

	void FixedUpdate()
	{
        Rb.MovePosition(Rb.position + movementDirection* moveSpeed * Time.fixedDeltaTime);
        Light.position = Rb.position;
        Cam.position = Rb.position;
        SR.flipX = LookingLeft;
	}
}
