using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void OnStartButton(string nextScene)
    {
        SceneManager.LoadScene(nextScene); // "GameScene" の部分はシーンの名前に変更
    }
}