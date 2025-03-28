using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished {get; protected set;}
        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, int textSize, float delay, AudioClip[] sound, float secondsBetweenLines)
        {
            textHolder.color = textColor;
            textHolder.font = textFont;
            textHolder.fontSize = textSize;
            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                if(input[i] != ' '){
                    SoundManager.instance.PlaySound(sound[Random.Range(0,sound.Length)]);
                }
                yield return new WaitForSeconds(delay);
            }
            //yield return new WaitForSeconds(secondsBetweenLines);
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            finished = true;
        }
    }
}
/* Bunu karakter movement script'e eklemem gerekiyor:
	private NPC_Controller npc;

	private void OnTriggerStay2D(Collider2D collision)
	{ // Talks when u enter collision
		if (collision.gameObject.tag == "NPC")
		{
			npc = collision.gameObject.GetComponent<NPC_Controller>();
			if (Input.GetKey(KeyCode.E))
			{

				npc.ActivateDialogue();
			}
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{ // knows hen u exit.
		if (collision.gameObject.tag == "NPC")
		{
			npc = null;
		}
	}
	private bool inDialogue()
	{
		if (npc != null)
		{
			return npc.DialogueActivate();
		}
		else
		{
			return false;
		}
	}
    ve sonra tum movement scriptini bir if statement'a almam gerekiyor 	if (!inDialogue()){} seklinde.
*/