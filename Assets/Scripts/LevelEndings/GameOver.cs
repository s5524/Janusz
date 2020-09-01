using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;
    AsyncOperation asyncLoadLevel;

    IEnumerator LoadGameOver()
    {
        asyncLoadLevel = SceneManager.LoadSceneAsync("EndGame", LoadSceneMode.Single);
        while (!asyncLoadLevel.isDone)
        {
            yield return null;
        }
    }
}
