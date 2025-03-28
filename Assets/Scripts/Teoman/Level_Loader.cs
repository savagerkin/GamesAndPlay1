using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    public string levelToLoad;

    private bool playerInZone;
	public int currentScene;
	public static bool control = false;

    // Use this for initialization
    void Start()
    {
        playerInZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone)
        {
			if(currentScene == 3){
				if(Score_Manager.score > 1){
					levelToLoad = "LevelSelect";
					CallMeBeforeSwitchingScenes();
				} else {
					levelToLoad = "LevelSelect 1";
				}
			}
			if(currentScene == 6){
				if(control){
                    control = false;
					if(Score_Manager.score > 2){
						levelToLoad = "LevelS2A";
					} else {
						levelToLoad = "LevelS2AC";
					}
				} else {
					if(Score_Manager.score > 2){
						levelToLoad = "LevelS2AB";
					} else {
						levelToLoad = "LevelS2";
					}					
                }
			}
            SceneManager.LoadScene(levelToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player")
        {
            playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "player")
        {
            playerInZone = false;
        }
    }

    private void CallMeBeforeSwitchingScenes()
    {
          control = true;
    }
}