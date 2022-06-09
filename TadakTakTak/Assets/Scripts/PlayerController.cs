using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float rotateSpeed = 3f;

    private Camera mainCam;
    private CharacterController characterController;

    private void Start()
    {
        mainCam = FindObjectOfType<Camera>();
        characterController = GetComponent<CharacterController>(); 
    }
    void Update()
    {
        
        Move();   
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition).normalized;  

        Vector3 moveDir = (transform.right.normalized * h) + (transform.forward.normalized * v);
        
        characterController.Move(moveDir.normalized);


//        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,mousePos.z));

        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward);
        Vector3 right = mainCam.transform.TransformDirection(Vector3.right);

        //Vector3 playerForward = characterController.transform.forward;
        //playerForward.y = 0;
        //Vector3 camForward = mainCam.transform.forward;
        //camForward.y = 0;

        //characterController.transform.forward = Vector3.Lerp(playerForward, camForward, Time.deltaTime);
        Vector3 camrRot = mainCam.transform.eulerAngles;
        camrRot.x = 0; 
        characterController.transform.eulerAngles = camrRot; 
    }
}
