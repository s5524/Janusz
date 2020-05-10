using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyPioter : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent enemy;
    private Vector3 velocity;
    AsyncOperation asyncLoadLevel;

    private PlayerMovement _player;
    private bool givenTask;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        //enemy.SetDestination(velocity);
    }
    public void SetPlayer(PlayerMovement player)
    {
        _player = player;
    }
    public void SetLocation(MazeCell cell)
    {
        transform.localPosition = cell.transform.localPosition;
        velocity = cell.transform.localPosition;
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(5);

    }
    public void SetTravelLocation(MazeCell cell)
    {

        float distance = Vector3.Distance(_player.transform.position, transform.position);
        //Debug.Log(distance);
        
        if (distance < 10 && givenTask==false)
        {
            enemy.SetDestination(_player.transform.localPosition);
            if (distance<2)
            {
                //Time.timeScale = 0f;
                givenTask = true;
                StartCoroutine(LoadMiniGameScene());
                Debug.Log("dupa");
            }
        }

        if (enemy != null && !enemy.pathPending)
        {
            if (enemy.remainingDistance <= enemy.stoppingDistance)
            {
                if (!enemy.hasPath || enemy.velocity.sqrMagnitude == 0f)
                {
                    enemy.SetDestination(cell.transform.localPosition);
                    velocity = cell.transform.localPosition;
                }
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


        asyncLoadLevel = SceneManager.LoadSceneAsync("MazeTest",LoadSceneMode.Additive);
        while (!asyncLoadLevel.isDone)
        {
            Debug.Log(asyncLoadLevel.isDone);
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MazeTest"));
    }
}
