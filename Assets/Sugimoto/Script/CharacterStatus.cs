using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [Header("Base Status")]
    [SerializeField] private float baseAttack = 1f;
    [SerializeField] private float baseDefense = 1f;
    [SerializeField] private float baseSpeed = 1f;
    [SerializeField] private float baseMaxHp = 1f;

    //バフの値を保持する辞書
    private readonly Dictionary<StatType, float> buffValues = new();

    public float Attack => baseAttack + GetBuffValue(StatType.Attack);
    public float Defense => baseDefense + GetBuffValue(StatType.Defense);
    public float Speed => baseSpeed + GetBuffValue(StatType.Speed);
    public float MaxHp => baseMaxHp + GetBuffValue(StatType.MaxHp);

    //バフの値を更新するメソッド
    public void ApplyBuffValues(Dictionary<StatType, float> values)
    {
        buffValues.Clear();

        foreach (var pair in values)
        {
            Debug.Log(pair.Key + "のバフ値を" + pair.Value + "に設定");
            buffValues[pair.Key] = pair.Value;
        }
    }

    //バフの値を取得するメソッド
    private float GetBuffValue(StatType statType)
    {
        return buffValues.TryGetValue(statType, out var value) ? value : 0f;
    }
}