using UnityEngine;

public class RankingSender : MonoBehaviour
{
    public void SendRanking(int score)
    {
        var item = new RankingItem { score = score };
        RankingIOService.RegisterRank(item);
        Debug.Log($"スコアを保存しました: {score}");
    }
}
