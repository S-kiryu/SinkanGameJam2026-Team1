using System.Collections.Generic;
using UnityEngine;

public class RankingView : MonoBehaviour
{
    [SerializeField] Transform _rankingBoardRoot;

    RankingData _rankingData; // ランキングデータのインスタンス

    private void Start()
    {
        _rankingData = RankingIOService.Load();

        var items = _rankingBoardRoot.GetComponentsInChildren<RankingItemView>(false);

        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetData(null, i);
        }

        for (int i = 0; i < _rankingData.ranks.Count; i++)
        {
            items[i].SetData(_rankingData.ranks[i], i);
        }
    }
}

/// <summary>
/// ランキング情報の１個ずつ
/// </summary>
[System.Serializable]
public class RankingItem
{
    public int score;
}

/// <summary>
/// Jsonで保存するランキングデータ
/// </summary>
[System.Serializable]
public class RankingData
{
    public List<RankingItem> ranks = new();
}
