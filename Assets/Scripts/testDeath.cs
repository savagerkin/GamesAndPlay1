using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDeath : MonoBehaviour
{

    public Level_Manager level_manager;

    // Start is called before the first frame update
    void Start()
    {
        level_manager = FindObjectOfType<Level_Manager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player")
        {
            level_manager.RespawnPlayer();
            Debug.Log(("Death") + transform.position);
        }
    }
}
