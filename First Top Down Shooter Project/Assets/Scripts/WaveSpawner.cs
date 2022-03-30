using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour{

    [System.Serializable]
    public class Wave{

        public Enemy[] enemies;
        public int enemyCount;
        public float timeBetweenSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;
    public GameObject boss;
    public Transform bossSpawnPoint;
    public GameObject bossHealthBar;

    [HideInInspector]
    public bool bossDied = false;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;
    private bool finishedSpawning;

    private void Start(){

        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index){

        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index){

        currentWave = waves[index];
        yield return null;
        
        for(int i = 0; i < currentWave.enemyCount; i++){

            if (player == null){
                yield break;
            }

            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

            if(i == currentWave.enemyCount - 1){
                finishedSpawning = true;
            }

            else{
                finishedSpawning = false;
            }

            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }

    private void Update(){

        if (finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0){

            finishedSpawning = false;

            if(currentWaveIndex + 1 < waves.Length){

                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            } 
            
            else{

                Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
                bossHealthBar.SetActive(true);
            }
        }

        if(bossDied == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene("YouWin");
            Debug.Log("you win");
        }
    }
}
