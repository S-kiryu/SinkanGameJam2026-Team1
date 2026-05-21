using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankingView : MonoBehaviour
{
    [SerializeField] Transform _rankingBoardRoot;

    RankingData _rankingData; // ランキングデータのインスタンス

    private void Start()
    {
        _rankingData = RankingIOService.Load();

        var items = _rankingBoardRoot.GetComponentsInChildren<RankingItemView>(false);

        foreach (RankingItemView t in items)
        {
            t.SetNoData();
        }

        var ranking = _rankingData.GetOrderedRanking();
        var latestIndex = RankingData.GetLatestRank(ranking);

        for (int i = 0; i < ranking.Count; i++)
        {
            if (i >= items.Length) return;
            items[i].SetData(ranking[i], i, i == latestIndex);
        }
    }
}

[System.Serializable]
public struct RankingRegisterInfo
{
    public int Score;

    public RankingRegisterInfo(int score)
    {
        Score = score;
    }
}

/// <summary>
/// ランキング情報の１個ずつ
/// </summary>
[System.Serializable]
public readonly struct RankingItem
{
    public readonly int Score;
    public readonly int Index;

    public RankingItem(RankingData data, RankingRegisterInfo info)
    {
        Score = info.Score;
        Index = data.Count + 1;
    }
}

/// <summary>
/// Jsonで保存するランキングデータ
/// </summary>
[System.Serializable]
public class RankingData
{
    [SerializeField] private List<RankingItem> _ranks = new();

    public int Count => _ranks.Count;

    public void AddItem(RankingItem item)
    {
        _ranks.Add(item);
    }

    public List<RankingItem> GetOrderedRanking()
    {
        return _ranks.OrderBy(x => x.Score).ToList();
    }

    public static int GetLatestRank(List<RankingItem> items)
    {
        var latestIndex = items.Max(x => x.Index);
        return items.FindIndex(x => x.Index == latestIndex);
    }
}
