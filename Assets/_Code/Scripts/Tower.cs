using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Bullet bulletprefab;
    public TowerScriptableObject towerData;
    public Transform towerCannonPivot;
    public Transform enemySpawner;
    [SerializeField] private float fireCountdown = 0f;
    [SerializeField] private float fireRate;
    [SerializeField] private int damage;
    [SerializeField] private float bulletSize;

    private void Start()
    {
        if (towerData !=null)
        {
            fireRate = towerData.fireRate;
            damage = towerData.damage;
            bulletSize = towerData.bulletSize;
        }
    }

    private void Update()
    {
        if (enemySpawner != null || towerCannonPivot != null)
        {
            if (enemySpawner.childCount > 0)
            {
                towerCannonPivot.LookAt(enemySpawner.GetChild(0));
                
                if (fireCountdown  <= 0f)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate;
                }

                fireCountdown -= Time.deltaTime;
            }
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletprefab, transform.position,transform.rotation,transform);
        bullet.SetValues(enemySpawner.GetChild(0),damage);
    }
}
