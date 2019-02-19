using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    private TextMeshProUGUI livesText = default;
    private int lives = 10;

    private void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        DisplayLives();
        if(lives <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadGameOverScene();
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
