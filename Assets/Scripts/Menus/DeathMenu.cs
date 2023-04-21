using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    //Player Data
    [Header("Player Data")]

    public GameObject Player;

    [Space]

    public Score Score;
    //Player Data

    //Death Menu
    [Header("Death Menu")]

    public GameObject DeathMenuPanel;
    //Death Menu

    public void Death()
    {
        //Save
        Score.SaveMaxScore();
        //Save

        //Deactivation
        Player.SetActive(false);
        //Deactivation

        //Death Menu
        DeathMenuPanel.SetActive(true);
        //Death Menu
    }

    //Buttons
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    //Buttons
}
