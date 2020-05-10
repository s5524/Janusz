using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameSceneLuncher : MonoBehaviour
{
    AsyncOperation asyncLoadLevel;
    // Start is called before the first frame update
    public void LoadMiniGame()
    {
        StartCoroutine(LoadMiniGameScene());
    }



    private IEnumerator LoadMiniGameScene()
    {

        asyncLoadLevel = SceneManager.LoadSceneAsync("Maze");
        while (!asyncLoadLevel.isDone)
        {
            Debug.Log(asyncLoadLevel.isDone);
            yield return null;
        }
    }
}
