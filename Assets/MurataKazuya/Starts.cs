using UnityEngine;
using UnityEngine.SceneManagement;

public class Starts : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject FadeObject;
    public void FadeIn()
    {
        animator.SetTrigger("FadeateTrigger");
    }

    public void OnStartButton(string nextScene)
    {
        SceneManager.LoadScene(nextScene); // "GameScene" の部分はシーンの名前に変更
    }
}