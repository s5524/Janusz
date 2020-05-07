using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPioter : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent enemy;
    private Vector3 velocity;

    private PlayerMovement _player;
    private bool givenTask;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //    //enemy.SetDestination(velocity);
    //}
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
        //Debug.Log(distance);
        
        if (distance < 10 && givenTask==false)
        {
            enemy.SetDestination(_player.transform.localPosition);
            if (distance<2)
            {
                givenTask = true;
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
}
