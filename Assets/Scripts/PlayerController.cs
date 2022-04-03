using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    CheckpointManager checkPointManager;
    [SerializeField] float speed;
    Rigidbody2D rb;

    GameObject lantern;
    Vector2 movement;
    public Action<bool> OnCollidingEnemy = null;
    private void Awake()
    {
        checkPointManager = FindObjectOfType<CheckpointManager>();
        gameManager = FindObjectOfType<GameManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        lantern = transform.GetChild(0).gameObject;
    }
    void Start()
    {
        transform.position = checkPointManager.CheckPoint[gameManager.lastCheckpoint].transform.position;
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
            checkPointManager.FindCheckPoint(other.name);
        }
        if (other.CompareTag("Enemy"))
        {
            OnCollidingEnemy?.Invoke(true);
            if(!other.GetComponent<AudioSource>().isPlaying) other.GetComponent<AudioSource>().Play();
        }
        if (other.CompareTag("EnemySound"))
        {
            if (!other.GetComponent<AudioSource>().isPlaying) other.GetComponent<AudioSource>().Play();
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
