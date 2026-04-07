using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text winText;

    private int score = 0;

    void Start()
    {
        scoreText.text = "Score: 0";

        if (winText != null)
            winText.gameObject.SetActive(false);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score); 

        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (score >= 5)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Time.timeScale = 0f;
        StartCoroutine(WinAnimation());
    }

    IEnumerator WinAnimation()
    {
        if (winText == null) yield break;

        winText.transform.localScale = Vector3.zero;
        winText.gameObject.SetActive(true);

        float t = 0;
        while (t < 1)
        {
            t += Time.unscaledDeltaTime * 2;
            winText.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }
    }
}