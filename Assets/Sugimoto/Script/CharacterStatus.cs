using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [Header("Base Status")]
    [SerializeField] private float _baseAttack = 1f;
    [SerializeField] private float _baseBarret = 1f;
    [SerializeField] private float _baseSpeed = 1f;
    [SerializeField] protected float _shootingInterval = 1f;
    [SerializeField] private float _baseMaxHp = 1f;
    [SerializeField] private int _smallcannon = 0;

    private float _currentHp;

    private readonly Dictionary<StatType, float> buffValues = new();

    public float Attack => _baseAttack + GetBuffValue(StatType.Attack);
    public float Barret => _baseBarret + GetBuffValue(StatType.Barret);
    public float Speed => _baseSpeed + GetBuffValue(StatType.Speed);
    public float ShootingInterval => _shootingInterval + GetBuffValue(StatType.ShootingInterval);
    public float MaxHp => _baseMaxHp + GetBuffValue(StatType.MaxHp);
    public int Smallcannon => _smallcannon + (int)GetBuffValue(StatType.Smallcannon);
    public float CurrentHp => _currentHp;
    
    public Action<float, float> OnHpChanged;
    public Action<int> OnSmallcannonChanged;

    private void Awake()
    {
        _currentHp = MaxHp;
    }

    public void TakeDamage(float damage)
    {
        _currentHp = Mathf.Max(_currentHp - damage, 0f);
        OnHpChanged?.Invoke(MaxHp, _currentHp);

        Debug.Log(damage + "のダメージを受けた。残りHP: " + _currentHp);

        if (_currentHp <= 0f)
        {
            Death();
        }
    }

    public void ApplyBuffValues(Dictionary<StatType, float> values)
    {
        int previousSmallcannon = Smallcannon;

        buffValues.Clear();

        foreach (var pair in values)
        {
            buffValues[pair.Key] = pair.Value;
        }

        if (previousSmallcannon != Smallcannon)
        {
            OnSmallcannonChanged?.Invoke(Smallcannon);
        }
    }

    private void Death()
    {
        Debug.Log("キャラクターは死んだ");
    }

    private float GetBuffValue(StatType statType)
    {
        return buffValues.TryGetValue(statType, out var value) ? value : 0f;
    }
}