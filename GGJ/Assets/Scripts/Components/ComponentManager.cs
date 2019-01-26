using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentManager : MonoBehaviour
{
    //
    public GameObject[] Components = new GameObject[10]; 

    //change to component type 
    GameObject[,] board;

    int spacing = 74;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void NewLevel(int width)
    {
        board = new GameObject[width, width];
    }

    //Add component X to the board at the current position 
    public void AddComponent(Vector2 pos, int num)
    {
        if(board[(int)pos.x, (int)pos.y] == null)
        {
            Vector3 position = new Vector3(pos.x * spacing, 0f, pos.y * spacing);
            board[(int)pos.x, (int)pos.y] = Instantiate(Components[num], position, new Quaternion());
        }
        else
        {
            //TODO POSITION IS FULL - WE CANT BUILD HERE?????
        }
    }

    //TODO - rename as it could confuse people 
    //Set the part to the specified tile
    public void MovePart(GameObject part, Vector2 tilePos)
    {
        Debug.Log("MOVING PART");
        board[(int)tilePos.x, (int)tilePos.y].GetComponent<Component>().Part = part;
    }

    //Rotate the component on the specified square 
    public void RotateComponent(Vector2 tilePos)
    {
        //board[(int)tilePos.x, (int)tilePos.y].GetComponent<Component>().Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
