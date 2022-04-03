using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{


    //// Logic
    //public float triggerLenght = 1;
    //public float chaseLenght = 5;
    //private bool chasing;
    //private bool collidingWhitPlayer;
    //private Transform playerTransform;
    //private Vector3 startingPosition;

    //// Hitbox
    //public ContactFilter2D filter;
    //private BoxCollider2D hitBox;
    //private Collider2D[] hits = new Collider2D[10];

    //protected override void Start()
    //{
    //    base.Start();
    //    playerTransform = GameManeger.instance.player.transform;
    //    startingPosition = transform.position;
    //    hitBox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    //}

    //private void FixedUpdate()
    //{
    //    // Is the player in range?
    //    if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght)
    //    {
    //        if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght)
    //        {
    //            chasing = true;
    //        }
    //        if (chasing)
    //        {
    //            if (!collidingWhitPlayer)
    //            {
    //                UpdateMotor((playerTransform.position - transform.position).normalized);
    //            }
    //        }
    //        else
    //        {
    //            UpdateMotor(startingPosition - transform.position);
    //        }
    //    }
    //    else
    //    {
    //        UpdateMotor(startingPosition - transform.position);
    //        chasing = false;
    //    }

    //    // Check for overlaps
    //    collidingWhitPlayer = false;
    //    // colition work
    //    hitBox.OverlapCollider(filter, hits);
    //    for (int i = 0; i < hits.Length; i++)
    //    {
    //        if (hits[i] == null)
    //        {
    //            continue;
    //        }

    //        if (hits[i].tag == "Fighter" && hits[i].name == "Player")
    //        {
    //            collidingWhitPlayer = true;
    //        }

    //        // the array is not cleaned up , so we do it ourself
    //        hits[i] = null;
    //    }

    //    UpdateMotor(Vector3.zero);
    //}

}
