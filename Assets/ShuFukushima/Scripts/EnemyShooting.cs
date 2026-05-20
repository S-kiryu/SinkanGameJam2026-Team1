using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private EnemyAttackBase[] attacks;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform playerTransform;

    private float cooldownTimer = 0f;

    void Update()
    {
        if (attacks == null || attacks.Length == 0) return;
        if (muzzle == null || playerTransform == null) return;

        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0f) return;

        EnemyAttackBase attack = GetRandomAttack();
        if (attack == null) return;

        attack.ExecuteAttack(transform, muzzle, playerTransform);

        // 今回使った攻撃のクールタイムを待つ
        cooldownTimer = attack.Interval;
    }

    private EnemyAttackBase GetRandomAttack()
    {
        int index = Random.Range(0, attacks.Length);
        return attacks[index];
    }
}