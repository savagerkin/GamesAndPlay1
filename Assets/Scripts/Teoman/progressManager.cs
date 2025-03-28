using UnityEngine;

public class progressManager : MonoBehaviour
{
    public static progressManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsLevelUnlocked(int levelIndex)
    {
        // Check if the level is unlocked based on your criteria (e.g., by index)
        return PlayerPrefs.GetInt("Level" + levelIndex, 0) == 1;
    }

    public void UnlockLevel(int levelIndex)
    {
        // Unlock a level by setting the PlayerPrefs flag
        PlayerPrefs.SetInt("Level" + levelIndex, 1);
    }
}
