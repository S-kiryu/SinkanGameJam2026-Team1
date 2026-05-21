using UnityEngine;

/// <summary>
/// バフ取得時の効果表示
/// </summary>
public class BuffLogManager : MonoBehaviour
{
    [SerializeField] private BuffManager _buffManager;
    [SerializeField] private BuffLogView _buffLogViewPrefab;

    private void Start()
    {
        _buffManager.OnBuffAdded += BuffManagerOnOnBuffAdded;
    }

    private void BuffManagerOnOnBuffAdded(BuffBase obj)
    {
        var modifiers = obj.GetModifiers();

        foreach (var mod in modifiers)
        {
            var log = Instantiate(_buffLogViewPrefab, transform.position, Quaternion.identity);

            log.SetBuffInfo(mod);
        }
    }

    public void ShowLog(StatModifier modifier)
    {
        modifier.StatType.ToString();
    }
}
