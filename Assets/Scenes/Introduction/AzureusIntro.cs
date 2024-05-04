using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzureusIntro : MonoBehaviour
{
    private Animator animator;
    public float speed = 5f;
    public Vector3 startPosition = new Vector3(-12f, -0.52f, 0);
    public bool azureusReached = false;

    // Start is called before the first frame update
    void Start()
    {
        // initialize
        animator = GetComponent<Animator>();

        // set start position
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // run until reach the desired position(x = -3,y = -0.52)
        // run animator is set automatically at the start
        
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Debug.Log(transform.position.x);

        // stay idle
        if (transform.position.x >= -3f)
        {
            // play idle animation
            animator.SetTrigger("Idle");
            azureusReached = true; // Set the flag to true when target is reached
            enabled = false;
        }
    }
}
