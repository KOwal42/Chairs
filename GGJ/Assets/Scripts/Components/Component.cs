using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : MonoBehaviour
{

    public ComponentType Type;
    public Direction Dir = Direction.Up; 
    public float MoveSpeed = 10f;

    Vector2 tilePos; //where on the board is this tile?


    private bool hasPart = false;
    public GameObject part;

    public GameObject Part
    {
        get
        {
            return part;
        }
        set
        {
            this.part = value;
            hasPart = true;
        }
    }

    public enum ComponentType
    {
        Part,
        Machine
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GivePart()
    {
        Vector2 newTilePos = Vector2.zero;

        switch (Dir)
        {
            case Direction.Up:
                newTilePos = Vector2.up + tilePos;
                break;
            case Direction.Down:
                newTilePos = Vector2.down + tilePos;
                break;
            case Direction.Left:
                newTilePos = Vector2.left + tilePos;
                break;
            case Direction.Right:
                newTilePos = Vector2.right + tilePos;
                break;
        }
        part = null; //TODO test to see if this deletes part totally 
        hasPart = false;

        var manager = FindObjectOfType<ComponentManager>();
        //manager.MovePart();
    }

    private void MovePart()
    {
        Vector3 movement = Vector3.zero;

        switch (Dir)
        {
            case Direction.Up:
                movement = Vector3.back * MoveSpeed * Time.deltaTime;
                break;
            case Direction.Down:
                movement = Vector3.forward * MoveSpeed * Time.deltaTime;
                break;
            case Direction.Left:
                movement = Vector3.right * MoveSpeed * Time.deltaTime;
                break;
            case Direction.Right:
                movement = Vector3.left * MoveSpeed * Time.deltaTime;
                break;
        }

        part.transform.position += movement;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasPart)
        {
            MovePart();
           // CheckBounds();
        }
    }
}
