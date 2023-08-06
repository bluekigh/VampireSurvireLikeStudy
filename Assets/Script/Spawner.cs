using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Pool;


public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    private float timer=1;
    private float curtimer = 0;

    private IObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(createEnemy, OngetEnemy, OnReleaseEnemy, OnDestoryEnemy, maxSize: 50);
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
        // GameObject enemy = GameManager.inst.PoolManager.Get(Random.Range(0,2));
        // enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        // GameManager.inst.PoolManager.

        var enemy = _pool.Get();
        enemy.gameObject.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;

    }

    Enemy createEnemy()
    {
        Enemy enemy = Instantiate(GameManager.inst.PoolManager.prefabs[0]).GetComponent<Enemy>();
        enemy.setMenagedPool(_pool);
        return enemy;
    }

    void OngetEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
    }
    
    void OnReleaseEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }
    
    void OnDestoryEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

    
}
