using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int _score;
    public int Score => _score;

    public static int LastScore;

    private void Awake()
    {
        Instance = this;
        _score = 0;
        LastScore = _score;
    }

    public void AddScore(int value)
    {
        _score += value;
        LastScore = _score;
    }
}
