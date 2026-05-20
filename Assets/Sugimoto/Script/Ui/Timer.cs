using UnityEngine;
using UnityEngine.UI;

public class Timer: MonoBehaviour
{
    [SerializeField] private float duration = 60f; // タイマーの制限時間
    [SerializeField] private TMPro.TextMeshProUGUI _timerText; // タイマー表示用のテキスト
    private float _remainingTime; // 残り時間

    void Start()
    {
        _remainingTime = duration;
    }

    void Update()
    {
        _remainingTime -= Time.deltaTime;

        if (_remainingTime <= 0)
        {
            _remainingTime = 0;
            TimeUp();
        }

        // UI更新
        _timerText.text = _remainingTime.ToString("F1");
    }

    // タイマー終了時の処理
    void TimeUp()
    {
        Debug.Log("時間切れ！");

        enabled = false;
    }
}
