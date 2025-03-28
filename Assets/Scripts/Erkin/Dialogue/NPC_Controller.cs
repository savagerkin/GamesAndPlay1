using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject e_Box;
    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
    }
    public void CloseDialogueBoxE()
    {
        e_Box.SetActive(false);
    }
    public void ActivateDialogueBoxE()
    {
        e_Box.SetActive(true);
    }
    public bool DialogueActivate()
    {
        return dialogue.activeInHierarchy;
    }

}
