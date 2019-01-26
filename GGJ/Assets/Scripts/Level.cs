using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    private int width;

    public int Width
    {
        get; set;
    }

    private int money;

    public int Money
    {
        get; set;
    }

    private int[] inputs;

    public int[] Inputs
    {
        get; set;
    }

    private List<int> outputs;

    public int Outputs
    {
        get; set;
    }

    public Level(int width, int money, int[] inputs, int outputs)
    {
        this.Width = width;
        this.Money = money;
        this.Inputs = inputs;
    }
}
