using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerSpawner : MonoBehaviour
{
    public List<Tower> playerTowerDeck;
    public List<Transform> towerPivots;
    public int towerCost;
    public int towerCostIncrease;
    private List<bool> pivotIsBusy;
    private int freeSpaceId;

    private void Awake()
    {
        pivotIsBusy = new List<bool>(new bool[towerPivots.Count]);
        GameManager.Instance.SetTowerCost(towerCost);
    }

    public void BuyTower()
    {
        
        if (GameManager.Instance.money < GameManager.Instance.towerCost) return;
        GameManager.Instance.AddAndSetMoney(-towerCost);
        SpawnTower();
        towerCost += towerCostIncrease;
        GameManager.Instance.SetTowerCost(towerCost);
    }

    private void SpawnTower()
    {
        //Check if any space is free
        for (int i = 0; i < pivotIsBusy.Capacity; i++)
        {
            if (pivotIsBusy[i] == false)
            {
                freeSpaceId = i;
                break;
            }
        }

        //int randomNumber = GetRandomFreeSpace(); WIP


        //Spawn Tower at random free space
        int randomTower = Random.Range(0, playerTowerDeck.Count);
        Tower spawnedTower = Instantiate(
            playerTowerDeck[randomTower],
            towerPivots[freeSpaceId].transform.position,
            Quaternion.identity,towerPivots[freeSpaceId].transform);

        spawnedTower.enemySpawner = GameManager.Instance.enemySpawner.transform;
        //Set pivot busy on private list
        pivotIsBusy[freeSpaceId] = true;

    }


    #region WIP

    
    // private bool CheckPivotBusy(int value)
    // {
    //     if (pivotIsBusy[value] == true) return true;
    //     else
    //     {
    //         return false;
    //     }
    // }
    //
    // private int GetRandomFreeSpace()
    // {
    //     int randomNumber = Random.Range(0, towerPivots.Count);
    //     
    //     switch (randomNumber)
    //     {
    //         case 0:
    //             if (pivotIsBusy[randomNumber] == true)
    //             {
    //                 GetRandomFreeSpace();
    //                 break;
    //             }
    //             else
    //             {
    //                 break;
    //             }
    //         case 1:
    //             if (pivotIsBusy[randomNumber] == true) GetRandomFreeSpace();
    //             break;
    //         case 2:
    //             print("Random number:  2");
    //             break;
    //         case 3:
    //             print("Random number:  3");
    //             break;
    //         default:
    //             print("Random number:  Default");
    //             break;
    //     }
    //     return randomNumber;
    // }

    #endregion
}
