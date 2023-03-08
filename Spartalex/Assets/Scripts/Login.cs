using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{
    public TMP_InputField textBox;

    public void clickSaveButton()
    {
        PlayerPrefs.SetString("name", textBox.text);
        PlayerPrefs.SetInt("score", 0);
        Debug.Log("You name is" + PlayerPrefs.GetString("name"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
