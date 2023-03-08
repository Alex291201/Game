using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadMenu : MonoBehaviour
{

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score1"));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
