using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewCurrentScore : MonoBehaviour
{
    [SerializeField] private int _scoreDigits = 1;
    [SerializeField] Text _text;
    [SerializeField] private TextMeshProUGUI _textPro;
    [SerializeField] private string _prefix;

    void Start()
    {
        if (_text) _text.text = GetScoreString();
        if (_textPro) _textPro.text = GetScoreString();
    }

    string GetScoreString()
    {
        int score = ScoreManager.LastScore;
        return $"{_prefix}{FormatNumber(score, _scoreDigits)}";
    }

    string FormatNumber(int value, int digits)
    {
        // 数値の桁数が最大桁数を超えていたらそのまま返す
        if (value.ToString().Length >= digits)
            return value.ToString();

        // 足りない分だけ0埋め
        return value.ToString("D" + digits);
    }
}
