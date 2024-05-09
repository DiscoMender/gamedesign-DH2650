using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findTheKeyMovement : MonoBehaviour
{
    public float moveSpeed = 6f;

    public Rigidbody2D Rb;
    public SpriteRenderer SR;

    public Camera cam;

    public bool LookingLeft = false;

    private float speed;
    public Animator animator;

    private Vector2 relativePos;

    private Vector2 movementDirection;

    // Update is called once per frame
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
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);

        if (relativePos.magnitude > 0.2)
        {
            Rb.MovePosition(Rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
            SR.flipX = LookingLeft;
            cam.transform.position = new Vector3(Rb.position.x, Rb.position.y, -10f);
        }

    }
}
