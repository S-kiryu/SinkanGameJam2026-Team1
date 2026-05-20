using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [Header("Base Status")]
    [SerializeField] private float _baseAttack = 1f;
    [SerializeField] private float _baseBarret = 1f;
    [SerializeField] private float _baseSpeed = 1f;
    [SerializeField] private float _baseMaxHp = 1f;

    private float _currentHp;

    //バフの値を保持する辞書
    private readonly Dictionary<StatType, float> buffValues = new();

    public float Attack => _baseAttack + GetBuffValue(StatType.Attack);
    public float Barret => _baseBarret + GetBuffValue(StatType.Barret);
    public float Speed => _baseSpeed + GetBuffValue(StatType.Speed);
    public float MaxHp => _baseMaxHp + GetBuffValue(StatType.MaxHp);

    private void Awake()
    {
        _currentHp = _baseMaxHp;
    }


    public void TakeDamage(float damage)
    {
        _currentHp -= damage;
        Debug.Log(damage + "のダメージを受けた。残りHP: " + _currentHp);

        if (_currentHp <= 0)
        {
            _currentHp = 0;
            Death();
        }
    }
    //バフの値を更新するメソッド
    public void ApplyBuffValues(Dictionary<StatType, float> values)
    {
        buffValues.Clear();

        foreach (var pair in values)
        {
            //Debug.Log(pair.Key + "のバフ値を" + pair.Value + "に設定");
            buffValues[pair.Key] = pair.Value;
        }
    }

    private void Death()
    {
        Debug.Log("キャラクターは死んだ");
    }
    //バフの値を取得するメソッド
    private float GetBuffValue(StatType statType)
    {
        return buffValues.TryGetValue(statType, out var value) ? value : 0f;
    }
}