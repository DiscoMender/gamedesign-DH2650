using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    // offset of the sprite to hide
    public Vector2 startPosition = new Vector2(-1.57f, -2.5f);
    public Vector2 endPosition = new Vector2(0.95f, -2.5f);

    // How long it takes to show a mole
    public float showDuration = 0.5f;
    public float duration = 1f;

    private SpriteRenderer spriteRenderer;

    // Mole parameters 
    private bool hittable = true;
    private int lives;


    //private void Awake()
    //{
    //    spriteRenderer = GetComponent<SpriteRenderer>();
    //}

    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        // Make sure we start at the start
        transform.localPosition = start;

        // Show the mole
        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);

            //update at max framerate
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Make sure we're exactly at the end
        transform.localPosition = end;

        // Wait for duration to pass.
        yield return new WaitForSeconds(duration);

        // Hide the mole
        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            //update at max framerate
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Make sure we're exactly back at the start position
        transform.localPosition = start;
    }

    private void Start()
    {
        CreateNext();
        StartCoroutine(ShowHide(startPosition, endPosition));
    }

    private IEnumerator QuickHide()
    {
        yield return new WaitForSeconds(0.25f);
        if (hittable)
        {
            Hide();
        }
    }

    private void Hide()
    {
        // Set the appropriate mole parameters to hide it
        transform.localPosition = startPosition;
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
                    StopAllCoroutines();
                    StartCoroutine(QuickHide());
                    hittable = false;
                }
            }
        }
    }
}
