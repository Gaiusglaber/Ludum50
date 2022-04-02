using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> Checkpoints;

    [SerializeField] int lastCheckpoint;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //if(lastCheckpoint != null)
        //{
        //    GameObject player = FindObjectOfType<PlayerController>().gameObject;
        //    player.transform.position = Checkpoints[lastCheckpoint].transform.position;
        //}
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    public void LastCheckPoint(string Name)
    {
        for (int i = 0; i < Checkpoints.Count; i++)
        {
            string checkPointName = Checkpoints[i].name;
            if (Name == checkPointName)
            {
                lastCheckpoint = i;
            }
        }
    }
}
