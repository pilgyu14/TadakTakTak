using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletSO bulletSO;
    private Rigidbody _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>(); 
    
    }
    public void SetInfo(BulletSO bulletSO)
    {
        this.bulletSO = bulletSO; 
    }
    public void Shotted()
    {
        if (_rigid == null)
        {
            _rigid = GetComponent<Rigidbody>();
        }
        _rigid.AddForce(transform.forward * bulletSO.bulletSpeed);
        
    }

}
