using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
     
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    
   [System.Serializable]
    public class Wave
    {
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    public Transform spawnPoint;
    private int nextWave = 0;
    public float TimeBetweenWaves = 5f;
    public float waveCountdown;
    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.COUNTING;
    public Animator animator;
    void Start()
    {
        waveCountdown = TimeBetweenWaves;
    }
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
           
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }
    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = TimeBetweenWaves;
        

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave -= 1;
            waves[nextWave].count += 1;
        }
        else
        {
            nextWave++;
        }
    }
    bool EnemyIsAlive()
    {
       searchCountdown -= Time.deltaTime;

       if (searchCountdown <= 0f)
       {
           searchCountdown = 1f;
           if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 3)
        { 
            return false; 
        }

       }
        
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;
        animator.SetBool("Spawning", true);
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        animator.SetBool("Spawning", false);

        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
       
    }

}
