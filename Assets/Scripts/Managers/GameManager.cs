using System;
using System.Collections;
using Ui;
using UI;
using UnityEngine;

namespace Managers
{
	public class GameManager : IGameManager
	{
		private int _numberEnemiesToDefeat;
		private bool _isPointerOnAllowedArea = false;

		public int NumberEnemiesToDefeat
		{
			get => _numberEnemiesToDefeat;
			set => _numberEnemiesToDefeat = value;
		}

		public bool isPointerOnAllowedArea()
		{
			return _isPointerOnAllowedArea;
		}

		public void SetPointerAllowed(bool isPointerAllowed)
		{
			_isPointerOnAllowedArea = isPointerAllowed;
		}
		
		public void EnemyDefeated()
		{
			NumberEnemiesToDefeat--;
		}
	}
}

