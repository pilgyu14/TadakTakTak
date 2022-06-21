using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoveComponent : MonoBehaviour, IComponent
{ 
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _walkSpeed = 3f;
    [SerializeField]
    private float _runSpeed = 8f;
    [SerializeField]
    private float _jumpPower = 5f;
    [SerializeField]
    private float _gravity = 9.8f;
    [SerializeField]
    private float maxDistance = 1.5f;
    [SerializeField]
    private float rotateSpeed = 360f;

    private bool isJump = false; // 점프 하는중인가 

    private Camera _mainCam;
    private CharacterController _characterController;

    [SerializeField]
    private LayerMask _layerMask;

    private Vector3 moveDir;
    private Ray ray;

    public UnityEvent<float> RunEvent = null; 
    public UnityEvent JumpEvent = null; 
    public UnityEvent<float,float> MoveEvent = null; 
    public void Initialize()
    {
        _mainCam = FindObjectOfType<Camera>();
        _characterController = GetComponent<CharacterController>();    
    }
    public void UpdateSomething()
    {
        InputMove();
        Rotate(); 
    }

    public float h, v, r;
    private void InputMove()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");  
        r = Input.GetAxis("Mouse X");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveSpeed = _runSpeed;
            RunEvent?.Invoke(_moveSpeed); 
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _moveSpeed = _walkSpeed;
            RunEvent?.Invoke(_moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            moveDir.y += _jumpPower;
            JumpEvent?.Invoke(); 
        }

        Move(h, v);
    }

    private void Rotate()
    {
        float r = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0,r * rotateSpeed * Time.deltaTime,0)); 
    }
    private bool RayGravity()
    {
        ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);

        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        return Physics.Raycast(ray, maxDistance, _layerMask);
    }

    private void ApplyGravity()
    {
        Debug.Log("IsGrounded" + _characterController.isGrounded);
        Debug.Log("Ray" + RayGravity());
        Debug.Log("중력적용중");

        moveDir.y -= _gravity * Time.deltaTime;
        return;
    }

    private void Move(float h, float v)
    {
        if (_characterController.isGrounded == true || RayGravity() == true)
        {
            isJump = false; 
            moveDir = (transform.right * h) + (transform.forward * v);
        }
        else
        {
            isJump = true;
            ApplyGravity();
        }
        //      Animate(h, v);
        MoveEvent?.Invoke(h, v); 
        _characterController.Move((moveDir.normalized) * _moveSpeed * Time.deltaTime);
        
        //Vector3 camrRot = _mainCam.transform.eulerAngles;
        //camrRot.x = 0;
        //_characterController.transform.eulerAngles = camrRot;
    }

}
