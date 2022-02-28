using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Ui;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject winningScreen;
    [SerializeField] private GameObject losingScreen;

    private void Awake()
    {
        EnemySpawner.OnEnemiesDefeated += Victory;
        HealthBar.OnPlayerDead += GameOver;
    }

    private void OnDestroy()
    {
        EnemySpawner.OnEnemiesDefeated -= Victory;
        HealthBar.OnPlayerDead -= GameOver;
    }


    void Victory()
    {
        winningScreen.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void GameOver()
    {
        losingScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
