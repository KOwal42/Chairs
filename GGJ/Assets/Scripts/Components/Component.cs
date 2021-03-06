﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : MonoBehaviour
{
    //TODO fix all userless getters / setters


    public ComponentType Type;
    public Direction Dir = Direction.Up;
    
    public float MoveSpeed = 5f;

    //public Vector2 tileNum; //where on the board is this tile?

    public Vector2 TileNum;

    //TODO - put somewhere static 
    private int partWidth = 18;
    private int tileWidth = 64;

    private bool hasParts = false;
    private bool isAligned = false;

    //TODO make private after testing 
    public List<GameObject> parts;

    public List<GameObject> Parts
    {
        get
        {
            return parts;
        }
        set
        {
            this.parts = value;
            hasParts = true;
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

    //

    //TODO RENAME
    //Move the part in the set direction 
    private void MovePart(GameObject part)
    {
        Vector3 movement = Vector3.zero;

        switch (Dir)
        {
            case Direction.Up:
                movement = Vector3.forward * MoveSpeed * Time.deltaTime;
                break;
            case Direction.Down:
                movement = Vector3.back * MoveSpeed * Time.deltaTime;
                break;
            case Direction.Left:
                movement = Vector3.left * MoveSpeed * Time.deltaTime;
                break;
            case Direction.Right:
                movement = Vector3.right * MoveSpeed * Time.deltaTime;
                break;
        }

        part.transform.position += movement;
    }

    //TODO - merge this with MovePart. Keep seperate until tested 
    void MoveToCentre(GameObject part)
    {
        var pos = part.transform.position;

        //make y = 18 (belt height) so we are testing 2D distance
        var tilePos = new Vector3(TileNum.x * 64, 18f, TileNum.y * 64);


        Debug.Log(Vector3.Distance(pos, tilePos));

        if (Vector3.Distance(pos, tilePos) < 1)
        {
            part.transform.position = tilePos;
            isAligned = true;
            return;
        }
        else
        {
            Vector3 movement = Vector3.zero;

            switch (part.GetComponent<Part>().PreviousDir)
            {
                case Direction.Up:
                    movement = Vector3.forward * MoveSpeed * Time.deltaTime;
                    break;
                case Direction.Down:
                    movement = Vector3.back * MoveSpeed * Time.deltaTime;
                    break;
                case Direction.Left:
                    movement = Vector3.left * MoveSpeed * Time.deltaTime;
                    break;
                case Direction.Right:
                    movement = Vector3.right * MoveSpeed * Time.deltaTime;
                    break;
            }

            part.transform.position += movement;
        }

    }

    public void Rotate()
    {
        transform.localRotation = Quaternion.Euler(0f, transform.eulerAngles.y + 90f, 0f);

        switch (Dir)
        {
            case Direction.Up:
                Dir = Direction.Right;
                break;
            case Direction.Down:
                Dir = Direction.Left;
                break;
            case Direction.Left:
                Dir = Direction.Up;
                break;
            case Direction.Right:
                Dir = Direction.Down;
                break;
        }
    }

    //Check to see if the part has left the boundary
    private void CheckBounds(GameObject part)
    {
        var halfPart = partWidth / 2;
        var halfTile = tileWidth / 2;

        //How much space do we have to move?
        var space = halfTile;// - halfPart;

        var partPos = part.transform.position;
        var tilePos = transform.position;

        var i = TileNum;

        if (partPos.x > tilePos.x + space)
        {
            GivePart(part);
        }
        else if (partPos.x < tilePos.x - space)
        {
            GivePart(part);
        }
        else if(partPos.z > tilePos.z + space)
        {
            GivePart(part);
        }
        else if (partPos.z < tilePos.z - space)
        {
            GivePart(part);
        }
    }

    //Give the part to another tile when it leaves the boundary
    public void GivePart(GameObject part)
    {
        Vector2 newTilePos = Vector2.zero;

        switch (Dir)
        {
            case Direction.Up:
                newTilePos = Vector2.up + TileNum;
                break;
            case Direction.Down:
                newTilePos = Vector2.down + TileNum;
                break;
            case Direction.Left:
                newTilePos = Vector2.left + TileNum;
                break;
            case Direction.Right:
                newTilePos = Vector2.right + TileNum;
                break;
        }

        hasParts = false;

        var manager = FindObjectOfType<ComponentManager>();
        part.GetComponent<Part>().PreviousDir = Dir;
        manager.MovePart(part, newTilePos);
    }


    // Update is called once per frame
    void Update()
    {
        if(hasParts)
        {
            foreach (GameObject p in parts)
            {
                if (!p.GetComponent<Part>().CanMove)
                    continue;
                

                if (!isAligned)
                {
                    MoveToCentre(p);
                }
                else
                {
                    MovePart(p);
                }

                CheckBounds(p);
            }
        }
    }
}
