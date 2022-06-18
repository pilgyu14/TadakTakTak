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
    private bool isEmpty; // ��� ���� �Ѿ��� ����°� 
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
    /// �� ��� 
    /// </summary>
    public void Shoot()
    {
        _guns.ForEach(x => x.Fire());
    }

    /// <summary>
    /// ���� �������� �ѵ� �������� 
    /// </summary>
    private void SetGunList()
    {
        for(int i =0; i < _gunParent.childCount; i++)
        {
            _guns.Add(_gunParent.Find("GunPos").GetChild(i).GetComponent<AbstractGun>());
        }
    }

}
