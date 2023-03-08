using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public int cont;
    public void SetTextValue()
    {
        cont++;
        GetComponent<TMPro.TextMeshProUGUI>().text = cont.ToString();
        PlayerPrefs.SetInt("score1", cont);
    }
}
