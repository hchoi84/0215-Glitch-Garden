using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private float projectileRPM = 10f;
    [SerializeField] private float damage = 10f;
    Vector3 pos;

    void Update()
    {
        FireProjectile();
    }

    private void FireProjectile()
    {
        pos = transform.position;
        pos += Vector3.right * projectileSpeed * Time.deltaTime;
        transform.position = pos;
        //transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -projectileRPM));
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
