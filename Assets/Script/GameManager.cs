using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    public Player player;

    private void Awake()
    {
        inst = this;
    }
}
