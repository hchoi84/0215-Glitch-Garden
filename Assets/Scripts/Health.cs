using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 20f;
    [SerializeField] private GameObject explosionParticleSystem = default;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(explosionParticleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
