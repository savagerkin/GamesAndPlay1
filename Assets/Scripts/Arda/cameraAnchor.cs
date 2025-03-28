using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAnchor : MonoBehaviour
{

    public CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "player")
        {
            cameraController.currentAnchor = gameObject;
        }
    }

}