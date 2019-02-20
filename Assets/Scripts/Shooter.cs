using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab = default;
    [SerializeField] private Transform projectilePos = default;
    AttackerSpawner myLaneSpawner = default;
    Animator animator;
    private GameObject projectileParent = default;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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

    //Called from Animator
    private void TriggerProjectils()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, projectilePos.position, Quaternion.identity);
        newProjectile.transform.parent = projectileParent.transform;
    }
}
