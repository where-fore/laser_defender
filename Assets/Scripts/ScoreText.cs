using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI textComponent = null;

    private ScoreManager scoreManagerScript = null;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();

        FindScoreManager();

        UpdateText();
    }

    private void Update()
    {
        if (!scoreManagerScript)
        {
            FindScoreManager();
            UpdateText();
        }

    }

    private void FindScoreManager()
    {
        scoreManagerScript = FindObjectOfType<ScoreManager>();
    }

    public void UpdateText()
    {
        string scoreString = scoreManagerScript.GetScore().ToString();

        textComponent.text = scoreString;
    }

}
