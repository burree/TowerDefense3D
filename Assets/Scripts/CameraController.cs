using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    // Define the boundaries for camera movement
    public float minX = 0f; // Minimum X boundary
    public float maxX = 70f;  // Maximum X boundary
    public float minZ = -50f; // Minimum Z boundary
    public float maxZ = 50f;  // Maximum Z boundary

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        // Movement controls
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            MoveCamera(Vector3.forward);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            MoveCamera(Vector3.back);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            MoveCamera(Vector3.right);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            MoveCamera(Vector3.left);
        }

        // Scroll to zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    private void MoveCamera(Vector3 direction)
    {
        Vector3 newPosition = transform.position + direction * panSpeed * Time.deltaTime;

        // Clamp the new position within the defined boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        transform.position = newPosition;
    }
}