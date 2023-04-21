using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Score
    [Header("Score")]

    public int ScoreNumber;

    [Space]

    public float ScoreMultiplier;
    //Score

    //Height
    [Header("Height")]

    public float MaxHeight;

    [Space]

    public Transform PlayerPosition;
    //Height

    //User Interface
    [Header("User Interface")]

    public Text ScoreText;
    //User Interface
    
    //Save
    [Header("Save")]

    public Save SaveItem;
    //Save

    private void Start()
    {
        ScoreText.text = "" + 666;
    }

    /*
    void Update()
    {
        if (PlayerPosition.position.y > MaxHeight)
        {
            MaxHeight = PlayerPosition.position.y;

            ScoreNumber = (int)(MaxHeight * ScoreMultiplier);

            ScoreText.text = "" + ScoreNumber;
        }
    }
    */

    public void SaveMaxScore()
    {
        if (SaveItem.MaxScore < ScoreNumber)
        {
            SaveItem.MaxScore = ScoreNumber;
        }
    }
}
