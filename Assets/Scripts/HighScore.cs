using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    
    public TextMeshProUGUI HSText;

    private void Start() {

        if (PlayerPrefs.GetInt("highscore") == 0) {
            HSText.text = "High Score : 0";
        } else {
            HSText.text = "High Score : " + PlayerPrefs.GetInt("highscore");
        }

    }

}
