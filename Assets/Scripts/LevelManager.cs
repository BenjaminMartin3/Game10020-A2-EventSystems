using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; 

public class LevelManager : MonoBehaviour
{
    // UI for Coin and HP counters
    public TextMeshProUGUI coinCounter;
    public TextMeshProUGUI hpCounter;

    // Int for player's current HP
    public int playerHP = 3;

    // Int for player's max HP
    int playerMaxHP = 3;

    // Int for amount of coins collected
    int coinsCollected = 0;


    private void Update()
    {
        // Update changes in UI 
        coinCounter.text = ($"- {coinsCollected}");
        hpCounter.text = ($"- {playerHP}");
    }

    public void CollectCoin()
    {
        // Add a coin to counter when collected
        coinsCollected++;
    }

    public void RaiseHP()
    {
        // Raise HP when Potion is collected
        playerHP++;
        // Cap HP if already max
        playerHP = playerMaxHP;
    }

    public void LowerHP(int damage)
    {
        // Lower HP by whatever damage is taken 
        playerHP -= damage;

        // Call Game Over function if HP reaches or below 0
        if (playerHP <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        // Load Lose Scene
        SceneManager.LoadScene("Lose"); 
    }
}
