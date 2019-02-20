using System;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defender = default;
    GameObject defenderParent = default;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

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
        Defender newDefender = Instantiate(defender, new Vector3(roundPos.x, roundPos.y, -1), Quaternion.identity);
        newDefender.transform.parent = defenderParent.transform;
    }

    //Called from DefenderButton
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }
}
