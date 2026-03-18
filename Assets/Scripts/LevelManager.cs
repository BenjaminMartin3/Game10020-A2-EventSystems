using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; 

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI coinCounter;
    public TextMeshProUGUI hpCounter;

    public int playerHP = 3;

    int coinsCollected = 0;
    int playerMaxHP = 3;

    private void Update()
    {
        coinCounter.text = ($"- {coinsCollected}");
        hpCounter.text = ($"- {playerHP}");
    }

    public void CollectCoin()
    {
        coinsCollected++;
    }

    public void RaiseHP()
    {
        playerHP++;
        playerHP = playerMaxHP;
    }

    public void LowerHP(int damage)
    {
        playerHP -= damage;
        if (playerHP < 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Lose"); 
    }
}
