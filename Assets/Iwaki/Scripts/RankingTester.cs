using UnityEngine;

public class RankingTester : MonoBehaviour
{
    public RankingRegisterInfo item;

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
