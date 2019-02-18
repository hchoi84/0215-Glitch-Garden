using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab = default;

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
