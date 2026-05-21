using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            var status = collision.GetComponent<CharacterStatus>();

            if (status != null)
            {
                Debug.Log($"{name}: Player に {damage} ダメージ");
                status.TakeDamage(damage);

                Destroy(gameObject);
            }

        }
    }
}
