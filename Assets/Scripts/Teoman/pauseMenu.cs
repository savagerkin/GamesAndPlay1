using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

	public string mainMenu;

	public string Levels;

    public bool isPAuse;

    public GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update() {
        if (isPAuse)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            isPAuse = !isPAuse;
        }
	}

    public void Resume()
    {
        isPAuse = false;
    }
    public void Selectlevel()
    {
        SceneManager.LoadScene(Levels);

    }
    public void Quit()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
