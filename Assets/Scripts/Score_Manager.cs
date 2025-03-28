using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Manager : MonoBehaviour
{
    public static int score;

    TMP_Text text; // Use TMP_Text instead of Text

    void Start()
    {
        text = GetComponent<TMP_Text>(); // Use GetComponent<TMP_Text>() instead of GetComponent<Text>()
        score = 0;
    }

    void Update()
    {
        if (score < 0)
            score = 0;
        text.text = "" + score;
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public static void Reset()
    {
        score = 0;
    }
}