using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LevelManager : MonoBehaviour
{
    private string gameSceneString = "Main";
    private string gameOverSceneString = "Game Over Menu";
    private string startMenuSceneString = "Start Menu";

    private float delayBeforeGameOver = 3f;


    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneString);
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(WaitThenGameOver());
    }

    private IEnumerator WaitThenGameOver()
    {
        yield return new WaitForSeconds(delayBeforeGameOver);

        SceneManager.LoadScene(gameOverSceneString);
    }

    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene(startMenuSceneString);
    }

    public void QuitGame()
    {
        // Remove me for builds, add me for editing
        EditorApplication.isPlaying = false;

        // Add me for builds, remove me for editing
        //Application.Quit();
    }
}
