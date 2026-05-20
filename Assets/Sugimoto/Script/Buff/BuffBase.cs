using System.Collections.Generic;
using UnityEngine;

public abstract class BuffBase : MonoBehaviour
{
    //バフの名前と持続時間を定義
    [field: SerializeField] public string BuffName { get; private set; }

    public abstract IReadOnlyList<StatModifier> GetModifiers();
}