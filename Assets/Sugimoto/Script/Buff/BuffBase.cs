using System.Collections.Generic;
using UnityEngine;

public abstract class BuffBase: ScriptableObject
{
    public abstract IReadOnlyList<StatModifier> GetModifiers();
}