using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private float damage = 10f;

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        if (attacker && health)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
