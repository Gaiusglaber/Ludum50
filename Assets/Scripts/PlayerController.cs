using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    GameObject lantern;
    void Start()
    {
        lantern = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        transform.Translate(xAxis * speed * Time.deltaTime, yAxis * speed * Time.deltaTime, 0f);



        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        lantern.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }


    void LookTarget()
    {
    }
}
