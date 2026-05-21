using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStatus : MonoBehaviour
{
    [SerializeField] private float _maxHp = 100f;
    private float _currentHp;

    public float MaxHp => _maxHp;
    public float CurrentHp => _currentHp;

    public System.Action<float, float> OnHpChanged;

    private void Awake()
    {
        _currentHp = _maxHp;
        OnHpChanged?.Invoke(MaxHp, CurrentHp);
    }

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;

        OnHpChanged?.Invoke(MaxHp, CurrentHp);

        if (_currentHp <= 0)
        {
            _currentHp = 0;
            BossDead();
        }
    }

    public void BossDead()
    {
        Debug.Log("Boss defeated!");
        SceneManager.LoadScene("Game Clear");
    }
}