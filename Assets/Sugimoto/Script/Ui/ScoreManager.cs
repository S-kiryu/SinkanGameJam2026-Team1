using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    public int Score => _score;
    public void AddScore(int score)
    {
        _score += score;
    }
    public void ResetScore()
    {
        _score = 0;
    }
}
