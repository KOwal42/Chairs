using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentManager : MonoBehaviour
{
    //
    public GameObject[] Components = new GameObject[10]; 

    //change to component type 
    public GameObject[,] board;

    int spacing = 64;

    public List<GameObject> parts;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void NewLevel(int width)
    {
        board = new GameObject[width, width];


        //DEBUG LEVEL BELOW
        AddComponent(new Vector2(0, 0), 2);
        AddComponent(new Vector2(0, 2), 3);
        AddComponent(new Vector2(1, 0), 5);
        AddComponent(new Vector2(1, 2), 8);
        AddComponent(new Vector2(1, 1), 7);
        AddComponent(new Vector2(2, 1), 1);
    }

    //Add component X to the board at the current position 
    public void AddComponent(Vector2 pos, int num)
    {
        if(board[(int)pos.x, (int)pos.y] == null)
        {
            Vector3 position = new Vector3(pos.x * spacing, 0f, pos.y * spacing);
            board[(int)pos.x, (int)pos.y] = Instantiate(Components[num], position, new Quaternion());
            board[(int)pos.x, (int)pos.y].GetComponent<Component>().TileNum = pos;
        }
        else
        {
            //TODO POSITION IS FULL - WE CANT BUILD HERE?????
        }
    }

    public void AddInputs(int[] inputs)
    {
        //parts = new List<GameObject>(); IS THIS REQUIRED?

        var levelManager = FindObjectOfType<LevelManager>();

        for (int i = 0; i < inputs.Length; i++)
        {
            var entryPoint = inputs[i] - 1; //offset for [0]


            //TODO CREATE A PREFAB FOR THIS
            var part = GameObject.CreatePrimitive(PrimitiveType.Cube);
            part.transform.localScale = new Vector3(18f, 18f, 18f);
            part.transform.position = new Vector3(-23f, 18f, 64f * entryPoint);
            part.AddComponent<Part>();

            MovePart(part, new Vector2(0, inputs[i]-1));

            levelManager.Parts.Add(part);
        }
    }

    //TODO - rename as it could confuse people 
    //Set the part to the specified tile
    public void MovePart(GameObject part, Vector2 tilePos)
    {
        //get the previous list of parts, add the new part then set to the new list 
        List<GameObject> parts = board[(int)tilePos.x, (int)tilePos.y].GetComponent<Component>().Parts;
        parts.Add(part);
        board[(int)tilePos.x, (int)tilePos.y].GetComponent<Component>().Parts = parts;

    }

    //Rotate the component on the specified square 
    public void RotateComponent(Vector2 tilePos)
    {
        board[(int)tilePos.x, (int)tilePos.y].GetComponent<Component>().Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
