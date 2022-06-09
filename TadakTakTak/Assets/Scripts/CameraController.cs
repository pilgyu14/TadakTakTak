using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotationX,rotationY;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float mouseSpeed = 5f; // 마우스 감도 
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y"); 

        rotationX += x * mouseSpeed;
        rotationY = Mathf.Clamp(rotationY + y  * mouseSpeed, -45, 90); 

        transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0);
        transform.position = playerTransform.position; 
    }
}
