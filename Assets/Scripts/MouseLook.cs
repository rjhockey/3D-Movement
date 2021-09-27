using UnityEngine;

// first person shooter
// attach to main camera -  a child of First person player
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    // head left/right
    public Transform playerBody; // drag first person player onto slot

    // head up/down
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // hide and lock cursor to center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // get player input from mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // player head turns left/right/x plane
        playerBody.Rotate(Vector3.up * mouseX);

        // player head rotates up/down/y plane
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
