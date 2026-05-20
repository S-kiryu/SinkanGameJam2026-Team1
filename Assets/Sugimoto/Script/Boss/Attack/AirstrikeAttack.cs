using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAttack/AirstrikeAttack")]
public class AirstrikeAttack : EnemyAttackBase
{
    [SerializeField] private GameObject Airstrik;
    [SerializeField] private GameObject AirstrikEffect;
    [SerializeField] private float warningTime = 1.5f;
    [SerializeField] private float spawnHeight = 8f;
    [SerializeField] private float speed = 5f;

    public override IEnumerator ExecuteAttack(Transform enemy, Transform muzzle, Transform player)
    {
        if (Airstrik == null || AirstrikEffect == null || player == null)
        {
            yield break;
        }

        Vector3 targetPosition = player.position;

        GameObject effect = Instantiate(AirstrikEffect, targetPosition, Quaternion.identity);
        SpriteRenderer sr = effect.GetComponent<SpriteRenderer>();

        // エフェクトの色を赤に設定
        if (sr != null)
        {
            Color color = sr.color;
            color.r = 1f;
            color.g = 0f;
            color.b = 0f;
            color.a = 0f;
            sr.color = color;

            float timer = 0f;
            while (timer < warningTime)
            {
                timer += Time.deltaTime;
                float t = Mathf.Clamp01(timer / warningTime);

                color.a = t;
                sr.color = color;

                yield return null;
            }
        }
        else
        {
            yield return new WaitForSeconds(warningTime);
        }

        if (effect != null)
        {
            Destroy(effect);
        }

        Vector3 spawnPosition = targetPosition + Vector3.up * spawnHeight;
        GameObject airstrike = Instantiate(Airstrik, spawnPosition, Quaternion.identity);

        if (airstrike.TryGetComponent(out Rigidbody2D rb))
        {
            rb.linearVelocity = Vector2.down * speed;
        }
    }
}