using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVitalPoints : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public List<Image> hearts;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent(typeof(Enemy)) != null)
        {
            TakeDamage();
            col.gameObject.GetComponent<Enemy>().Die();
        }
    }

    private void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            UpdateHearts();
            GameOver();
        }
        else
        {
            UpdateHearts();
        }
    }

    private void GameOver()
    {
        GameManager.Instance.GameOver();
    }

    private void UpdateHearts()
    {
        if(currentHealth >= 0)hearts[currentHealth].gameObject.SetActive(false);
    }
}
