﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent enemy;

    private PlayerMovement _player;
    private GameTimer _gameTimer;
    //public CharacterController controller;
    public bool EnemyCaught;
    public float EnemyDistance;

    public float speed = 12f;
    public float gravity = -9.81f;

    
    public float groundDistance = 1f;

    Vector3 velocity;
    bool isGrounded;

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
    public void SetLocation(MazeCell cell)
    {
        transform.localPosition = cell.transform.localPosition;
    }
    void Update()
    {

        velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);
        float distance = Vector3.Distance(_player.transform.position,transform.position);
        //Debug.Log(distance);

        //isGrounded = Physics.CheckSphere(grountCheck.position, groundDistance, groundMask);



        //if (isGrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}


        if (_gameTimer.timerStart <= 1)
        {
            //Vector3 dirToPlayer = transform.position - _player.transform.position;

            //Vector3 newPos = transform.position - dirToPlayer;
            //Debug.Log(newPos);
            enemy.SetDestination(_player.transform.position);
            if (distance <= EnemyDistance)
            {
                Debug.Log("złapany");
                EnemyCaught = true;
            }
        }
    }
}
