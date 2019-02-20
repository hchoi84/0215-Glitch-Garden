using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab = default;
    private TextMeshProUGUI starCostText = default;

    private void Start()
    {
        starCostText = GetComponentInChildren<TextMeshProUGUI>();
        starCostText.text = defenderPrefab.GetComponent<Defender>().GetStarCost().ToString();
    }

    private void OnMouseDown()
    {
        DefenderButton[] defenderButtons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton defenderButton in defenderButtons)
        {
            defenderButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
