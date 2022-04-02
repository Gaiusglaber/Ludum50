using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;

    GameObject lantern;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        lantern = transform.GetChild(0).gameObject;
    }
    
    private void FixedUpdate()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xAxis * speed, yAxis * speed);
    }
}
