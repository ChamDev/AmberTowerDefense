using System;
using Managers;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemyDamage : MonoBehaviour
    {
        [SerializeField] private int damage = 10;
        [Inject] private IGameManager _gameManager;
        
        public static Action<int> OnEnemyHit;
        private EnemyHealth _enemyHealth;
        
        private void Awake()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
        }

        public void MakeDamage()
        {
            OnEnemyHit?.Invoke(damage);
            _enemyHealth.EnemyDead();
        }
    }
}
