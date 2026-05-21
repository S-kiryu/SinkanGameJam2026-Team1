using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = $"Score: {ScoreManager.Instance.Score}";
    }
}