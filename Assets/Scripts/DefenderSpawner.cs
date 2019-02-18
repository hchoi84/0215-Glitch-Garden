using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defender = default;

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt();
    }

    private void AttemptToPlaceDefenderAt()
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender();
            StarDisplay.SpendStars(defenderCost);
        }
    }

    private void SpawnDefender()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 roundPos = new Vector2(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));
        Instantiate(defender, new Vector3(roundPos.x, roundPos.y, -1), Quaternion.identity);
    }

    //Called from DefenderButton
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }
}
