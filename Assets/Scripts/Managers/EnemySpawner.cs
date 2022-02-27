using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class EnemySpawner : MonoBehaviour
    {
        
        [SerializeField] private int enemiesPerWave = 5;
        [SerializeField] private int increaseEnemiesPerWave = 3;
        [SerializeField] private int numberOfWaves = 2;
        [SerializeField] private float timeMaxToWait = 5;
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private Transform spawnPoint;

        private int _enemyIndex = 0;
        private GameManager _gameManager;
        private float _timeToWait = 1;
        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Start()
        {
            StartCoroutine(EnemyWaveSpawner());
        }

        IEnumerator EnemyWaveSpawner()
        {
            for (int i = 0; i < numberOfWaves; i++)
            {
                yield return SpawningEnemies();

                enemiesPerWave += increaseEnemiesPerWave;
            }
            
            _gameManager.GameOver(true);
        }

        IEnumerator SpawningEnemies()
        {
            _gameManager.NumberEnemiesToDefeat = enemiesPerWave;
            _enemyIndex = Random.Range(0, enemyPrefabs.Length);
            
            for (int i = 0; i < enemiesPerWave; i++)
            {
                Instantiate(enemyPrefabs[_enemyIndex], spawnPoint.position, quaternion.identity);

                _timeToWait = Random.Range(0, timeMaxToWait);

                yield return new WaitForSeconds(_timeToWait);
            }
            
            yield return new WaitUntil(() => _gameManager.NumberEnemiesToDefeat <= 0);
        }
    }
}
