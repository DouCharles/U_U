using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerPerspective : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float perspective1_x = 0f;
    public float perspective1_y = 0f;
    public float perspective1_z = 0f;
    public float perspective3_x = 0f;
    public float perspective3_y = 0f;
    public float perspective3_z = 0f;
    public Transform playerBody;

    float xRotation = 0f;
    public static bool perspective = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(perspective3_x, perspective3_y, perspective3_z);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (perspective == true)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            if (perspective == true)
            {
                perspective = false;
            }
            else
            {
                perspective = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(transform.localPosition.z < 0)
            {
                transform.localPosition = new Vector3(perspective1_x,perspective1_y,perspective1_z);
            }
            else
            {
                transform.localPosition = new Vector3(perspective3_x,perspective3_y, perspective3_z);
            }
        }
    }
}