using UnityEngine;

public abstract class EnemyAttackBase : ScriptableObject
{
    public float Interval = 1f;

    public abstract void ExecuteAttack(Transform enemy, Transform muzzle, Transform player);
}