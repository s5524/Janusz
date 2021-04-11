using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameHelpers : MonoBehaviour
{
    AsyncOperation asyncLoadLevel;
    bool poused;
    public static GameObject[] gameObjects;
    public GameObject[] miniGames;
    private GameObject miniGameInstance;
    public void LoadMiniGame()
    {
        LoadMiniGameScene();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            poused = !poused;
            if (poused)
            {
                DisableMainSceneObjects(false);
                StartCoroutine(LoadScene("Menu"));
            }
            else
            {
                DisableMainSceneObjects(true);
                StartCoroutine(LoadScene("Maze"));
            }
        }
    }

    private void LoadMiniGameScene()
    {
        DisableMainSceneObjects(false);
        var i = Random.Range(0, miniGames.Length);
        miniGameInstance = Instantiate(miniGames[i]);

    }
    public void UnloadMiniGame()
    {
        Destroy(miniGameInstance);
        DisableMainSceneObjects(true);

    }

    private void DisableMainSceneObjects(bool disable)
    {
        if (gameObjects == null || gameObjects.Length == 0)
        {
            var objectsWithPouseTag = GameObject.FindGameObjectsWithTag("Pouse");
            var objectsWithPlayerTag = GameObject.FindGameObjectsWithTag("Player");

            gameObjects = new GameObject[objectsWithPouseTag.Length + objectsWithPlayerTag.Length];

            objectsWithPouseTag.CopyTo(gameObjects, 0);
            objectsWithPlayerTag.CopyTo(gameObjects, objectsWithPouseTag.Length);
        }


        foreach (var item in gameObjects)
        {
            item.SetActive(disable);
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
