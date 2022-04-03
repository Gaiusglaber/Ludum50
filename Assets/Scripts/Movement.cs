using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover 
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;

    protected virtual void Start()
    {
    }
    protected virtual void UpdateMotor(Vector3 imput)
    {
        // Reset the moveDelta
        moveDelta = new Vector3(imput.x * xSpeed, imput.y * ySpeed, 0);
    }
}
