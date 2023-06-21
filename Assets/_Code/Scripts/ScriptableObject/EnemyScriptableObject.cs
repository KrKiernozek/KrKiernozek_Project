using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Tower Defense/Enemy Data", order = 1)]
public class EnemyScriptableObject : ScriptableObject
{
    public int health;
    public float speed;
    public int moneyReward;
}
