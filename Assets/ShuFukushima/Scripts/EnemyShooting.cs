using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private EnemyAttackBase[] attacks;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform playerTransform;

    private bool isAttacking;
    private float cooldownTimer;

    private void Update()
    {
        if (isAttacking) return;
        if (attacks == null || attacks.Length == 0) return;
        if (muzzle == null || playerTransform == null) return;

        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer > 0f) return;

        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        isAttacking = true;

        EnemyAttackBase attack = GetRandomAttack();
        if (attack != null)
        {
            yield return StartCoroutine(attack.ExecuteAttack(transform, muzzle, playerTransform));
            cooldownTimer = attack.Interval;
        }

        isAttacking = false;
    }

    private EnemyAttackBase GetRandomAttack()
    {
        int index = Random.Range(0, attacks.Length);
        return attacks[index];
    }
}