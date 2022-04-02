using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class IARotator : MonoBehaviour
{
    [SerializeField] private AIPath path;
    private void LateUpdate()
    {
        if (path.desiredVelocity.x >= 0.001f)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
