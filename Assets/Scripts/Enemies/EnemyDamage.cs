using Managers;
using UnityEngine;

namespace Enemies
{
    public class EnemyDamage : MonoBehaviour
    {
        [SerializeField] private int damage;
        private GameManager _gameManager;
        
        public void MakeDamage()
        {
            _gameManager.DamagePlayerHealth(damage);
        }
    }
}
