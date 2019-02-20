using UnityEngine;
using TMPro;
using System;

public class LivesDisplay : MonoBehaviour
{
    private TextMeshProUGUI livesText = default;
    private int lives = 10;
    private LevelController levelController;

    private void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        levelController = FindObjectOfType<LevelController>();
        SetLives();
    }

    private void SetLives()
    {
        if(PlayerPrefsController.GetDifficulty() == 0)
        {
            lives = 10;
        }
        else
        {
            lives -= (int)(PlayerPrefsController.GetDifficulty() * 2);
        }
    }

    private void Update()
    {
        DisplayLives();
        if(lives <= 0)
        {
            levelController.HandleLoseCondition();
        }
    }

    private void DisplayLives()
    {
        livesText.text = lives.ToString();
    }

    //Called from LoseCollider.cs
    public void SubtractLives()
    {
        lives--;
    }
}
