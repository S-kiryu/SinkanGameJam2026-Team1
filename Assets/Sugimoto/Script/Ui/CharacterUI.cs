using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private CharacterStatus status;
    [SerializeField] private HPgauge gauge;

    private void OnEnable()
    {
        status.OnHpChanged += gauge.UpdateGauge;
    }

    private void Start()
    {
        gauge.UpdateGauge(status.MaxHp, status.CurrentHp);
    }

    private void OnDisable()
    {
        status.OnHpChanged -= gauge.UpdateGauge;
    }
}