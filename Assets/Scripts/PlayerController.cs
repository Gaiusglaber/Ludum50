using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;

    GameObject lantern;
    Vector2 movement;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        lantern = transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}
