using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] float speed;
    Rigidbody2D rb;

    GameObject lantern;
    Vector2 movement;
    public Action<bool> OnCollidingEnemy = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoints"))
        {
            gameManager.LastCheckPoint(other.name);
        }
        if (other.CompareTag("Enemy"))
        {
            OnCollidingEnemy?.Invoke(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnCollidingEnemy?.Invoke(false);
        }
    }
}
