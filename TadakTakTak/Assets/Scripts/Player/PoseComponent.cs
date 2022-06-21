using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoseType
{
    T_Pose,
    PushUp,
    Powerless, 

}
public class PoseComponent : IComponent
{
    private bool isPosing; // 포즈 취하는 중 
    [SerializeField]
    private PlayerController _playerController;

    private List<IPose> _poseList = new List<IPose>(); // 보유 포즈 
    private IPose _curPose; // 현재 포즈
    private int _poseIndex = 0; 

    public void Initialize()
    {

    }

    public void UpdateSomething()
    {
        _curPose.Posing(); 
    }
    
    public void ChangePose()
    {
        if(_poseIndex >= _poseList.Count - 1)
        {
            _poseIndex = 0; 
        }
        _curPose = _poseList[_poseIndex++]; 
    }
    public void AddPose(IPose newPose)
    {
        _poseList.Add(newPose); 
    }

    public void RemovePose(IPose removePose)
    {
        _poseList.Remove(removePose);
    }

}
