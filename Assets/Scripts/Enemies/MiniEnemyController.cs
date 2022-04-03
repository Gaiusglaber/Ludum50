using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemyController : MonoBehaviour
{

    bool isRunning;
    float timePass;
    [SerializeField] float moveDuration;

    private void Update()
    {
        if (isRunning)
        {
            transform.Translate(new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0) * Time.deltaTime);
            timePass += Time.deltaTime;
        }
        if(timePass >= moveDuration)
        {
            isRunning = false;
            timePass = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lantern"))
        {
            RunAway();
        }
    }

    void RunAway()
    {
        Debug.Log("Dejar Persecución");
        isRunning = true;
    }

    public void ChildCollision(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ARRANCAR PERSECUCIÓN");
        }
    }
}
