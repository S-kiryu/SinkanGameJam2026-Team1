using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackBuff", menuName = "Buffs/AttackBuff")]
public class Buff : BuffBase
{

    //バフの効果を定義するリスト
    [SerializeField]private List<StatModifier> modifiers;

    //private void Awake()
    //{
    //    modifiers = new List<StatModifier>
    //    {
    //        new StatModifier
    //        {
    //            StatType = StatType.Attack,
    //            Value = attackIncrease
    //        }
    //    };
    //}

    //強化するバフのリストを返す
    public override IReadOnlyList<StatModifier> GetModifiers()
    {
        return modifiers;
    }
}