using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.parent.GetComponent<MiniEnemyController>().ChildCollision(other);
    }
}
