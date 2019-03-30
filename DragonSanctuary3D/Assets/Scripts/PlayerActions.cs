using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    RaycastHit hit;
    float checkDistance;


    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        Camera camera = GetComponentInChildren<Camera>();

        // When the user presses the E key.
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact(camera);
        } 
    }



    void Interact(Camera camera)
    {

        checkDistance = 3f;

        // Sends a raycast outward, where the player is facing.
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            

            // If the colliding object is less than 2.5 units away...
            if (hit.distance <= checkDistance)
            {
                Debug.Log(hit.collider.name);
                Debug.Log("Something in range.");
            }
        }
    }
}