using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using Zenject;

namespace Managers
{
    public class EnemySpawner : MonoBehaviour
    {
        
        [SerializeField] private int enemiesPerWave = 5;
        [SerializeField] private int increaseEnemiesPerWave = 3;
        [SerializeField] private int numberOfWaves = 2;
        [SerializeField] private float initialTimeToWait = 3;
        [SerializeField] private float timeMaxToWait = 5;
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private Transform spawnPoint;

        private int _enemyIndex = 0;
        private float _timeToWait = 1;
        
        [Inject] private IGameManager _gameManager;
        
        public static Action OnEnemiesDefeated;
        private ObjectPool [] _objectPool;
        private const int poolAmountEnemies = 10;
        
        private void Start()
        {
            _objectPool = new ObjectPool[enemyPrefabs.Length];

            for (int i = 0; i < _objectPool.Length; i++)
            {
                _objectPool[i] = gameObject.AddComponent<ObjectPool>();
                _objectPool[i].PoolingObjects(enemyPrefabs[i], poolAmountEnemies);
            }
            
            StartCoroutine(EnemyWaveSpawner());
        }

        IEnumerator EnemyWaveSpawner()
        {
            yield return new WaitForSeconds(initialTimeToWait);
            
            for (int i = 0; i < numberOfWaves; i++)
            {
                //Wait Until all the enemies has been spawned and defeated
                yield return SpawningEnemies();

                enemiesPerWave += increaseEnemiesPerWave;
            }
            //Win Condition
            OnEnemiesDefeated?.Invoke();
        }

        IEnumerator SpawningEnemies()
        {
            _gameManager.NumberEnemiesToDefeat = enemiesPerWave;
           
            
            for (int i = 0; i < enemiesPerWave; i++)
            {
                _enemyIndex = Random.Range(0, enemyPrefabs.Length);
                //Using the pool of enemies
                GameObject enemyObj =  _objectPool[_enemyIndex].GetPooledObject();
                
                if (enemyObj != null)
                {
                    enemyObj.transform.position = spawnPoint.position;
                    enemyObj.transform.rotation = spawnPoint.rotation;
                    enemyObj.SetActive(true);
                }
                
                _timeToWait = Random.Range(1, timeMaxToWait);

                yield return new WaitForSeconds(_timeToWait);
            }
            
            yield return new WaitUntil(() => _gameManager.NumberEnemiesToDefeat <= 0);
        }
    }
}
