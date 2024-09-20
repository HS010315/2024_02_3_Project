using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CommandManager commandManager;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            ICommand moveRight = new MoveCommand(transform, Vector3.right);
            commandManager.ExecuteCommand(moveRight);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ICommand moveLeft = new MoveCommand(transform, Vector3.left);
            commandManager.ExecuteCommand(moveLeft);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ICommand moveLeft = new MoveCommand(transform, Vector3.up);
            commandManager.ExecuteCommand(moveLeft);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ICommand moveLeft = new MoveCommand(transform, Vector3.down);
            commandManager.ExecuteCommand(moveLeft);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            commandManager.UndoLastCommand();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            commandManager.StartCoroutine("ResetCommand");              //커맨드 초기화
        }
    }
}
