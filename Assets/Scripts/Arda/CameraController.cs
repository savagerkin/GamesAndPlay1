using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Reference to the player character.
    public GameObject currentAnchor; // List of anchor points.

    public float anchorMultiplier = 1f;
    public float playerMultiplier = 1f;
    public float maxDistance = 1f;
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement.
    public Vector3 offset; // Offset between camera and player.

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Calculate the position between the player and the current anchor point.
        Vector3 targetPosition = (playerMultiplier*player.transform.position + anchorMultiplier*currentAnchor.transform.position) / (playerMultiplier + anchorMultiplier);
        targetPosition += offset;

        // Smoothly move the camera towards the target position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Check the distance between the camera and the current anchor point.
        float distanceToAnchor = Vector3.Distance(transform.position, currentAnchor.transform.position);

        // If the camera is too far from the current anchor point, switch to the next one.
      
    }
}
