using System.Collections.Generic;
using UnityEngine;

public class AttackBuff : BuffBase
{
    [SerializeField] private float attackIncrease = 10f;

    //バフの効果を定義するリスト
    private List<StatModifier> modifiers;

    private void Awake()
    {
        modifiers = new List<StatModifier>
        {
            new StatModifier
            {
                StatType = StatType.Attack,
                Value = attackIncrease
            }
        };
    }

    //強化するバフのリストを返す
    public override IReadOnlyList<StatModifier> GetModifiers()
    {
        return modifiers;
    }
}