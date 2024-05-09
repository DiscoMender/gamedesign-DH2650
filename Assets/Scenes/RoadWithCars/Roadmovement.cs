using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 6f;

    public Rigidbody2D Rb;
    public SpriteRenderer SR;

    public bool LookingLeft = false;

    private float speed;
    public Animator animator;

    private Vector2 relativePos;

    Vector2 move;

    private Vector2 movementDirection;

	void Update()
    {
        if (!controller.isPause)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                relativePos = touchPos - Rb.position;
                movementDirection = relativePos.normalized;

            }
            else
            {
                movementDirection = Vector2.zero;
            }

            if (movementDirection.x > 0)
            {
                LookingLeft = false;
            }
            else if (movementDirection.x < 0)
            {
                LookingLeft = true;
            }
        }
    }

	void FixedUpdate()
	{
        speed = movementDirection.magnitude * moveSpeed;
        animator.SetFloat("Speed", speed);
        
        if (relativePos.magnitude > 0.2)
        {
            Rb.MovePosition(Rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
            SR.flipX = LookingLeft;
        }
        
	}
}
