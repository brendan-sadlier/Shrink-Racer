using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI gameOverScoreText;

    void OnEnable()
    {
        gameOverScoreText.text = Score.finalScore;
    }
}
