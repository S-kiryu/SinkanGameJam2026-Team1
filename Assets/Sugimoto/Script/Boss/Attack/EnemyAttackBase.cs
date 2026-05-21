using System.Collections;
using UnityEngine;

public abstract class EnemyAttackBase : ScriptableObject
{
    [SerializeField] private float interval = 1f;
    public float Interval => interval;

    /// <summary>
    /// UŒ‚‚ÌÀsˆ—‚ğ‘‚­‚Æ‚±‚ë
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="muzzle"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    public abstract IEnumerator ExecuteAttack(Transform enemy, Transform muzzle, Transform player);
}