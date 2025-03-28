using UnityEngine;
using UnityEngine.UI;

public class LevelSelection: MonoBehaviour
{
    public Button[] levelButtons; // Reference to the buttons representing each level
    public Image[] levelBackgrounds; // Reference to the images representing each level's background
    public Image[] lockImages; // Reference to the lock images for each level

    private void Start()
    {
        // Initially, all levels are locked except the first one.
        for (int i = 1; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false; // Disable the button for locked levels
            lockImages[i].enabled = true; // Show the lock image for locked levels
        }
    }

    // Call this method to unlock a level and tint the background to red.
    public void UnlockLevel(int levelIndex)
    {
        if (levelIndex >= 1 && levelIndex < levelButtons.Length)
        {
            levelButtons[levelIndex].interactable = true; // Enable the button for the unlocked level
            lockImages[levelIndex].enabled = false; // Hide the lock image
            levelBackgrounds[levelIndex - 1].color = Color.red; // Tint the background to red
        }
    }
}