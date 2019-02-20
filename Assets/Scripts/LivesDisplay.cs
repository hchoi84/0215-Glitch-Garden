using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    private TextMeshProUGUI livesText = default;
    private int lives = 10;
    private LevelController levelController;

    private void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        levelController = FindObjectOfType<LevelController>();
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

    public void SubtractLives()
    {
        lives--;
    }
}
