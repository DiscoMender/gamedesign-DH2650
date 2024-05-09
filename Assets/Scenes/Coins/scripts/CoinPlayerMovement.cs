using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private Timer timer;
    private Vector2 target;
    private CoinCounter coinCounter;
    private RubyCounter rubyCounter;

    void Start()
    {
        target = transform.position;
        coinCounter = CoinCounter.instance;
        rubyCounter = RubyCounter.instance;
    }

    void Update()
    {

        if (timer.remainingSeconds <= 0f)
        {
            PlayerStats.LoseMinigame("Coins");
        }

        if (coinCounter.currentCoins >= 15 && rubyCounter.currentRubies >= 5)
        {
            PlayerStats.WinMinigame("Coins");
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
}
