using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController controller;

    public float speed = 12f;
    private float originalSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 18f;

    //public Transform groundCheck;
    //public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Rigidbody rb;

    //Vector3 velocity;
    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalSpeed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 2);
        /* if(isGrounded && velocity.y < 0)
         {
             velocity.y = -2f;
         }*/

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector3 move = transform.right * x + transform.forward * z;

        //controller.Move(move * speed * Time.deltaTime);

        transform.Translate(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);

        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight);
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = originalSpeed;
        }



        //velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);
    }
}
