using System.Collections;
using UnityEngine;

namespace Managers
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private GameObject winningScreen;
		[SerializeField] private GameObject losingScreen;
		
		private bool _isPointerOnAllowedArea = false;
		
		public bool isPointerOnAllowedArea()
		{
			return _isPointerOnAllowedArea;
		}

		public void SetPointerAllowed(bool isPointerAllowed)
		{
			_isPointerOnAllowedArea = isPointerAllowed;
		}
		
		private void GameOver(bool playerHasWon)
		{
			if (playerHasWon)
			{
				winningScreen.SetActive(true);
			}
			else
			{
				losingScreen.SetActive(true);
			}
			
			Time.timeScale = 0;
		}
	}
}

