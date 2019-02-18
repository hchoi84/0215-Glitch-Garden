using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab = default;
    [SerializeField] private Transform projectilePos = default;

    private void TriggerProjectils()
    {
        Instantiate(projectilePrefab, projectilePos.position, Quaternion.identity);
    }
}
