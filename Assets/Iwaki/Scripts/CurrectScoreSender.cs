using UnityEngine;

/// <summary>
/// シーンロード時に現在スコアをランキングに登録するだけ
/// </summary>
public class CurrectScoreSender : MonoBehaviour
{
    private void Awake()
    {
        var item = new RankingItem { score = ScoreManager.LastScore };
        RankingIOService.RegisterRank(item);
    }
}
