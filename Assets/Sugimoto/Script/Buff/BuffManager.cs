using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField] private CharacterStatus targetStatus;

    //今効果が適用されているバフのリスト
    private readonly List<ActiveBuff> activeBuffs = new();

    private void Awake()
    {
        if (targetStatus == null)
            targetStatus = GetComponent<CharacterStatus>();

        RecalculateStatus();
    }


    //新しいバフを追加するメソッド
    public void AddBuff(BuffBase buff)
    {
        if (buff == null)
        {
            return;
        }

        activeBuffs.Add(new ActiveBuff(buff));
        RecalculateStatus();
    }

    //特定のバフを削除するメソッド
    public void RemoveBuff(BuffBase buff)
    {
        activeBuffs.RemoveAll(x => x.Buff == buff);
        RecalculateStatus();
    }

    //すべてのバフをクリアするメソッド
    public void ClearBuffs()
    {
        activeBuffs.Clear();
        RecalculateStatus();
    }

    //バフの効果を再計算してステータスに適用するメソッド
    private void RecalculateStatus()
    {
        if (targetStatus == null)
        {
            return;
        }

        Dictionary<StatType, float> totalValues = new();
        Dictionary<BuffBase, int> sameBuffCounts = new();

        //同じバフの数をカウント
        foreach (var activeBuff in activeBuffs)
        {
            if (activeBuff.Buff == null)
            {
                continue;
            }

            if (!sameBuffCounts.ContainsKey(activeBuff.Buff))
            {
                sameBuffCounts[activeBuff.Buff] = 0;
            }

            sameBuffCounts[activeBuff.Buff]++;
        }

        //同じバフの数に基づいて、各バフの効果を合計
        foreach (var pair in sameBuffCounts)
        {
            BuffBase buff = pair.Key;
            int sameBuffCount = pair.Value;
            var modifiers = buff.GetModifiers();

            foreach (var modifier in modifiers)
            {
                if (!totalValues.ContainsKey(modifier.StatType))
                {
                    totalValues[modifier.StatType] = 0f;
                }

                float addedValue = modifier.GetTotalValue(sameBuffCount);
                totalValues[modifier.StatType] += addedValue;

                Debug.Log($"{buff.name} x{sameBuffCount} : {modifier.StatType} に {addedValue} のバフ効果を追加");
            }
        }

        targetStatus.ApplyBuffValues(totalValues);
    }

    private class ActiveBuff
    {
        public BuffBase Buff { get; }

        public ActiveBuff(BuffBase buff)
        {
            Buff = buff;
        }
    }
}