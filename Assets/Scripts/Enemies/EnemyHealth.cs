using System;
using Managers;
using Projectiles;
using UnityEngine;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float health = 100f;
        [SerializeField] private string projectileTag = "Projectile";

        private GameManager _gameManager;
        
        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(projectileTag))
            {
                Hit(other.GetComponent<Projectile>().Damage);
                other.gameObject.SetActive(false);
            }
        }

        void Hit(float damage)
        {
            health -= damage;
				
            if (health <= 0) //estoy vivo aún
            {
                _gameManager.EnemyDefeated();
                gameObject.SetActive(false);
            } 
        }
    }
}
