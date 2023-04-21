using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManagment : MonoBehaviour
{
    //User Interface
    [Header("User Interface")]

    public Text ScoreText;
    //User Interface

    //Save
    [Header("Save")]

    public Save SaveItem;
    //Save

    void Start()
    {
        ScoreText.text = "" + SaveItem.MaxScore;
    }
    
    //Buttons
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    //Buttons
}
