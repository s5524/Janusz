using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyPioter : MonoBehaviour
{
    private NavMeshAgent enemy;
    private Vector3 velocity;
    private GameManager gm;
    public MiniGameHelpers MGH;
    private PlayerMovement _player;
    private bool givenTask;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        gm = GetComponent<GameManager>();

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
    public void SetTravelLocation(MazeCell cell)
    {

        float distance = Vector3.Distance(_player.transform.position, transform.position);
        
        if (distance < 10 && givenTask==false)
        {
            enemy.SetDestination(_player.transform.localPosition);
            if (distance<2)
            {
                givenTask = true;
                MGH.LoadMiniGame();
            }
        }
        else if (enemy != null && !enemy.pathPending)
        {
            if (enemy.remainingDistance <= enemy.stoppingDistance)
            {
                enemy.SetDestination(cell.transform.position);
                velocity = cell.transform.position;
            }
        }
    }

 
}
