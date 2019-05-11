using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    float cameraYPos;
    float z = 0.0f;

    public float panBorderThickness = 10f;
    public float vertPanSpeed = 20f;
    public float horiPanSpeed = 15f;

    bool doMovement = false;

    public UIManager uiManager;

    // Use this for initialization
    void Start()
    {
        // Makes sure the camera does not intersect the terrain
        cameraYPos = transform.position.y;

        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
            uiManager.cameraMovementStatus.text = doMovement.ToString();
        }
            
        if (!doMovement)
            return;

        MouseDragMovement();
        KeyboardMovement();
    }

    private void KeyboardMovement()
    {
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * vertPanSpeed * Time.deltaTime);
            Vector3 position = transform.position;
            position.y = cameraYPos;
            transform.position = position;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * vertPanSpeed * Time.deltaTime);
            Vector3 position = transform.position;
            position.y = cameraYPos;
            transform.position = position;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * horiPanSpeed * Time.deltaTime);
            Vector3 position = transform.position;
            position.y = cameraYPos;
            transform.position = position;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * horiPanSpeed * Time.deltaTime);
            Vector3 position = transform.position;
            position.y = cameraYPos;
            transform.position = position;
        }

    }

    private void MouseDragMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit_position = Input.mousePosition;
            camera_position = transform.position;

        }
        if (Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            LeftMouseDrag();
        }
    }

    void LeftMouseDrag()
    {
        // From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
        // with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
        current_position.z = hit_position.z = camera_position.y;

        // Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
        // anyways.  
        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

        // Invert direction to that terrain appears to move with the mouse.
        direction = direction * -1;

        Vector3 position = camera_position + direction;

        position.y = cameraYPos;
        transform.position = position;
    }
}