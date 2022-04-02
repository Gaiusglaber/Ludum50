using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        //float mouseX = Input.mousePosition.x;
        //float mouseY = Input.GetAxis("Mouse Y");

        transform.position = Input.mousePosition;
    }
}
