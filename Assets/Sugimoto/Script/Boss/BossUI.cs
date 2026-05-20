using UnityEngine;

public class BossUI : MonoBehaviour
{
    [SerializeField] private BossStatus boss;
    [SerializeField] private HPgauge gauge;

    private void Start()
    {
        boss.OnHpChanged += gauge.UpdateGauge;
        gauge.UpdateGauge(boss.MaxHp, boss.CurrentHp);
    }
}