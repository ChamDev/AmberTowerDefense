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
        private GameManager _gameManager;
        private Score _score;
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(PurchaseTower);
        }

        private void PurchaseTower()
        {
            var price = towerPrefab.GetComponent<Tower>().InitialCost;

            if (price <= _score.GetScore())
            {
                _score.AddScore(-price);
                Instantiate(towerPrefab);
            }
        }
    }
}
