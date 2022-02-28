using System;
using Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        
        private Image _fillingImage;
        private int _currentHealth;
        public static Action OnPlayerDead;
        
        private void Awake()
        {
            _fillingImage = GetComponent<Image>();
            _currentHealth = maxHealth;
            EnemyDamage.OnEnemyHit += ApplyDamage;
        }

        private void Start()
        {
            UpdateHealthBar();
        }

        private void OnDestroy()
        {
            EnemyDamage.OnEnemyHit -= ApplyDamage;
        }

        public void ApplyDamage(int damage){
            
            _currentHealth -= damage;

            if(_currentHealth > 0){
                UpdateHealthBar();
            }
           
            _currentHealth = 0;
            UpdateHealthBar();
            OnPlayerDead?.Invoke();
        }
        
        void UpdateHealthBar(){
            //Calculating the percentage of health between 0 & 1 
            float percentage = _currentHealth * 1.0f / maxHealth;
            _fillingImage.fillAmount = percentage;
        }
    }
}

