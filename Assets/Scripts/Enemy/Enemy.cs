using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent enemy;

    private PlayerMovement _player;
    private GameTimer _gameTimer;
    public bool EnemyCaught;
    public float EnemyDistance;

    public float speed = 12f;
    public float gravity = -9.81f;

    
    public float groundDistance = 1f;

    Vector3 velocity;

    public LayerMask groundMask;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }
    public void SetTimer(GameTimer gameTimer)
    {
        _gameTimer = gameTimer;
    }
    public void SetPlayer(PlayerMovement player)
    {
        _player = player;
    }
    void Update()
    {
        velocity.y += gravity * Time.deltaTime;

        if (_gameTimer.timerStart <= 1)
        {
            float distance = Vector3.Distance(_player.transform.position, transform.position);
            if (distance <= EnemyDistance)
            {
                EnemyCaught = true;
            }

            if (enemy != null && !enemy.pathPending)
            {


                if (enemy.remainingDistance <= enemy.stoppingDistance)
                {
                    if (!enemy.hasPath || enemy.velocity.sqrMagnitude == 0f)
                    {
                        enemy.SetDestination(_player.transform.position);
                        velocity = _player.transform.position;
                    }
                }
            }
        }
    }
}
