using UnityEngine;

public abstract class EnemyAttackBase
{
    public float Damage { get; protected set; }
    public float Speed { get; protected set; }
    public float Lifetime { get; protected set; }


    protected float timer;

    public virtual void OnEnter()
    {
        timer = 0f;
    }

    public virtual void UpdateAttack(Transform enemy)
    {
        timer += Time.deltaTime;
        Execute(enemy);
    }

    public bool IsFinished()
    {
        return timer >= Lifetime;
    }

    protected abstract void Execute(Transform enemy);
}
