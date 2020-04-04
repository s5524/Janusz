using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Maze maze;
    public CharacterController controller;
    // Start is called before the first frame update
    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform grountCheck;
    public float groundDistance = 1f;

    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    private void OnTriggerEnter(Collider other)
    {
        var firstSpace = other.gameObject.name.ToString().IndexOf(' ');
        var secoundSpace = other.gameObject.name.ToString().IndexOf(' ',firstSpace + 1);
        var comaIndex = other.gameObject.name.ToString().IndexOf(',');

        var yIndex = Int32.Parse(other.gameObject.name.ToString().Substring(comaIndex+1));
        var xIndex = Int32.Parse(other.gameObject.name.ToString().Substring(secoundSpace,comaIndex-secoundSpace));

        maze.GetCell(xIndex, yIndex).OnPlayerEntered();
        var cell = maze.GetCell(xIndex, yIndex);


        Debug.Log(cell.gameObject.name);
        Debug.Log("="+xIndex+"======"+yIndex+"=");
        //Debug.Log(Int32.Parse(yIndex.Trim(' ')) + " ====== " + Int32.Parse(xIndex.Trim(' ')));

       // Debug.Log("collide (lenght) : " + other.gameObject.name);
       // Debug.Log("collide (name) : " + other.gameObject.gameObject);
    }

    internal void SetCells(Maze maze)
    {
        this.maze = maze ;
    }

    public void SetLocation(MazeCell cell)
    {
        transform.localPosition = cell.transform.localPosition;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(grountCheck.position, groundDistance, groundMask);



        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
