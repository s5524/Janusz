using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
       


    }
  
    public void SetScore()
    {
        StartCoroutine(UpdateList());
    }
    // Update is called once per frame
    public IEnumerator UpdateList()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://januszexscore.azurewebsites.net/api/GetScore?code=ghKSeQZQUX3u1BsFEnj44mGJrs6DDEN1eKntfWasRtYXZ5SGy4u6qA==");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            text.text = "";
            var json = www.downloadHandler.text ;
            var myObject = JsonConvert.DeserializeObject<ScoreList>(json);//JsonUtility.FromJson<ScoreList>(json);

            foreach (var score in myObject.ScoreLists)
            {
                text.text = text.text + "Name:\t" + score.name + "\t\tScore:" + score.points + "\n";
            }




        }
    }
}

[Serializable]
public class Scores
{
    public int points { get; set; }
    public string name { get; set; }
    public DateTime data { get; set; }
}
public class ScoreList
{
    public Scores[] ScoreLists { get; set; }
}