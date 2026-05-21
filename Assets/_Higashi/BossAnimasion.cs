using UnityEngine;

public class BossAnimasion : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HitAnima()
    {
        animator.SetTrigger("Hit");
    }
}