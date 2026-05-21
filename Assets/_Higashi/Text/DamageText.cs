using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void SetText(int damage, Vector3 position)
    {
        text.text = damage.ToString();
        transform.position = position;

        Destroy(gameObject, 1f);
    }
}