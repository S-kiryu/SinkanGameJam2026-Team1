using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int Score { get; private set; }

    private void Awake()
    {
        Instance = this;
        Score = 0;
    }

    public void AddScore(int value)
    {
        Score += value;
    }
}