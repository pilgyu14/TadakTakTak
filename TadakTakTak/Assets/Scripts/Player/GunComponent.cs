using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunPosType
{ 
    Head,
    Neck,
    Body,
    LShoulder,
    RShoulder,
    LArm,
    RArm,
    LLeg,
    RLeg,
}

public class GunComponent : MonoBehaviour
{
    [SerializeField]
    private Transform[] _gunPos; 


}
