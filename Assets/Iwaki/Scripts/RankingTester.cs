using UnityEngine;

public class RankingTester : MonoBehaviour
{
    public RankingItem item;

    [ContextMenu("Register")]
    public void Register()
    {
        RankingIOService.RegisterRank(item);
    }

    [ContextMenu("Reset")]
    public void ResetRank()
    {
        RankingIOService.ResetRank();
    }
}
