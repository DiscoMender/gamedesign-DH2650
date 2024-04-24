using UnityEngine;
using System.Collections;

public class AzureusEscaping : MonoBehaviour
{

    //[SerializeField] float m_speed = 4.0f;
    [SerializeField] float m_jumpForce = 7.5f;

    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private Sensor_Bandit m_groundSensor;
    private bool m_grounded = false;
    //private bool m_combatIdle = false;
    //private bool m_isDead = false;
    public bool canJump = false;
    public bool dead = false;
    [SerializeField]
    private Timer timer;

    public Transform attarkPoint;
    public float attarkRange = 0.58f;
    public LayerMask enemyLayers;

    public float attackDuration = 0.5f;  // Duration of the attack in seconds


    // Use this for initialization
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();

        timer.isCountDown = false;
    }

    private GameObject lastCollidedObject = null; // Broader scope variable

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        lastCollidedObject = collision.gameObject; // Store the collided object
        if (lastCollidedObject.CompareTag("Hazard"))
        {
            Debug.Log("collision");
            dead = true;
        }
    }

    //IEnumerator Attark()
    void Attark()
    {
        // Play Animation
        m_animator.SetTrigger("Attack");

        // Wait half of the attack duration before detecting enemies
        //yield return new WaitForSeconds(attackDuration / 2);

        // Detact enemies in range of attark
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attarkPoint.position, attarkRange, enemyLayers);

        // Damage them!
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" +  enemy.name);
            enemy.GetComponent<Enemy>().Die();
        }

        // Wait for the second half of the attack duration
        //yield return new WaitForSeconds(attackDuration / 2);
    }

    void OnDrawGizmosSelected()
    {
        if (attarkPoint == null)
            return;
        Gizmos.DrawWireSphere(attarkPoint.position, attarkRange);
    }


    // Update is called once per frame
    void Update()
    {
        // check timer
        if (timer.remainingSeconds <= 0f)
        {
            PlayerStats.WinMinigame("Escaping");
        }

        //Debug.Log(m_grounded);

        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //if (collision.m_body2d.CompareTag("Hazard"))
        //{
        //    dead = true;
        //}

        //transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        if (Input.touchCount > 0 && !dead)
        {
            Touch firstTouch = Input.GetTouch(0);
            if (firstTouch.position.x < Screen.width / 2 && m_grounded)
            {
                //Debug.Log("Left");
                m_animator.SetTrigger("Jump");
                m_grounded = false;
                m_animator.SetBool("Grounded", m_grounded);
                m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
                m_groundSensor.Disable(0.5f);
            }
            else if (firstTouch.position.x >= Screen.width / 2)
            {
                //Debug.Log("Right");
                Attark();
                //StartCoroutine(Attack());
                //m_body2d.velocity = new Vector2(m_jumpForce,m_body2d.velocity.y);
            }
        }

        else if (!dead)
        {
            m_animator.SetInteger("AnimState", 2);
        }

        else
        {
            m_animator.SetTrigger("Death");
            PlayerStats.LoseMinigame("Escaping");
        }

    }
}


//// Update is called once per frame
//void Update () {
//       Debug.Log(m_grounded);

//       //Check if character just landed on the ground
//       if (!m_grounded && m_groundSensor.State()) {
//           m_grounded = true;
//           m_animator.SetBool("Grounded", m_grounded);
//       }

//       //Check if character just started falling
//       if(m_grounded && !m_groundSensor.State()) {
//           m_grounded = false;
//           m_animator.SetBool("Grounded", m_grounded);
//       }

//       // -- Handle input and movement --
//       float inputX = Input.GetAxis("Horizontal");

//       // Swap direction of sprite depending on walk direction
//       if (inputX > 0)
//           transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
//       else if (inputX < 0)
//           transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

//       // Move
//       m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

//       //Set AirSpeed in animator
//       m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

//       // -- Handle Animations --
//       //Death
//       if (Input.GetKeyDown("e")) {
//           if(!m_isDead)
//               m_animator.SetTrigger("Death");
//           else
//               m_animator.SetTrigger("Recover");

//           m_isDead = !m_isDead;
//       }

//       //Hurt
//       else if (Input.GetKeyDown("q"))
//           m_animator.SetTrigger("Hurt");

//       //Attack
//       else if(Input.GetMouseButtonDown(1)) {
//           m_animator.SetTrigger("Attack");
//       }

//       //Change between idle and combat idle
//       else if (Input.GetKeyDown("f"))
//           m_combatIdle = !m_combatIdle;

//       //Jump
//       else if (canJump && m_grounded) {

//           m_animator.SetTrigger("Jump");
//           canJump = false;
//           m_grounded = false;
//           m_animator.SetBool("Grounded", m_grounded);
//           m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
//           m_groundSensor.Disable(0.2f);
//       }

//       //Run
//       else if (Mathf.Abs(inputX) > Mathf.Epsilon)
//           m_animator.SetInteger("AnimState", 2);

//       //Combat Idle
//       else if (m_combatIdle)
//           m_animator.SetInteger("AnimState", 1);

//       //Idle
//       else
//           m_animator.SetInteger("AnimState", 0);
//   }

//   public void Jump()
//   {
//       canJump = true;
//   }
