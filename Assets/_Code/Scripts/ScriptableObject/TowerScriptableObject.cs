using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower Data", menuName = "Tower Defense/Tower Data", order = 1)]
public class TowerScriptableObject : ScriptableObject
{
    public float fireRate;
    public int damage;
    public float bulletSize;
    //public GameObject bulletPrefab;
}
