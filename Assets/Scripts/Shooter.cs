using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab = default;
    [SerializeField] private Transform projectilePos = default;

    private void TriggerProjectils()
    {
        Instantiate(projectilePrefab, projectilePos.position, Quaternion.identity);
    }
}
