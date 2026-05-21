using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int _score;
    public int Score => _score;

    public int LastScore { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _score = 0;
        LastScore = 0;
    }

    public void AddScore(int value)
    {
        _score += value;
        LastScore = _score;
    }
}