using System;
using Managers;
using Towers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonPurchaseTower : MonoBehaviour
    {
        private Button _button;
        [SerializeField] private GameObject towerPrefab;
        [SerializeField] private Text costText;
        private Score _score;
        private int _price;
        
        private void Awake()
        {
            _score = FindObjectOfType<Score>();
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _price = towerPrefab.GetComponent<Tower>().InitialCost;
            costText.text = _price.ToString();
            _button.onClick.AddListener(PurchaseTower);
        }

        private void PurchaseTower()
        {
            if (_price <= _score.GetScore())
            {
                _score.AddScore(-_price);
                Instantiate(towerPrefab);
            }
        }
    }
}
