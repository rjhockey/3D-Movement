using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // horizontal and vertical movement variables
    public float speed = 5.0f;
    public float horizontalInput;
    public float forwardInput;

    // jump variables
    public float jumpForce = 5.0f;
    private Rigidbody playerRb;
    public bool isOnGround = true; // to prevent additive jumping

    private void Start()
    {
        // access the player rigidbody
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // move the player forward

        // alters z position
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // alters x position
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // player jump
        // isOnGround & onColl... below prevents additive jumping...remove to fly or swim
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // add Ground tag to ground plane
        {
            isOnGround = true;
        }
    }
}
