using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ComponentManager))]
public class LevelManager : MonoBehaviour
{
    public Material BoardMaterial;
    public Material SelectedMaterial;

    float spacing = 64f;

    public GameObject[,] GameBoard;

    GameObject activeSquare;

    public Vector2 selectedPos = Vector2.zero;

    int currentLevelNo = 1;
    Level currentLevel;

    List<Level> levels = new List<Level>();

    ComponentManager componentManager;

    // Start is called before the first frame update
    void Start()
    {
        componentManager = GetComponentInParent<ComponentManager>();
        SetupLevels();
        LoadLevel();
        componentManager.AddInputs(levels[currentLevelNo].Inputs);
    }

    void SetupLevels()
    {
        var level = new Level(3, 100,new int[1] {1}, 2); // Level 1
        levels.Add(level);
        levels.Add(level); //add it twice so that level 1 is [1] and not [0]

        level = new Level(3, 80, new int[1] {1}, 1); // Level 2
        levels.Add(level);

        level = new Level(4, 120, new int[2] {2, 3}, 1); // Level 3
        levels.Add(level);

        currentLevel = levels[currentLevelNo];
    }

    public void MoveSquare(Vector2 movement)
    {
        selectedPos += movement;

        var width = currentLevel.Width;

        if (selectedPos.x < 0)
        {
            selectedPos = new Vector2(width - 1, selectedPos.y);
        }
        else if (selectedPos.x > width -1)
        {
            selectedPos = new Vector2(0, selectedPos.y);
        }
        else if (selectedPos.y < 0)
        {
            selectedPos = new Vector2(selectedPos.x, width - 1);
        }
        else if (selectedPos.y > width - 1)
        {
            selectedPos = new Vector2(selectedPos.x, 0);
        }

        Debug.Log(selectedPos);

        activeSquare.GetComponent<Renderer>().material = BoardMaterial;
        activeSquare = GameBoard[(int)selectedPos.x, (int)selectedPos.y];
        activeSquare.GetComponent<Renderer>().material = SelectedMaterial;
    }

    public void RotateSquare()
    {
        componentManager.RotateComponent(selectedPos);
    }

    public void AddComponent(int num)
    {
        componentManager.AddComponent(selectedPos, num);
    }


    void Activate()
    {

    }

    void LoadLevel()
    {
        var width = currentLevel.Width;

        GameBoard = new GameObject[width, width];

        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameBoard[i,j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                GameBoard[i, j].transform.position = new Vector3(i * spacing, -9f, j * spacing);
                GameBoard[i, j].transform.localScale = new Vector3(64f, 1f, 64f);
                GameBoard[i, j].GetComponent<Renderer>().material = BoardMaterial;
            }
        }

        activeSquare = GameBoard[(int)selectedPos.x, (int)selectedPos.y];
        activeSquare.GetComponent<Renderer>().material = SelectedMaterial;

        componentManager.NewLevel(width);
    }

    void NextLevel()
    {
        currentLevelNo++;
        LoadLevel();
        //DELETE CURRENT LEVEL 
    }

    void RestartLevel()
    {
        //DELETE CURRENT LEVEL 
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
