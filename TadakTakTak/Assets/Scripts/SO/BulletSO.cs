using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/BulletSO")]
public class BulletSO : ScriptableObject
{
    public Bullet bulletPrefab; // �Ѿ� ������
    [Range(1, 10)] public int damage; // ���ݷ�
    [Range(100, 3000)] public int bulletSpeed; // ���ư��� �ӵ� 

    public bool isBumb; // �����°� 
    [Range(0,10)]public float BombRadius; // ���� �ݰ�  
    private float lifeTime = 2f; 

    public Sprite bulletSprite; 

    public GameObject impactObstacleEffect; // ��ֹ��� �ε������� ����Ʈ
    public GameObject impactEnemyEffect; // ��ֹ��� �ε������� ����Ʈ

}