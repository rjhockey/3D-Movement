// add to Camera to follow the player
// camera position -1.4, -.37, -10.5, rot 0,0,180 muck with y to show 3d
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform characterPosition; // drag player onto slot

    // Update is called once per frame
    void Update()
    {
        // camera follows the player position
        transform.position = new Vector3(characterPosition.position.x, transform.position.y, transform.position.z);
    }
}
