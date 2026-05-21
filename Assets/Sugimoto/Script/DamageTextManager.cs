using UnityEngine;

public class DamageTextManager : MonoBehaviour
{
    public static DamageTextManager Instance;

    [SerializeField] private DamageText damageTextPrefab;
    [SerializeField] private Transform canvasTransform;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDamage(int damage, Collider2D enemy)
    {
        // 敵の位置 → 画面座標に変換
        Vector3 screenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);

        // ダメージテキスト生成
        DamageText text = Instantiate(damageTextPrefab, canvasTransform);

        text.SetText(damage, screenPos);
    }
}