using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cactus = default;

    private void OnMouseDown()
    {
        SpawnDefender();
    }

    private void SpawnDefender()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 roundPos = new Vector2(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));
        Instantiate(cactus, new Vector3(roundPos.x, roundPos.y, -1), Quaternion.identity);
    }
}
