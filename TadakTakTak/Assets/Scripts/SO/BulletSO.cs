using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/BulletSO")]
public class BulletSO : ScriptableObject
{
    public Bullet bulletPrefab; // 총알 프리팹
    [Range(1, 10)] public int damage; // 공격력
    [Range(100, 3000)] public int bulletSpeed; // 날아가는 속도 

    public bool isBumb; // 터지는가 
    [Range(0,10)]public float BombRadius; // 폭발 반경  
    private float lifeTime = 2f; 

    public Sprite bulletSprite; 

    public GameObject impactObstacleEffect; // 장애물에 부딪혔을때 이펙트
    public GameObject impactEnemyEffect; // 장애물에 부딪혔을때 이펙트

}