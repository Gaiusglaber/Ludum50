using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Camera mainCamera = null;

    GameObject player;
    [SerializeField] public int lastCheckpoint = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
