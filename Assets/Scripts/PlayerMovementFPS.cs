using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add to FirstPersonPlayer
// jump doesn't work b/c isGrounded = Physics...wont return true, assume colliders
// are not touching 

public class PlayerMovementFPS : MonoBehaviour
{
    public CharacterController controller; // drag FirstPersonPlayer onto

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck; // drag Ground Check onto slot
    public float groundDistance = 0.4f;
    public LayerMask groundMask; // choose the ground layer

    Vector3 velocity;
    bool isGrounded; // to check if player is grounded
    
    // Update is called once per frame
    void Update()
    {
        // check to see if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // obtain player input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // player movement based on movement and direction player is facing
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // add gravity with increasing velocity
        velocity.y += gravity * Time.deltaTime;

        // add velocity to player
        controller.Move(velocity * Time.deltaTime);
    }
}
