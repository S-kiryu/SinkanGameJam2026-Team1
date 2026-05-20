using UnityEngine;

public class buffDrop : MonoBehaviour
{
    [SerializeField] private GameObject[] debugBuffItems;
    [SerializeField] private BossStatus bossHP;

    private bool drop80;
    private bool drop50;
    private bool drop10;

    void Update()
    {
        float hpRate = bossHP.CurrentHp / bossHP.MaxHp;

        if (!drop80 && hpRate <= 0.8f)
        {
            DropItem();
            drop80 = true;
        }

        if (!drop50 && hpRate <= 0.5f)
        {
            DropItem();
            drop50 = true;
        }

        if (!drop10 && hpRate <= 0.1f)
        {
            DropItem();
            drop10 = true;
        }
    }

    private void DropItem()
    {
        int index = Random.Range(0, debugBuffItems.Length);
        Instantiate(debugBuffItems[index], transform.position, Quaternion.identity);
    }
}