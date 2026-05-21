using UnityEngine;

public class colorFade : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    private SpriteRenderer spriteRenderer;
    private float timer = 0f;
    private readonly float targetAlpha = 200f / 255f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Color c = spriteRenderer.color;
        c.a = 0f;
        spriteRenderer.color = c;
    }

    void Update()
    {
        if (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            float progress = Mathf.Clamp01(timer / fadeDuration);
            float alpha = progress * targetAlpha;

            Color c = spriteRenderer.color;
            c.a = alpha;
            spriteRenderer.color = c;
        }
    }
}