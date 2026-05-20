using UnityEngine;

public class BuffPickup : MonoBehaviour
{
    [SerializeField] private BuffBase buffPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("“–‚½‚Á‚½");
        BuffManager buffManager = other.GetComponent<BuffManager>();

        if (buffManager == null)
        {
            return;
        }

        buffManager.AddBuff(buffPrefab);

    }
}