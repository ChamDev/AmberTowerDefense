using System;
using System.Collections;
using Ui;
using UI;
using UnityEngine;

namespace Managers
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private GameObject winningScreen;
		[SerializeField] private GameObject losingScreen;
		
		private int _numberEnemiesToDefeat;
		private bool _isPointerOnAllowedArea = false;
		private int _enemyScore = 5;
		
		private Score _score;
		private HealthBar _playerHealth;

		private void Awake()
		{
			_score = GameObject.FindObjectOfType<Score>();
		}


		public int NumberEnemiesToDefeat
		{
			get => _numberEnemiesToDefeat;
			set => _numberEnemiesToDefeat = value;
		}

		public int EnemyScore
		{
			get => _enemyScore;
			set => _enemyScore = value;
		}

		public bool isPointerOnAllowedArea()
		{
			return _isPointerOnAllowedArea;
		}

		public void SetPointerAllowed(bool isPointerAllowed)
		{
			_isPointerOnAllowedArea = isPointerAllowed;
		}
		
		public void GameOver(bool playerHasWon)
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

		public void AddScore(int score)
		{
			_score.AddScore(score);
		}

		public void DamagePlayerHealth(int damage)
		{
			var playerDead = _playerHealth.ApplyDamage(damage);

			if (playerDead)
			{
				GameOver(false);
			}
			
			EnemyDefeated();
		}
		
		public void EnemyDefeated()
		{
			NumberEnemiesToDefeat--;
			AddScore(_enemyScore);
		}
	}
}

