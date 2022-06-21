using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimation : MonoBehaviour
{
    private readonly int _hashJump = Animator.StringToHash("Jump");
    private readonly int _hashX = Animator.StringToHash("Horizontal");
    private readonly int _hashY = Animator.StringToHash("Vertical");
    private readonly int _hashMoveSpeed = Animator.StringToHash("MoveSpeed");

    private readonly int _hashTpose = Animator.StringToHash("TPose");
    private readonly int _hashPushupPose = Animator.StringToHash("PushupPose");
    private readonly int _hashPowerlessPose = Animator.StringToHash("PowerlessPose");

    private Animator _anim;

    public void Start()
    {
        _anim = GetComponent<Animator>(); 
    }
    public void AnimateRun(float moveSpeed)
    {
        _anim.SetFloat(_hashMoveSpeed, moveSpeed);
    }
    public void AnimateJump()
    {
        _anim.SetTrigger(_hashJump);
    }
    public void AnimateMove(float x,float y)
    {
        _anim.SetFloat(_hashX, x);
        _anim.SetFloat(_hashY, y);
    }

    public void AnimateTpose(bool isPose)
    {
        _anim.SetBool(_hashTpose, isPose);
    }
    public void AnimatePushupPose(bool isPose)
    {
        _anim.SetBool(_hashPushupPose, isPose);
    }
    public void AnimatePowerlessPose(bool isPose)
    {
        _anim.SetBool(_hashPowerlessPose, isPose);
    }

}
