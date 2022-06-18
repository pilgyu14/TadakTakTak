using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGun : MonoBehaviour,IGun
{
    [SerializeField]
    protected GunSO gunSO;
    private Camera mainCam; 

    private bool _isDelay; // �������� 
    private float _curDelayTime = 0; 
    private Transform muzzlePos; 

    private float currentDelay;
    Ray ray;
    
    void Start()
    {
        muzzlePos    = transform.Find("Muzzle").transform;
    }

    void Update()
    {
        ShotDelay();
    }

    private void ShotDelay()
    {
        if (_isDelay == false) // �������� �ƴҶ� ����
        {
            return; 
        }

        if (_curDelayTime >= gunSO.shotDelay) // ���������ε� ������ �ð� ��ä������ 
        {
            _isDelay = false;
            _curDelayTime = 0; 
            return;
        }
        _curDelayTime += Time.deltaTime; 
    }
    public void Fire()
    {
        if (_isDelay == true) return; 

        Bullet bullet = Instantiate(gunSO.bulletSO.bulletPrefab, muzzlePos.position,muzzlePos.rotation);
        //bullet.transform.position = muzzlePos.position; 
        bullet.SetInfo(gunSO.bulletSO);
        bullet.Shotted();
        StartCoroutine(DelayGun()); 
    }

    public void Reload()
    {

    }

   public IEnumerator DelayGun()
    {
        _isDelay = true;
        while (_isDelay == true)
        {
            currentDelay += Time.deltaTime;
            if (currentDelay >= gunSO.shotDelay)
            {
                _isDelay = false;
                currentDelay = 0;
                break; 
            }
            yield return null; 
        }
        
    }
}
