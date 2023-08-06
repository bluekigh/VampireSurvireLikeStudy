using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    public Player player;
    public PoolManager PoolManager;

    private void Awake()
    {
        inst = this;
    }
}
