using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Wave> proceduralWaves;
    public float spawnInterval;

    public void StartWave(int waveNumber)
    {
        if(waveNumber <= proceduralWaves.Count)StartCoroutine(SpawnWave(proceduralWaves[waveNumber]));
    }

    public bool CheckEnemyCount(int waveNumber, int currentWaveEnemiesDeathCount)
    {
        if (currentWaveEnemiesDeathCount == proceduralWaves[waveNumber].wave.Count) return true;
        else
        {
            return false;
        }
    }
    
    private IEnumerator SpawnWave(Wave wave)
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < wave.wave.Count; i++)
        {
            Instantiate(wave.wave[i], transform.position, Quaternion.identity,transform);
            yield return new WaitForSeconds(spawnInterval);
        }
        
    }
}
