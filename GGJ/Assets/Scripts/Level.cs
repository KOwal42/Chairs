using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int Width;
    public int Money;

    public Level(int width, int money)
    {
        this.Width = width;
        this.Money = money;
    }
}
