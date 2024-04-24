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
        StartCoroutine(ShowHide(startPosition, endPosition));
    }
}
