using System;

[Serializable]
public struct StatModifier
{
    //種類と値を定義
    public StatType StatType;
    public float Value;

    //同じバフが重なったときの値の増加量
    public float ValueIncreasePerSameBuff;

    public float GetValuePerBuff(int sameBuffCount)
    {
        int extraStackCount = sameBuffCount - 1;

        return Value + (ValueIncreasePerSameBuff * extraStackCount);
    }

    //同じバフが重なったときの合計値を計算するメソッド
    public float GetTotalValue(int sameBuffCount)
    {
        return GetValuePerBuff(sameBuffCount) * sameBuffCount;
    }
}