using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    private float timer=1;
    private float curtimer = 0;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        curtimer += Time.deltaTime;
        if (timer < curtimer)
        {
            Spawn();
            curtimer = 0;
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.inst.PoolManager.Get(Random.Range(0,2));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        
    }
}
