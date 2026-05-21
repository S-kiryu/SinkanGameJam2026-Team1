using UnityEngine;
using UnityEngine.UI;

public class RankingItemView : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] private GameObject _isNewDisplay;

    public void SetData(RankingItem item, int rank, bool isNew)
    {
        scoreText.text = $"{item.Score}"; // ランキングとスコアを表示
        if (_isNewDisplay) _isNewDisplay.SetActive(isNew);
    }

    public void SetNoData()
    {
        scoreText.text = "N/A";
    }
}
