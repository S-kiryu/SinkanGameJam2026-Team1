using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int _score;
    public int Score => _score;

    private void Awake()
    {
        Instance = this;
        _score = 0;
    }

    public void AddScore(int value)
    {
        _score += value;
    }
}