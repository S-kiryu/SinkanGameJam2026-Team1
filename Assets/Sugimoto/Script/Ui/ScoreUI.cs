using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = $"Score: {ScoreManager.Instance.Score}";
    }
}