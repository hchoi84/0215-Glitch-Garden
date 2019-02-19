using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defender defender = collision.GetComponent<Defender>();
        if (defender)
        {
            if (collision.gameObject.name == "Gravestone")
            {
                animator.SetTrigger("isJumping");
            }
            else
            {
                GetComponent<Attacker>().Attack(defender);
            }
        }
    }
}
