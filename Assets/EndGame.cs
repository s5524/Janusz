using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public TMP_InputField field;
    private string postScoreUrl = "https://januszexscore.azurewebsites.net/api/PostScore?code=tzTr7ICmp2X6ni9iYgEardrcJLVVG1DJ1rJPG925JHL4nKkJ6FRMBg==";
    // private string postScoreUrl = "http://localhost:7071/api/PostScore";
    public Button submitButton;
    public GameObject endGame;
    public GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        field.text = "Type your Name";
    }

    public void SaveScore()
    {
        StartCoroutine(Upload());
        submitButton.interactable = true;
        endGame.SetActive(false);
        mainMenu.SetActive(true);

    }


    IEnumerator Upload()
    {
        submitButton.interactable = false;
        var score = new Scores();

        score.name = field.text;
        score.points = StaticData.Score;
        StaticData.Score = 0;
        var scoreToSend = JsonConvert.SerializeObject(score);


        var request = new UnityWebRequest(postScoreUrl, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(scoreToSend);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);






        //var postData = System.Text.Encoding.UTF8.GetBytes(scoreToSend);


        //using (UnityWebRequest www = UnityWebRequest.Post(postScoreUrl, scoreToSend))
        //{
        //    yield return www.SendWebRequest();

        //    if (www.isNetworkError || www.isHttpError)
        //    {
        //        Debug.Log(www.error);
        //    }
        //    else
        //    {
        //        Debug.Log("Form upload complete!");
        //    }
        //}
    }
}
