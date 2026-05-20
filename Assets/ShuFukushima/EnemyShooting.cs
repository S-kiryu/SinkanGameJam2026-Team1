using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private EnemyAttackBase[] attacks;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform playerTransform;

    private float cooldownTimer = 0f;

    void Update()
    {
        if (attacks == null || attacks.Length == 0)
        {
            Debug.LogWarning($"{name}: attacks が未設定です");
            return;
        }

        if (muzzle == null)
        {
            Debug.LogWarning($"{name}: muzzle が未設定です");
            return;
        }

        if (playerTransform == null)
        {
            Debug.LogWarning($"{name}: playerTransform が未設定です");
            return;
        }

        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0f) return;

        EnemyAttackBase attack = GetRandomAttack();
        if (attack == null)
        {
            Debug.LogWarning($"{name}: ランダムで選ばれた attack が null です");
            return;
        }

        attack.ExecuteAttack(transform, muzzle, playerTransform);

        cooldownTimer = attack.Interval;
    }

    private EnemyAttackBase GetRandomAttack()
    {
        int index = Random.Range(0, attacks.Length);
        return attacks[index];
    }
}