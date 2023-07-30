using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        
        if (!other.CompareTag("Area"))
        {
            return;
        }

        Vector3 playerposition = GameManager.inst.player.transform.position;
        Vector3 myPos = transform.position;

        float diffx = Mathf.Abs(playerposition.x - myPos.x);
        float diffy = Mathf.Abs(playerposition.y - myPos.y);

        Vector3 playerDir = GameManager.inst.player.inputvector;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffx > diffy)
                {
                    transform.Translate(Vector3.right*dirX*40);
                }
                else if(diffx < diffy)
                {
                    transform.Translate(Vector3.up*dirY*40);
                }
                break;
            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3,3),Random.Range(-3,3),0));
                }
                break;
            default:
                break;
        }

    }
}
