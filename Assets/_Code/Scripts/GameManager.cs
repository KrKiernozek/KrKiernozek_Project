using System;
using System.Collections;
using System.Collections.Generic;
using _Code.Scripts.ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = "GameManager";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }
    #endregion
    
    public EnemySpawner enemySpawner;
    public MusicManager musicManager;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI towerCostText;

    public GameObject gameOverPanel;
    
    public int money;
    public int score;
    public int wave;
    public int towerCost;
    public int enemiesDeathCount;
    public bool gameStatus = true;

    private void Start()
    {
        enemySpawner.StartWave(wave);
        AddAndSetWave(wave);
        AddAndSetMoney(0);
    }

    public void EnemyDied(int moneyReward)
    {
        AddAndSetMoney(moneyReward);
        enemiesDeathCount += 1;
        
        if (enemySpawner.CheckEnemyCount(wave, enemiesDeathCount))
        {
            if (!gameStatus) return;
            wave += 1;
            enemySpawner.StartWave(wave);
            AddAndSetWave(wave);
        }
    }

    public void GameOver()
    {
        gameStatus = false;
        gameOverPanel.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void AddAndSetMoney(int value)
    {
        money += value;
        moneyText.text = money.ToString();
        SetScore(money);
    }
    
    public void SetScore(int value)
    {
        score = value;
        scoreText.text = score.ToString();
    }

    public void SetTowerCost(int value)
    {
        towerCost = value;
        towerCostText.text = towerCost.ToString();
    }
    
    public void AddAndSetWave(int value)
    {
        waveText.text = value.ToString();
    }
    
}