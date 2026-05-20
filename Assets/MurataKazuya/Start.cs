using UnityEngine;
using UnityEngine.SceneManagement; // 追加

public class Start : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneManager.LoadScene("GameScene"); // "GameScene" の部分はシーンの名前に変更
    }
}