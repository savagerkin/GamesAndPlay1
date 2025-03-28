using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        [Header("Text Options")]

        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;
        private Text textHolder;
        [SerializeField] private string input;
        [SerializeField] private int textSize;
        [Header("Time")]
        [SerializeField] private float delay;
        [SerializeField] private float secondsBetweenLines;
        [Header("Sound")]
        [SerializeField] private AudioClip[] sound;
        [Header("Images")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;


        private IEnumerator lineAppear;
        private void Awake()
        {
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }
        private void OnEnable()
        {
            ResetLine();
            lineAppear = WriteText(input, textHolder, textColor, textFont, textSize, delay, sound, secondsBetweenLines);
            StartCoroutine(lineAppear);

        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textHolder.text != input)
                {
                    StopCoroutine(lineAppear);
                    textHolder.text = input;

                }
                else
                {
                    finished = true;
                }
            }
        }
        private void ResetLine()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            finished = false;
        }
    }

}

