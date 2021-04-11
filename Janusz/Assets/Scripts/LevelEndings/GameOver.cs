using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;
    public void LoadGameOver()
    {
       
        var async = SceneManager.LoadSceneAsync("Menu");
        //async.allowSceneActivation = false;
       // SceneManager.LoadScene("Menu");
        //gm.RestartGame();
    }
}
