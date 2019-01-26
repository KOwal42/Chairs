using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelManager))]
public class InputManager : MonoBehaviour
{
    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponentInParent<LevelManager>();
    }

    // Update is called once per frame

    private void UpdateMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            levelManager.MoveSquare(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            levelManager.MoveSquare(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            levelManager.MoveSquare(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            levelManager.MoveSquare(Vector2.left);
        }
    }

    private void UpdateShortcuts()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            levelManager.AddComponent(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            levelManager.AddComponent(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            levelManager.AddComponent(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            levelManager.AddComponent(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            levelManager.AddComponent(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            levelManager.AddComponent(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            levelManager.AddComponent(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            levelManager.AddComponent(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            levelManager.AddComponent(9);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            levelManager.AddComponent(0);
        }
    }

    void Update()
    {
        UpdateMovement();
        UpdateShortcuts();
    }
}
