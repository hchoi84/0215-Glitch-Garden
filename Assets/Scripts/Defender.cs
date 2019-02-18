using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int starCost = 100;
    private StarDisplay starDisplay = default;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    // Called from Trophy Animation Event
    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
