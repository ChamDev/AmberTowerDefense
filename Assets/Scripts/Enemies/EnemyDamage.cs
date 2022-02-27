using System;
using Managers;
using UnityEngine;

namespace Enemies
{
    public class EnemyDamage : MonoBehaviour
    {
        [SerializeField] private int damage = 10;
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        public void MakeDamage()
        {
            _gameManager.DamagePlayerHealth(damage);
        }
    }
}
