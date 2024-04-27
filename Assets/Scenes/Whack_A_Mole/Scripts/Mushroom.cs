using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    // offset of the sprite to hide
    public Vector2 startPosition = new Vector2(0f, 0f);
    public Vector2 endPosition = new Vector2(0f, 1.71f);

    // How long it takes to show a mole
    public float showDuration = 0.5f;
    public float duration = 1f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private BoxCollider2D boxCollider2D;
    private Vector2 boxOffset;
    private Vector2 boxSize;
    private Vector2 boxOffsetHidden;
    private Vector2 boxSizeHidden;

    // Mole parameters 
    private bool hittable = true;
    private int lives;


    private void Awake()
    {
        // get references
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        // collider values
        boxOffset = boxCollider2D.offset;
        boxSize = boxCollider2D.size;
        boxOffsetHidden = new Vector2(boxOffset.x, -startPosition.y / 2f + 0.22f); // -startPosition.y / 2f);
        boxSizeHidden = new Vector2(boxSize.x, 0f);
    }

    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        // Make sure we start at the start
        transform.localPosition = start;

        // Show the mole
        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            boxCollider2D.offset = Vector2.Lerp(boxOffsetHidden, boxOffset, elapsed / showDuration);
            boxCollider2D.size = Vector2.Lerp(boxSizeHidden, boxSize, elapsed / showDuration);
            //update at max framerate
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Make sure we're exactly at the end
        transform.localPosition = end;
        boxCollider2D.offset = boxOffset;
        boxCollider2D.size = boxSize;

        // Wait for duration to pass.
        yield return new WaitForSeconds(duration);

        // Hide the mole
        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            boxCollider2D.offset = Vector2.Lerp(boxOffset, boxOffsetHidden, elapsed / showDuration);
            boxCollider2D.size = Vector2.Lerp(boxSize, boxSizeHidden, elapsed / showDuration);

            //update at max framerate
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Make sure we're exactly back at the start position
        transform.localPosition = start;
        boxCollider2D.offset = boxOffsetHidden;
        boxCollider2D.size = boxSizeHidden;
    }

    private void Start()
    {
        CreateNext();
        StartCoroutine(ShowHide(startPosition, endPosition));
    }

    private IEnumerator QuickHide()
    {
        yield return new WaitForSeconds(0.25f);
        Debug.Log("QuickHide");
        if (!hittable)
        {
            Hide();
        }
    }

    private void Hide()
    {
        // Set the appropriate mole parameters to hide it
        transform.localPosition = startPosition;
        Debug.Log("Hide");
        boxCollider2D.offset = boxOffsetHidden;
        boxCollider2D.size = boxSizeHidden;
    }

    private void CreateNext()
    {
        //float random = random.Range(0f,1f);
        // No monster need to be hit twice by now
        lives = 1;
        hittable = true;
    }

    //private void OnMouseDwon()
    //{
    //    if(hittable)
    //    {
    //        StopAllCoroutines();
    //        StartCoroutine(QuickHide());
    //        hittable = false; 
    //    }
    //}

    void Update()
    {
        if (Input.touchCount > 0) // Once screen is touched
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0); 

            // Convert the touch position from screen to world coordinates
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began) // Detect the start of a touch
            {

                // Check if the touch position is within the collider of this GameObject
                Collider2D collider = GetComponent<Collider2D>();

                if (collider != null && collider.OverlapPoint(touchPosition))
                {
                    Debug.Log("Touched!");
                    animator.SetTrigger("Death");
                    StopAllCoroutines();
                    StartCoroutine(QuickHide());
                    hittable = false;
                }
            }
        }
    }
}
