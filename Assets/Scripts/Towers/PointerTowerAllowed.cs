using System;
using Managers;
using UnityEngine;
using Zenject;
namespace Towers
{
    public class PointerTowerAllowed : MonoBehaviour
    {
        [Inject] private IGameManager _gameManager;
        
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
