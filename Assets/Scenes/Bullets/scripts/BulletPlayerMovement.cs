using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private Timer timer;
    private Vector2 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (timer.remainingSeconds <= 0f)
        {
            PlayerStats.WinMinigame("Bullets");
        }

        if (!controller.isPause && Input.GetMouseButton(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        Vector2 movement = (target - (Vector2)transform.position).normalized;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-10, 10, 10); // Flip horizontally
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(10, 10, 10); // Reset to normal
        }

        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerStats.LoseMinigame("Bullets");
    }
}
