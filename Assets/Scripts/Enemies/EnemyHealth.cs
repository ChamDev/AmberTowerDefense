using System;
using Managers;
using Projectiles;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float health = 100f;
        [SerializeField] private string projectileTag = "Projectile";
        [SerializeField] private int scoreWhenDie = 5;

        [Inject] private IGameManager _gameManager;
        public static Action<int> OnEnemyDead;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(projectileTag))
            {
                EnemyHitted(other.GetComponent<Projectile>().Damage);
                other.gameObject.SetActive(false);
            }
        }

        void EnemyHitted(float damage)
        {
            health -= damage;
				
            if (health <= 0)
            {
                EnemyDead();
            } 
        }

        public void EnemyDead()
        {
            _gameManager.EnemyDefeated();
            OnEnemyDead?.Invoke(scoreWhenDie);
            gameObject.SetActive(false);
        }
    }
}
