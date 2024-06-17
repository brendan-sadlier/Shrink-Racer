using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public TextMeshProUGUI scoreText;

    public static string finalScore;

    // Update is called once per frame
    void Update()
    {
        finalScore = player.position.z.ToString("0");
        scoreText.text = finalScore;
    }
}
