using UnityEngine;

/// <summary>
/// シーンロード時に現在スコアをランキングに登録するだけ
/// </summary>
public class CurrectScoreSender : MonoBehaviour
{
    private void Awake()
    {
        var info = new RankingRegisterInfo(ScoreManager.Instance.LastScore);
        RankingIOService.RegisterRank(info);
    }
}
