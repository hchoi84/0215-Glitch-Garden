using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defender defender = collision.GetComponent<Defender>();
        if (defender)
        {
            GetComponent<Attacker>().Attack(defender);
        }
    }
}
