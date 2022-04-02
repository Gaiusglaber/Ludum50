using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTest : MonoBehaviour
{
    public Vector3 check;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Checkpoints") == 1)
        {
            this.transform.position = check;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Check1")
        {
            PlayerPrefs.SetInt("CheckPoint" , 1);
            Debug.Log("Coliciona");
        }
    }

}
