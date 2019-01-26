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

    private int entryPoint;

    public int EntryPoint
    {
        get; set;
    }

    public Level(int width, int money, int entryPoint)
    {
        this.Width = width;
        this.Money = money;
        this.EntryPoint = entryPoint;
    }
}
