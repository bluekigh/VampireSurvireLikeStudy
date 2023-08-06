using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    private List<GameObject>[] pools;
    

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        Debug.Log("polling");
        GameObject select = null;
        foreach (var VARIABLE in pools[index])
        {
            if (VARIABLE != null)
            {
                
            
            if (!VARIABLE.activeSelf)
            {
                select = VARIABLE;
                select.SetActive(true);
                break;
            }
            }
        }

        if (select == null)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        
        return select;
    }
    
    
    public GameObject Get2(int index)
    {
        GameObject select = null;
        foreach (var VARIABLE in pools[index])
        {
            if (!VARIABLE.activeSelf)
            {
                select = VARIABLE;
                select.SetActive(true);
                return select;
            }
        }
       
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        
        
        return select;
    }
    
}
