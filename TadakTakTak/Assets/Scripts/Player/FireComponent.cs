using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FireComponent : IComponent
{
    [SerializeField]
    private List<AbstractGun> _guns;

    [SerializeField]
    private Transform _gunParent;

    private GunComponent _gunComponent; 
        
    private float _shootDelay; 
    private bool _isEmpty; // ¸ðµç ÃÑÀÇ ÃÑ¾ËÀÌ ºñ¾ú´Â°¡ 
    private bool _isShotable;

    public bool IsShotable => _isShotable;


    public void Initialize(GunComponent gunComponent)
    {
        _gunComponent = gunComponent;
        SetGunList(); 
    }
    public void UpdateSomething()
    {
        if(Input.GetMouseButton(0))
        {
            Shoot(); 
        }
    }
    /// <summary>
    /// ÃÑ ½î±â 
    /// </summary>
    public void Shoot()
    {
        _guns.ForEach(x => x.Fire());
    }

    /// <summary>
    /// ÇöÀç ÀåÂøÁßÀÎ ÃÑµé °¡Á®¿À±â 
    /// </summary>
    private void SetGunList()
    {
        Transform[] gunPosList = _gunComponent._gunPosList; 
        foreach(Transform gunPosParent in gunPosList)
        {
            int gunCount = gunPosParent.childCount;
            for(int i = 0; i < gunCount; i++)
            {
                _guns.Add(gunPosParent.GetChild(i).GetComponent<AbstractGun>());
            }
        }
        //for(int i =0; i < _gunParent.childCount; i++)
        //{
        //    _guns.Add(_gunParent.Find("GunPos").GetChild(i).GetComponent<AbstractGun>());
        //}
    }

}
