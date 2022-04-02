using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private float speed = 0;
    #endregion
    private RaycastHit hitforward;
    private float vertical = 0;
    private float horizontal = 0;
    private void Start()
    {
        
    }
    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        Vector3 movementDirection = new Vector3(horizontal, vertical, 0);
        movementDirection.Normalize();
        if (rayCastForward())
        {
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        }

        if (movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
        }
    }
    bool rayCastForward()
    {

        Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hitforward, 1f);
        if (hitforward.transform != null)
        {
            if (hitforward.transform.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                return false;
            }
        }
        return true;
    }
}
