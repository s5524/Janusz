using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    AsyncOperation asyncLoadLevel;


    public void PlayGame()
    {
        StartCoroutine(LoadGameOver());

    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    IEnumerator LoadGameOver()
    {
        asyncLoadLevel = SceneManager.LoadSceneAsync("Maze");
        while (!asyncLoadLevel.isDone)
        {
            yield return null;
        }
    }
}
