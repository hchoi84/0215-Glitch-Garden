using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab = default;
    [SerializeField] private Transform projectilePos = default;
    AttackerSpawner myLaneSpawner = default;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner attackerSpawner in attackerSpawners)
        {
            bool IsCloseEnough = Mathf.Abs(attackerSpawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (IsCloseEnough)
            {
                myLaneSpawner = attackerSpawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return myLaneSpawner.transform.childCount > 0;
    }

    private void TriggerProjectils()
    {
        Instantiate(projectilePrefab, projectilePos.position, Quaternion.identity);
    }
}
