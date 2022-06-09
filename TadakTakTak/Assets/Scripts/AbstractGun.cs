using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGun : MonoBehaviour,IGun
{
    [SerializeField]
    protected GunSO gunSO;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Fire()
    {
        Bullet bullet = Instantiate(gunSO.bulletSO.bulletPrefab);
        bullet.SetInfo(gunSO.bulletSO);
        bullet.Shotted(); 
    }

    public void Reload()
    {

    }

}
