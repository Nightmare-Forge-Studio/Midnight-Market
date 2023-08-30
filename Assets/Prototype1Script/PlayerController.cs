using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 10.0f;
    public float jumpHeight;
    public Transform orientation;
    private float defaultSpeed;
    void Start()
    {
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

        if (Input.GetButton("Jump"))
        {
            transform.Translate(0, jumpHeight * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 12.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = defaultSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            gameObject.layer = default;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            gameObject.layer = 3;
        }


    }
}
