using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    private ScoreText scoreTextScript = null;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        FindScoreText();
    }

    private void Update()
    {
        if (!scoreTextScript)
        {
            FindScoreText();
            scoreTextScript.UpdateText();
        }

    }

    private void FindScoreText()
    {
        scoreTextScript = FindObjectOfType<ScoreText>();
    }

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int delta)
    {
        score = score + delta;

        UpdateText();
    }

    private void UpdateText()
    {
        scoreTextScript.UpdateText();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
