using UnityEngine;

[System.Serializable]
public class DropSetting
{
    [Range(0f, 1f)] public float hpRate; // 何％で発動
    public int dropCount; // 個数
}

public class buffDrop : MonoBehaviour
{
    [SerializeField] private GameObject[] debugBuffItems;
    [SerializeField] private BossStatus bossHP;
    [SerializeField] private DropSetting[] dropSettings;

    private bool[] hasDropped;

    private void Start()
    {
        AudioManager.Instance.PlayBGM("InGame01", 0.3f);
        hasDropped = new bool[dropSettings.Length];
    }

    void Update()
    {
        float hpRate = bossHP.CurrentHp / bossHP.MaxHp;

        for (int i = 0; i < dropSettings.Length; i++)
        {
            if (!hasDropped[i] && hpRate <= dropSettings[i].hpRate)
            {
                DropItem(dropSettings[i].dropCount);
                hasDropped[i] = true;
            }
        }
    }

    private void DropItem(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, debugBuffItems.Length);

            float x = Random.Range(0.1f, 0.9f);
            float y = Random.Range(0.1f, 0.9f);

            Vector3 viewportPos = new Vector3(x, y, 0);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);
            worldPos.z = 0;

            Instantiate(debugBuffItems[index], worldPos, Quaternion.identity);
        }
    }
}