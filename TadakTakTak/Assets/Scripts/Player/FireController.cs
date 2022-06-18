using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField]
    private List<AbstractGun> _guns;

    [SerializeField]
    private Transform _gunParent; 

    private float shootDelay; 
    private bool isEmpty; // 모든 총의 총알이 비었는가 
    void Start()
    {
        SetGunList(); 
    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Shoot(); 
        }
    }
    /// <summary>
    /// 총 쏘기 
    /// </summary>
    public void Shoot()
    {
        _guns.ForEach(x => x.Fire());
    }

    /// <summary>
    /// 현재 장착중인 총들 가져오기 
    /// </summary>
    private void SetGunList()
    {
        for(int i =0; i < _gunParent.childCount; i++)
        {
            _guns.Add(_gunParent.Find("GunPos").GetChild(i).GetComponent<AbstractGun>());
        }
    }

}
