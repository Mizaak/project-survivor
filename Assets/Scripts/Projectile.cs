using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Projectile", menuName = "Skills/Projectile")]
public class Projectile : Skill
{
    [Space(10)]
    [Header("SKILL CUSTOM PARAMETERS")]
    [Header("REFERENCES")]
    [SerializeField] private GameObject projectilePrefab;

    [Header("PARAMETERS")]
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private float projectileSpeed;

    private Transform target;

    public override void Init() => base.Init();
    public override void ManageCooldown()
    {
        if (learned)
        {
            skillActualCooldown -= Time.deltaTime;

            if (skillActualCooldown <= 0)
            {
                if (CheckActivationConditions())
                {
                    ActivateSkill();
                    skillActualCooldown = skillBaseCooldown;
                }
            }
        }
    }
    public override bool CheckActivationConditions()
    {
        Collider2D[] enemiesFound = Physics2D.OverlapCircleAll(PlayerController.instance.transform.position, SkillRange, enemyLayerMask);
        if (enemiesFound.Length <= 0)
            return false;

        float minDistance = SkillRange + 1f;
        Transform closestEnemy = null;

        foreach (Collider2D enemy in enemiesFound)
        {
            if (!enemy.gameObject.activeInHierarchy)
                continue;

            float distanceFromPlayer = Vector3.Distance(PlayerController.instance.transform.position, enemy.transform.position);
            if (distanceFromPlayer < minDistance)
            {
                minDistance = distanceFromPlayer;
                closestEnemy = enemy.transform;
            }
        }

        target = closestEnemy;

        return target != null;
    }
    public override void ActivateSkill()
    {
        GameObject newprojectile = Instantiate(projectilePrefab);
        newprojectile.transform.position = PlayerController.instance.transform.position;
        newprojectile.GetComponent<ProjectileController>().Init(target, projectileSpeed);
    }
}
