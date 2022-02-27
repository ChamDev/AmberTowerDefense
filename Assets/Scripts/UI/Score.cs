using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
   public class Score : MonoBehaviour
   {
      [SerializeField] private Text _scoreText;
      private int _score;

      private void Awake()
      {
         if (_scoreText == null)
         {
            _scoreText = GetComponent<Text>();
         }
         
      }

      public void AddScore(int score)
      {
         _score += score;

         if (_score <= 0)
         {
            _score = 0;
         }

         UpdateScore();
      }

      public int GetScore()
      {
         return _score;
      }

      void UpdateScore()
      {
         _scoreText.text = _score.ToString();
      }
   }
}
