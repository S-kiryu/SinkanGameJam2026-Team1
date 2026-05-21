using UnityEngine;
using TMPro; // TextMeshProを使うために必要

public class DamageText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float disappearSpeed = 3f;
    [SerializeField] private float lifetime = 0.5f;

    private Color textColor;
    private bool isInitialized = false;

    public void Setup(int damageAmount, Vector3 worldPos)
    {
        if (textMesh == null) textMesh = GetComponent<TextMeshProUGUI>();

        textMesh.text = damageAmount.ToString();
        textColor = textMesh.color;

        Vector3 offset = Vector3.up * 0.8f;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos + offset);
        transform.position = screenPos;

        isInitialized = true;
    }

    void Update()
    {
        if (!isInitialized) return;

        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);

        lifetime -= Time.deltaTime;

        if (lifetime < 0)
        {
            textColor.a -= disappearSpeed * Time.deltaTime;
            if (textMesh != null)
            {
                textMesh.color = textColor;
            }

            if (textColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}