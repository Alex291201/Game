using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI nume1;
    public TextMeshProUGUI nume2;
    public TextMeshProUGUI nume3;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;

    void Start()
    {
        nume1.text = PlayerPrefs.GetString("nume1");
        nume2.text = PlayerPrefs.GetString("nume2");
        nume3.text = PlayerPrefs.GetString("nume3");


        if (PlayerPrefs.GetInt("highscore1") != 0) score1.text = PlayerPrefs.GetInt("highscore1").ToString();
        if (PlayerPrefs.GetInt("highscore2") != 0) score2.text = PlayerPrefs.GetInt("highscore2").ToString();
        if (PlayerPrefs.GetInt("highscore3") != 0) score3.text = PlayerPrefs.GetInt("highscore3").ToString();
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("score") >= PlayerPrefs.GetInt("highscore1"))
        {
            score3.text = PlayerPrefs.GetInt("highscore2").ToString();
            nume3.text = PlayerPrefs.GetString("nume2");
            PlayerPrefs.SetInt("highscore3", PlayerPrefs.GetInt("highscore2"));
            PlayerPrefs.SetString("nume3", PlayerPrefs.GetString("nume2"));
            score2.text = PlayerPrefs.GetInt("highscore1").ToString();
            nume2.text = PlayerPrefs.GetString("nume1");
            PlayerPrefs.SetInt("highscore2", PlayerPrefs.GetInt("highscore1"));
            PlayerPrefs.SetString("nume2", PlayerPrefs.GetString("nume1"));
            score1.text = PlayerPrefs.GetInt("score").ToString();
            nume1.text = PlayerPrefs.GetString("name");
            PlayerPrefs.SetInt("highscore1", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetString("nume1", PlayerPrefs.GetString("name"));
            PlayerPrefs.SetInt("score", 0);
        }
        else if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highscore2"))
        {
            score3.text = PlayerPrefs.GetInt("highscore2").ToString();
            nume3.text = PlayerPrefs.GetString("nume2");
            PlayerPrefs.SetInt("highscore3", PlayerPrefs.GetInt("highscore2"));
            PlayerPrefs.SetString("nume3", PlayerPrefs.GetString("nume2"));
            score2.text = PlayerPrefs.GetInt("highscore2").ToString();
            nume2.text = PlayerPrefs.GetString("name");
            PlayerPrefs.SetInt("highscore2", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetString("nume2", PlayerPrefs.GetString("name"));
            PlayerPrefs.SetInt("score", 0);
        }
        else if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highscore3"))
        {
            score3.text = PlayerPrefs.GetInt("highscore3").ToString();
            nume3.text = PlayerPrefs.GetString("name");
            PlayerPrefs.SetInt("highscore3", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetString("nume3", PlayerPrefs.GetString("name"));
            PlayerPrefs.SetInt("score", 0);
        }

    }
}
