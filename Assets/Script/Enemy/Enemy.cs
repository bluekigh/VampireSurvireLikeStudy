using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    public float speed;

    public Rigidbody2D target;

    private bool isLive = true;

    private Rigidbody2D rigd;

    private SpriteRenderer spriter;

    private IObjectPool<Enemy> _managedPool;

    public void setMenagedPool(IObjectPool<Enemy> pool)
    {
        _managedPool = pool;
    }

    public void Dead()
    {
        _managedPool.Release(this);
    }

    public void deadtimer()
    {
        Invoke("Dead",10);
    }
    
    

    private void Awake()
    {
        rigd = this.GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        target = GameManager.inst.player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isLive)
        {
            return;
        }
        Vector2 dirvec = target.position - rigd.position;
        Vector2 nextnec = dirvec.normalized * speed * Time.fixedDeltaTime;
        rigd.MovePosition(rigd.position + nextnec);
        rigd.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!isLive)
        {
            return;
        }
        spriter.flipX = target.position.x < rigd.position.x;
    }
}
