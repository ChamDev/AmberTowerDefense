using System;
using Managers;
using UnityEngine;

namespace Towers
{
    public class PointerTowerAllowed : MonoBehaviour
    {
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        void OnMouseEnter()
        {
            _gameManager.SetPointerAllowed(true);
        }
		
        void OnMouseExit()
        {
            _gameManager.SetPointerAllowed(false);
        }
    }
}
