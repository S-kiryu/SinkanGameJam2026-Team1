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

        foreach (var activeBuff in activeBuffs)
        {
            var modifiers = activeBuff.Buff.GetModifiers();

            //各バフの効果を合計する
            foreach (var modifier in modifiers)
            {
                if (!totalValues.ContainsKey(modifier.StatType))
                {
                    totalValues[modifier.StatType] = 0f;
                }
                Debug.Log(modifier.StatType + "に" + modifier.Value + "のバフ効果を追加");
                totalValues[modifier.StatType] += modifier.Value;
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