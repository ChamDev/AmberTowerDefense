using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IGameManager
{
    int NumberEnemiesToDefeat { get; set; }
    bool isPointerOnAllowedArea();
    void SetPointerAllowed(bool isPointerAllowed);
    void EnemyDefeated();
}
