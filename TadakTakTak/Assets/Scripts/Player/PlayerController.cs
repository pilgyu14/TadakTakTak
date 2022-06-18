using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly int _runHash = Animator.StringToHash("IsRun");
    private readonly int _jumpHash = Animator.StringToHash("Jump");
    [SerializeField]
    private float _moveSpeed = 3f;
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
    private Animator _anim;

    [SerializeField]
    private LayerMask _layerMask;

    private Vector3 moveDir;
    private Ray ray;
    private void Start()
    {
        _mainCam = FindObjectOfType<Camera>();
        _characterController = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        InputMove();
        Rotate(); 
    }

    float h, v, r;
    private void InputMove()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");  
        r = Input.GetAxis("Mouse X");

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
        Animate(h, v);
        _characterController.Move((moveDir.normalized) * _moveSpeed * Time.deltaTime);
        
        //Vector3 camrRot = _mainCam.transform.eulerAngles;
        //camrRot.x = 0;
        //_characterController.transform.eulerAngles = camrRot;
    }

    /// <summary>
    /// 움직임에 따른 애니메이션
    /// </summary>
    /// <param name="h"></param>
    /// <param name="v"></param>
    private void Animate(float h, float v)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveSpeed = 7f; 
            _anim.SetBool("IsRun", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _moveSpeed = 3f; 
            _anim.SetBool("IsRun", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            _anim.SetTrigger("Jump");
            moveDir.y += _jumpPower;
        }
        _anim.SetFloat("Horizontal", h);
        _anim.SetFloat("Vertical", v);
    }

}
