using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text winText;

    private int score = 0;

    void Start()
    {
        winText.gameObject.SetActive(false);
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;

        // WIN condition
        if (score >= 5)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        winText.text = "YOU WIN!";
        winText.gameObject.SetActive(true);
        Time.timeScale = 0f; 
    }
}