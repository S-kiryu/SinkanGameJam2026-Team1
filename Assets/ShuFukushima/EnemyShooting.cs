using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private EnemyAttackBase[] attacks;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform playerTransform;

    void Start()
    {
        foreach (var attack in attacks)
        {
            attack.Init();
        }
    }

    void Update()
    {
        foreach (var attack in attacks)
        {
            attack.UpdateAttack(transform, muzzle, playerTransform);
        }
    }
}