using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        private Image _fillingImage;
        private int _currentHealth;

        private void Awake()
        {
            _fillingImage = GetComponent<Image>();
            _currentHealth = maxHealth;
            UpdateHealthBar();
        }
        
        public bool ApplyDamage(int damage){
            
            _currentHealth -= damage;

            if(_currentHealth > 0){
                UpdateHealthBar();
                return false;
            }
           
            _currentHealth = 0;
            UpdateHealthBar();
            return true;
        }
        
        void UpdateHealthBar(){
            //Calculating the percentage of health between 0 & 1 
            float percentage = _currentHealth * 1.0f / maxHealth;
            _fillingImage.fillAmount = percentage;
        }
    }
}

