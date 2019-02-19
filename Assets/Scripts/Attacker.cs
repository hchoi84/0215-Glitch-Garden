using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float moveSpeed = 1f;
    Defender currentTarget;
    Animator animator;

    private void Start()
    { animator = GetComponent<Animator>(); }

    void Update()
    {
        MoveLeft();
        StopAttackAnimation();
    }

    private void MoveLeft()
    { transform.Translate(Vector2.left * Time.deltaTime * moveSpeed); }

    private void StopAttackAnimation()
    {
        if (!currentTarget)
        { animator.SetBool("isAttacking", false); }
    }

    // This method is called from Animation
    public void SetMovementSpeed(float speed)
    { moveSpeed = speed; }

    //Called from Lizard.cs
    public void Attack(Defender target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    //Called from animation attacking. Damage set within event
    public void StrikeCurrentTarget(float damage)
    {
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        { health.TakeDamage(damage); }
        else { return; }
    }
}
