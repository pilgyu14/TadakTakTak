using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/GunSO")]
public class GunSO : ScriptableObject
{
    public GameObject gunPrefab; // �� ������
    public BulletSO bulletSO; 

    public int bulletCount; // ���� �Ѿ� ����
    [Range(0, 999)] public int ammoCapacity; // �ִ� �Ѿ� ����
    [Range(0.1f, 2f)] public float shotDelay; // ��� �� ������
    [Range(0.1f, 2f)] public float reloadDelay; // ������ �ð� 


    public bool isMultiShot; // ������ �����ǰ� 
    public int multiShotCount; // ������ ���� � �����
    
    [Range(0,10f)] public float shotAngle; // �Ѿ� ������ ���� 

    public GameObject shotEffect; // ������ ����Ʈ  
    public AudioClip shootClip;
    public AudioClip outOfAmmoClip;
    public AudioClip reloadClip;

    public Sprite sprite;

    
}
