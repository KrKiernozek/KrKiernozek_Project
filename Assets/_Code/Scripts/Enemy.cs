using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    public int health;
    public float speed;
    public int moneyReward;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        health = enemyData.health;
        speed = enemyData.speed;
        moneyReward = enemyData.moneyReward;
        healthText.text = enemyData.health.ToString();
    }

    private void Update()
    {
        transform.position = (transform.position + new Vector3(0,speed/100f,0));
    }

    public void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0) Die();
        healthText.text = health.ToString();
    }

    public void Die()
    {
        GameManager.Instance.EnemyDied(moneyReward);
        Destroy(gameObject);
    }
}
