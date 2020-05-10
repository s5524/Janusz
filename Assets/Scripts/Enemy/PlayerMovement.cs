using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Maze maze;
    public CharacterController controller;
    // Start is called before the first frame update
    public float speed = 6f;
    public float gravity = 20.0f;
    public float rotationSpeed = 100.0F;
    public Transform grountCheck;
    public float groundDistance = 1f;

    public LayerMask groundMask;

    public Inventory inventory;

    Vector3 velocity;
    bool isGrounded;
    private Vector3 moveDirection = Vector3.zero;
    private void OnTriggerEnter(Collider other)
    {

        IInventoryItems item = other.GetComponent<IInventoryItems>();

        if (item!= null)
        {
            inventory.AddItem(item);

        }
        if (item == null)
        {

        var firstSpace = other.gameObject.name.ToString().IndexOf(' ');
        var secoundSpace = other.gameObject.name.ToString().IndexOf(' ',firstSpace + 1);
        var comaIndex = other.gameObject.name.ToString().IndexOf(',');

        var yIndex = Int32.Parse(other.gameObject.name.ToString().Substring(comaIndex+1));
        var xIndex = Int32.Parse(other.gameObject.name.ToString().Substring(secoundSpace,comaIndex-secoundSpace));
        maze.GetCell(xIndex, yIndex).OnPlayerEntered();
            // var cell = maze.GetCell(xIndex, yIndex);
        }



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
        //isGrounded = Physics.CheckSphere(grountCheck.position, groundDistance, groundMask);



        //if (isGrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");


        //Vector3 move = transform.right * x + transform.forward * z;

        //controller.Move(move*speed*Time.deltaTime);

        ////velocity.y += gravity * Time.deltaTime;

        ////controller.Move(velocity * Time.deltaTime);
        //float translation = Input.GetAxis("Vertical") * speed;
        //float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        //translation *= Time.deltaTime;
        //rotation *= Time.deltaTime;
        //transform.Translate(0, 0, translation);
        //transform.Rotate(0, rotation, 0);
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump")) ;
               // moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        //controller.enabled = false;
        controller.Move(moveDirection * Time.deltaTime);
        //controller.enabled = true;

    }
}
