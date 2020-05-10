using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameHelpers : MonoBehaviour
{
    AsyncOperation asyncLoadLevel;
    bool poused;
    GameObject[] c;
    // Start is called before the first frame update
    public void LoadMiniGame()
    {
        StartCoroutine(LoadMiniGameScene());
    }

    public MiniGameHelpers()
    {
    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            poused = !poused;
            if (poused)
            {
                DisableMainSceneObjects();
                StartCoroutine(LoadScene("Menu"));
            }
            else
            {
                DisableMainSceneObjects();
                StartCoroutine(LoadScene("Maze"));
            }
        }
    }

    private IEnumerator LoadMiniGameScene()
    {
        var a = GameObject.FindGameObjectsWithTag("Pouse");
        var b = GameObject.FindGameObjectsWithTag("Player");

        GameObject[] c = new GameObject[a.Length + b.Length];


        a.CopyTo(c, 0);
        b.CopyTo(c, a.Length);

        foreach (var item in c)
        {
            item.SetActive(false);
        }


        asyncLoadLevel = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
        while (!asyncLoadLevel.isDone)
        {
            Debug.Log(asyncLoadLevel.isDone);
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
    }

    private void PouseGameScene()
    {


    }

    private void DisableMainSceneObjects()
    {
        if (c==null)
        {
            var a = GameObject.FindGameObjectsWithTag("Pouse");
            var b = GameObject.FindGameObjectsWithTag("Player");

            c = new GameObject[a.Length + b.Length];


            a.CopyTo(c, 0);
            b.CopyTo(c, a.Length);
        }
    

        foreach (var item in c)
        {
            item.SetActive(!poused);
        }



    }
    private IEnumerator LoadScene(string sceneName)
    {
        if (sceneName == "Menu")
        {

            asyncLoadLevel = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
            if (asyncLoadLevel == null)
            {
                while (!asyncLoadLevel.isDone)
                {
                    Debug.Log(asyncLoadLevel.isDone);
                    yield return null;
                }
            }
        }
        if (sceneName == "Maze")
        {
            asyncLoadLevel = SceneManager.UnloadSceneAsync("Menu");
            while (!asyncLoadLevel.isDone)
            {
                Debug.Log(asyncLoadLevel.isDone);
                yield return null;
            }
        }
    }
}
