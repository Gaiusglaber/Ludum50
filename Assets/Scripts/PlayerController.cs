using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SoundPlayer Soundplayer = null;
    GameManager gameManager;
    CheckpointManager checkPointManager;
    [SerializeField] float speed;
    Rigidbody2D rb;

    GameObject lantern;
    Vector2 movement;
    public Action<bool> OnCollidingEnemy = null;
    public Action OnPickKey = null;
    [NonSerialized] public bool HasKey = false;
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
            Soundplayer.OnPlaySound?.Invoke("0");
        }
        if (other.CompareTag("EnemySound"))
        {
            Soundplayer.OnPlaySound?.Invoke("1");
        }
        if (other.CompareTag("Glass"))
        {
            Soundplayer.OnPlaySound?.Invoke("8");
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Key")&&Input.GetKey(KeyCode.E))
        {
            OnPickKey?.Invoke();
            collision.gameObject.SetActive(false);
            HasKey = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            if (collision.CompareTag("Enemy"))
            {
                OnCollidingEnemy?.Invoke(false);
            }
        }
    }
    private void EnableKey()
    {

    }
}
