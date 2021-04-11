using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplite : MonoBehaviour
{
    public GameManager gm;
    public void LoadNextLevel()
    {
        gm.GoNext();
    }
}
