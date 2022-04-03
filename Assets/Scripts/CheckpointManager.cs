using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] public List<Transform> CheckPoint = new List<Transform>();

    void Awake()
    {
        foreach (Transform checkPoint in transform)
        {
            Debug.Log(checkPoint.name);
            CheckPoint.Add(checkPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindCheckPoint(string name)
    {
        int indexPoint = CheckPoint.FindIndex(item => item.name == name);
        GameManager.instance.lastCheckpoint = indexPoint;
    }

}
