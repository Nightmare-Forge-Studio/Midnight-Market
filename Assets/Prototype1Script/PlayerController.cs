using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 10.0f;
    public float jumpHeight;
    public Transform orientation;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float radCircle;
    private float defaultSpeed;
    public bool isGrounded;
    private Rigidbody player;
    public int maxHealth = 3;
    
    private bool isOn = true;
    public float stamina = 100;
    void Start()
    {
        player = GetComponent<Rigidbody>();
         defaultSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        
        transform.Translate(moveX,0,0);
        transform.Translate(0,0,moveZ);
        gameObject.transform.rotation = orientation.transform.rotation;
        isGrounded = Physics.CheckSphere(groundCheck.position, radCircle, whatIsGround);

        if (Input.GetButton("Jump") && isGrounded)
        {
            player.velocity = new Vector3(player.velocity.z,jumpHeight);
            //transform.Translate(0, jumpHeight * Time.deltaTime, 0);
            
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += (speed * 20/100);
            stamina -= 10 * Time.deltaTime;
            Debug.Log(speed);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            DepleteStamina(10.0f);
            speed = defaultSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed -= (speed * 50/100);
            gameObject.layer = default;
            Debug.Log(speed);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = defaultSpeed;
            gameObject.layer = 3;
        }

        
    }

    private void DepleteStamina(float amount)
    {
        stamina -= amount;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, radCircle);

    }
    public void TakeDamage()
    {
        maxHealth -= 1;
    }
}
