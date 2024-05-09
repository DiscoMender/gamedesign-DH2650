using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaylanIntro : MonoBehaviour
{
    private Animator animator;
    public float speed = 5f;
    public Vector3 startPosition = new Vector3(-12f, -0.23f, 0);
    public bool raylanReached = false;
    public bool finishConversation = false;
    public bool goNextScene = false;

    // Start is called before the first frame update
    void Start()
    {
        // initialize
        animator = GetComponent<Animator>();

        // set start position
        transform.position = startPosition;
    }

    //private GameObject lastCollidedObject = null; // Broader scope variable

    //void OnCollisionEnter2D(Collision2D collision)
    //{

    //    lastCollidedObject = collision.gameObject; // Store the collided object
    //    if (lastCollidedObject.CompareTag("Lightbean"))
    //    {
    //        Debug.Log("Reach light bean");
    //        goNextScene = true;
    //        enabled = false;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (!raylanReached) // || !finishConversation)
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
                raylanReached = true; // Set the flag to true when target is reached
            }
        }

        if (finishConversation)
        {
            // Move again towards the light bean
            animator.SetTrigger("Walk");
            transform.position += Vector3.right * speed * Time.deltaTime;
            
        }
    }
}
