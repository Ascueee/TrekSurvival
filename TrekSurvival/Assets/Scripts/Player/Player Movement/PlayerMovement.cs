using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 12f;
    [SerializeField] float jumpHeight = 12f;
    [SerializeField] float jumpRange;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] LayerMask isGround;
    bool grounded;

    Vector3 velocity;



    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //created the move direction based on the x and z coordinates
        Vector3 move = transform.right * x + transform.forward * z;

        //moves and makes it framerate independent
        controller.Move(move * speed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            grounded = false;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

       

    }

    void GroundCheck()
    {
        if(Physics.Raycast(transform.position, Vector3.down, jumpRange, isGround))
        {
            grounded = true;
        }

        if(grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
}
